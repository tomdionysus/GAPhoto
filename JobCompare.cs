using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
    public class JobCompare : JQJob, IDisposable
    {
        public GAProjectProperties Properties;
        public GARepresentation Best;
        public FastBitmap Img = null;
        public FastBitmap WorkingImg = null;
        public double BestComparison;
        public ThreadSafeRandom Entropy;
        private bool _stop = false;
        private bool _disposed = false;

        ~JobCompare()
        {
            Dispose(false);
        }
        public override sealed void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Properties = null;
                    Best = null;
                    Img.Dispose();
                    WorkingImg.Dispose();
                    Entropy = null;
                }
                _disposed = true;
            }
        }
        public override void Init()
        {
        }

        public override void Run()
        {
            try
            {
                while (!_stop)
                {
                    if (_input.Count > 0)
                    {
                        MsgCommand mc = (MsgCommand)_input.Dequeue();
                        switch (mc.Command)
                        {
                            case MsgCommandCommands.Init:
                                LoadInit(mc);
                                break;
                            case MsgCommandCommands.LoadBestYet:
                                LoadBestYet(mc);
                                break;
                            case MsgCommandCommands.Stop:
                                _stop = true;
                                break;
                        }
                    }

                    if (Img != null)
                    {
                        if (ProcessIteration())
                        {
                            SendBestYet();
                            Thread.Sleep(0);
                        }
                    }
                    Thread.Sleep(0);

                }

                CallFinished(new JQEventArgs(this));
            }
            catch (Exception e)
            {
                CallError(new JQEventArgs(this), e);
            }
        }

        private void LoadInit(MsgCommand mc)
        {
            Best = mc.Best;
            BestComparison = mc.BestComparison;
            Properties = mc.Properties;
            Img = mc.Img;
            WorkingImg = new FastBitmap(Img.Width, Img.Height, PixelFormat.Format24bppRgb);
            Entropy = mc.Entropy;
        }
        private void LoadBestYet(MsgCommand mc)
        {
            Best = mc.Best;
            BestComparison = mc.BestComparison;
        }

        private void SendBestYet()
        {
            var msg = new MsgCommand(this, MsgCommandCommands.SaveBestYet)
            {
                BestComparison = BestComparison,
                Best = Best
            };
            _output.Enqueue(msg);
        }
        private bool ProcessIteration()
        {
            if (Best.Generation == 0)
            {
                Best = new GARepresentation(WorkingImg.GetBitmap().Width, WorkingImg.GetBitmap().Height);
                SeedRepresentation(Best);
            }

            GARepresentation nextgen = Best.Duplicate();
            nextgen.Mutate(Entropy, Properties);

            nextgen.DrawToFastBitmap(WorkingImg);
            double nextcomp = FastBitmap.UltraCompare(Img, WorkingImg);

            if ((nextcomp < BestComparison) || ((nextcomp == BestComparison) && (nextgen.Shapes.Count < Best.Shapes.Count)))
            {
                Best = nextgen;
                BestComparison = nextcomp;
                Best.Generation++;

                return true;
            }

            return false;
        }

        private void SeedRepresentation(GARepresentation rep)
        {
            if (Properties.BackgroundColorFromHistogram)
            {
                rep.ComputeBackground(Img);
            }

            switch (Properties.Seeding)
            {
                case GASeeding.RandomSeed:
                    rep.GenericSeed(Entropy, Properties);
                    break;
                case GASeeding.MatrixSeed:
                    rep.MatrixSeed(Img.GetBitmap(), Properties);
                    break;
            }


        }
    }
}
