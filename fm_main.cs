using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using JQFramework;

namespace GAPhoto
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PixelData
    {
        public byte blue;
        public byte green;
        public byte red;
        public byte alpha;

        public override string ToString()
        {
            return "(" + alpha.ToString() + ", " + red.ToString() + ", " + green.ToString() + ", " + blue.ToString() + ")";
        }
    }

    public partial class fm_main : Form
    {
        public const string VERSION = "0.1 ALPHA";

        Thread tr = null;
        DateTime started = DateTime.Now;
        bool changed = false;
        bool stopthread = false;

        public string InitialProjectFilename = null;

        uint lastiterations = 0;

        int lastjobbest = 0;

        JQController control = new JQController();

        MovingAverage AIpG = new MovingAverage(10);
        MovingAverageF ACpG = new MovingAverageF(10);
        MovingAverage Gps = new MovingAverage(10);

        GAVectorProject CurrentProject = null;

        Bitmap displaysourcebitmap = null;
        Bitmap displayimagebitmap = null;

        public static ThreadSafeRandom rd = new ThreadSafeRandom();

        public fm_main()
        {
            InitializeComponent();

            control.Start();
        }

        private void UpdateControlEnabled()
        {
            if (CurrentProject == null)
            {
                Text = "GAVector V" + VERSION + " [No Project Loaded]";
                menu_project_save.Enabled = false;
                menu_project_saveas.Enabled = false;
                menu_project_properties.Enabled = false;
                menu_project_reseed.Enabled = false;
                menu_project_close.Enabled = false;
                btn_go.Enabled = false;
                btn_stop.Enabled = false;

            }
            else
            {
                Text = "GAVector V" + VERSION + " [" + CurrentProject.Filename + (CurrentProject.Changed ? "*" : "") + "]";
                menu_project_save.Enabled = CurrentProject.Changed;
                menu_project_saveas.Enabled = true;
                menu_project_properties.Enabled = true;
                menu_project_close.Enabled = true;
                if (tr != null)
                {
                    btn_go.Enabled = !tr.IsAlive;
                    btn_stop.Enabled = tr.IsAlive;
                    menu_project_reseed.Enabled = !tr.IsAlive;
                }
                else
                {
                    btn_go.Enabled = true;
                    btn_stop.Enabled = false;
                    menu_project_reseed.Enabled = true;
                }

                if (changed)
                {
                    // Source Bitmap
                    pb_source.Image = displaysourcebitmap;
                    pb_source.Refresh();

                    pb_image.Image = displayimagebitmap;
                    pb_image.Refresh();

                    this.Refresh();
                    changed = false;
                }
            }

        }
        private void workerthread()
        {
            int lastgen = (int)CurrentProject.BestYet.Generation;
            DateTime started = DateTime.Now;
            FastBitmap imagebitmap = new FastBitmap(CurrentProject.SourceImage.Width, CurrentProject.SourceImage.Height, PixelFormat.Format24bppRgb);

            List<JobCompare> jobs = new List<JobCompare>();

            JQMessageQueue results = new JQMessageQueue();

            for (int i = 0; i < CurrentProject.Properties.ThreadLimit; i++)
            {
                JobCompare job = new JobCompare();
                job.Input = new JQMessageQueue();
                job.Output = results;
                jobs.Add(job);

                MsgCommand msg = new MsgCommand(null, MsgCommandCommands.Init);
                msg.Best = CurrentProject.BestYet;
                msg.BestComparison = CurrentProject.BestComparison;
                msg.Entropy = rd;
                msg.Img = CurrentProject.SourceImage.Duplicate();
                msg.Properties = CurrentProject.Properties;

                job.Input.Enqueue(msg);
                control.ScheduleJob(job);
            }

            while (!stopthread)
            {
                results.Trigger.WaitOne(100);

                while (results.Count > 0)
                {
                    MsgCommand msg = (MsgCommand)results.Dequeue();

                    switch (msg.Command)
                    {
                        case MsgCommandCommands.SaveBestYet:
                            lastiterations++;
                            if (msg.BestComparison < CurrentProject.BestComparison)
                            {
                                ACpG.Update(CurrentProject.BestComparison - msg.BestComparison);
                                AIpG.Update((int)(lastiterations - CurrentProject.BestYet.Iterations));

                                lastjobbest = jobs.IndexOf((JobCompare)msg.Job);

                                CurrentProject.BestYet = msg.Best;
                                CurrentProject.BestComparison = msg.BestComparison;
                                CurrentProject.Changed = true;
                                CurrentProject.BestYet.Generation++;
                                CurrentProject.BestYet.Iterations = lastiterations;
                            }
                            break;
                    }
                }

                TimeSpan sofar = DateTime.Now - started;

                if (sofar.TotalMilliseconds > 1000)
                {
                    CurrentProject.BestYet.DrawToFastBitmap(imagebitmap);
                    DisplayImageBitmap(imagebitmap);
                    changed = true;

                    started = DateTime.Now;
                    BroadcastBestYet(jobs);

                    Gps.Update((int)CurrentProject.BestYet.Generation - lastgen);
                    lastgen = (int)CurrentProject.BestYet.Generation;
                    GC.Collect();
                }
            }

            foreach (JQJob job in jobs)
            {
                MsgCommand msgot = new MsgCommand(null, MsgCommandCommands.Stop);
                job.Input.Enqueue(msgot);
            }
            stopthread = false;
        }

        private void BroadcastBestYet(List<JobCompare> jobs)
        {
            foreach (JQJob job in jobs)
            {
                MsgCommand msgot = new MsgCommand(null, MsgCommandCommands.LoadBestYet);
                msgot.BestComparison = CurrentProject.BestComparison;
                msgot.Best = CurrentProject.BestYet;
                job.Input.Clear();
                job.Input.Enqueue(msgot);
            }
        }

        private void DisplayImageBitmap(FastBitmap imagebitmap)
        {
            lock (imagebitmap)
            {
                displayimagebitmap = (Bitmap)imagebitmap.GetBitmap().Clone();
            }
            changed = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Status

            if ((tr != null) && (CurrentProject != null))
            {
                CurrentProject.BestYet.UpdateTotalPoints();
                double perc = CurrentProject.BestComparison / (CurrentProject.BestYet.MaxX * CurrentProject.BestYet.MaxY * 3 * 128) * 100;
                label1.Text = "Last Best Comparison: " + (CurrentProject.BestComparison.ToString() + " (" + (100 - perc).ToString("0.000") + "%) - AIpG: " + AIpG.Average().ToString("0.000") + " ACpG: " + ACpG.Average().ToString("0.000"));
                TimeSpan since = DateTime.Now - started;
                label2.Text = "Time: "
                    + since.Hours.ToString("00")
                    + ":" + since.Minutes.ToString("00")
                    + ":" + since.Seconds.ToString("00")
                    + " - Iterations: " + CurrentProject.BestYet.Iterations.ToString() + " Generation: " + CurrentProject.BestYet.Generation.ToString() + " Last Best Thread No.: " + lastjobbest.ToString() + " Avg Gen/sec: " + Gps.Average().ToString("0.000");
                label3.Text = "Shapes: " + CurrentProject.BestYet.Shapes.Count.ToString() + " - Total Points: " + CurrentProject.BestYet.TotalPoints.ToString();
            }

            UpdateControlEnabled();

        }

        private void menu_polygons_export_Click(object sender, EventArgs e)
        {
            if (sfd_export.ShowDialog() == DialogResult.OK)
            {
                switch (Path.GetExtension(sfd_export.FileName))
                {
                    case ".svg":
                        ExportSVG(sfd_export.FileName);
                        break;
                    default:
                        MessageBox.Show("Unknown Format to Export. Please choose a format from the Export dialog filetype.", "Unknown Export Format", MessageBoxButtons.OK);
                        break;
                }
            }
        }

        private bool IsProjectSaved()
        {
            if (CurrentProject != null)
            {
                if (CurrentProject.Changed)
                {
                    switch (MessageBox.Show("The current project has not been saved. Do you want to save the project first?", "Project Not Saved", MessageBoxButtons.YesNoCancel))
                    {
                        case DialogResult.Yes:
                            menu_project_save_Click(this, new EventArgs());
                            return true;
                        case DialogResult.No:
                            return true;
                        case DialogResult.Cancel:
                            return false;
                    }
                }
            }
            return true;
        }
        private void SaveCurrentProject()
        {
            if (CurrentProject == null)
            {
                throw new InvalidOperationException("SaveCurrentProject() - no current project");
            }
            else
            {
                if (CurrentProject.Filename == "")
                {
                    switch (sfd_save.ShowDialog())
                    {
                        case DialogResult.OK:
                            CurrentProject.Filename = sfd_save.FileName;
                            CurrentProject.Save();
                            break;
                    }
                }
                else
                {
                    CurrentProject.Save();
                }
            }
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            if (tr == null)
            {
                ThreadStart ts = new ThreadStart(workerthread);
                tr = new Thread(ts);
                tr.SetApartmentState(ApartmentState.MTA);
                tr.IsBackground = true;
                stopthread = false;
                tr.Start();
                btn_go.Enabled = false;
                btn_stop.Enabled = true;
            }
        }
        private void btn_stop_Click(object sender, EventArgs e)
        {
            if (tr != null)
            {
                if (tr.IsAlive) stopthread = true;
                tr.Join();
                tr = null;
                btn_go.Enabled = true;
                btn_stop.Enabled = false;
            }
        }

        private void fm_main_Load(object sender, EventArgs e)
        {
            if (InitialProjectFilename != null) LoadProject(InitialProjectFilename);
            UpdateControlEnabled();
        }
        private void fm_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsProjectSaved()) e.Cancel = true;
        }
        private void fm_main_Enter(object sender, EventArgs e)
        {
            UpdateControlEnabled();
        }

        private void menu_project_new_Click(object sender, EventArgs e)
        {
            if (IsProjectSaved())
            {
                if (ofd_openimage.ShowDialog() == DialogResult.OK)
                {
                    GAVectorProject newcp = new GAVectorProject();
                    newcp.Properties = new GAProjectProperties();
                    Bitmap b = new Bitmap(ofd_openimage.FileName);

                    newcp.SourceImage = new FastBitmap(b);
                    newcp.BestComparison = double.MaxValue;
                    fm_projectproperties frm = new fm_projectproperties();
                    frm.LoadProperties(newcp.Properties);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        newcp.BestYet = new GARepresentation(newcp.SourceImage.GetBitmap(), 10);
                        newcp.Properties = frm.GetProperties();
                        newcp.Changed = true;
                        CurrentProject = newcp;
                        displaysourcebitmap = (Bitmap)CurrentProject.SourceImage.GetBitmap().Clone();
                        changed = true;
                    }
                    else
                    {
                        // Cancelled, clean it all up
                        newcp = null;
                    }
                }
            }

            UpdateControlEnabled();
        }
        private void menu_project_load_Click(object sender, EventArgs e)
        {
            if (ofd_open.ShowDialog() == DialogResult.OK)
            {
                LoadProject(ofd_open.FileName);
            }
        }
        private void menu_project_save_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
            {
                if (CurrentProject.Filename == "")
                {
                    if (sfd_save.ShowDialog() != DialogResult.OK) return;
                    CurrentProject.Filename = sfd_save.FileName;
                }

                try
                {
                    CurrentProject.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A Problem occoured saving the project:\n\n" + ex.Message, "Error while saving project", MessageBoxButtons.OK);
                }
            }
        }
        private void menu_project_saveas_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
            {
                if (sfd_save.ShowDialog() != DialogResult.OK) return;
                CurrentProject.Filename = sfd_save.FileName;

                try
                {
                    CurrentProject.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A Problem occoured saving the project:\n\n" + ex.Message, "Error while saving project", MessageBoxButtons.OK);
                }

            }
        }
        private void menu_project_properties_Click(object sender, EventArgs e)
        {
            fm_projectproperties frm = new fm_projectproperties();
            frm.LoadProperties(CurrentProject.Properties);
            switch (frm.ShowDialog())
            {
                case DialogResult.OK:
                    CurrentProject.Properties = frm.GetProperties();
                    CurrentProject.Changed = true;
                    break;
                case DialogResult.Cancel:
                    break;
            }

            UpdateControlEnabled();
        }
        private void menu_project_reseed_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All progress will be lost. Are you sure you want to reseed the representation?", "Reseed: All progress will be lost", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            CurrentProject.BestYet = new GARepresentation(CurrentProject.SourceImage.GetBitmap().Width, CurrentProject.SourceImage.GetBitmap().Height);
            CurrentProject.BestComparison = double.MaxValue;
            DisplayRepresentation(CurrentProject.BestYet);
        }
        private void menu_project_quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DisplayRepresentation(GARepresentation rep)
        {
            FastBitmap fb = new FastBitmap(CurrentProject.SourceImage.Width, CurrentProject.SourceImage.Height, PixelFormat.Format24bppRgb);
            CurrentProject.BestYet.DrawToFastBitmap(fb);
            DisplayImageBitmap(fb);
        }
        private void UpdateBestComparison()
        {
            FastBitmap imagebitmap = new FastBitmap(CurrentProject.SourceImage.Width, CurrentProject.SourceImage.Height, PixelFormat.Format24bppRgb);
            CurrentProject.BestYet.DrawToFastBitmap(imagebitmap);
            CurrentProject.BestComparison = FastBitmap.UltraCompare(CurrentProject.SourceImage, imagebitmap);
            changed = true;
        }

        private void aboutGAVectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm_about about = new fm_about();
            about.ShowDialog();
        }

        private void LoadProject(string filename)
        {
            try
            {
                GAVectorProject openproj = new GAVectorProject(filename);

                openproj.Filename = filename;
                CurrentProject = openproj;
                CurrentProject.Changed = false;
                displaysourcebitmap = (Bitmap)CurrentProject.SourceImage.GetBitmap().Clone();
                DisplayRepresentation(CurrentProject.BestYet);
                UpdateBestComparison();
                changed = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("A Problem occured loading the project:\n\n" + ex.Message, "Error while loading project", MessageBoxButtons.OK);
            }
        }

        // Export Methods
        private void ExportSVG(string filename)
        {
            try
            {
                SvgNet.SvgGdi.SvgGraphics sg = new SvgNet.SvgGdi.SvgGraphics();
                CurrentProject.BestYet.Draw(sg);
                File.WriteAllText(filename, sg.WriteSVGString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Error while exporting to SVG format: " + e.Message, "Export Error", MessageBoxButtons.OK);
            }
        }

    }
}