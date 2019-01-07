namespace GAPhoto
{
    partial class fm_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_main));
            this.btn_go = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_stop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ms_main = new System.Windows.Forms.MenuStrip();
            this.menu_project = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_project_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_project_load = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_project_save = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_project_saveas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_project_properties = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_project_reseed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_project_close = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_project_quit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_polygons = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_polygons_import = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_polygons_export = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_tools = new System.Windows.Forms.ToolStripMenuItem();
            this.enu_tools_grid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_tools_preferences = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutGAVectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pb_source = new System.Windows.Forms.PictureBox();
            this.pb_image = new System.Windows.Forms.PictureBox();
            this.sfd_save = new System.Windows.Forms.SaveFileDialog();
            this.sfd_export = new System.Windows.Forms.SaveFileDialog();
            this.ofd_open = new System.Windows.Forms.OpenFileDialog();
            this.ofd_openimage = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.ms_main.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(4, 5);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(63, 23);
            this.btn_go.TabIndex = 2;
            this.btn_go.Text = "Process";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(4, 32);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(63, 23);
            this.btn_stop.TabIndex = 8;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_stop);
            this.panel1.Controls.Add(this.btn_go);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 428);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 60);
            this.panel1.TabIndex = 10;
            // 
            // ms_main
            // 
            this.ms_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_project,
            this.menu_polygons,
            this.menu_tools,
            this.aToolStripMenuItem});
            this.ms_main.Location = new System.Drawing.Point(0, 0);
            this.ms_main.Name = "ms_main";
            this.ms_main.Size = new System.Drawing.Size(708, 24);
            this.ms_main.TabIndex = 11;
            this.ms_main.Text = "ms_main";
            // 
            // menu_project
            // 
            this.menu_project.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menu_project.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_project_new,
            this.menu_project_load,
            this.toolStripMenuItem1,
            this.menu_project_save,
            this.menu_project_saveas,
            this.toolStripMenuItem2,
            this.menu_project_properties,
            this.toolStripSeparator1,
            this.menu_project_reseed,
            this.toolStripSeparator2,
            this.menu_project_close,
            this.menu_project_quit});
            this.menu_project.Name = "menu_project";
            this.menu_project.Size = new System.Drawing.Size(53, 20);
            this.menu_project.Text = "Project";
            // 
            // menu_project_new
            // 
            this.menu_project_new.Name = "menu_project_new";
            this.menu_project_new.Size = new System.Drawing.Size(148, 22);
            this.menu_project_new.Text = "New";
            this.menu_project_new.Click += new System.EventHandler(this.menu_project_new_Click);
            // 
            // menu_project_load
            // 
            this.menu_project_load.Name = "menu_project_load";
            this.menu_project_load.Size = new System.Drawing.Size(148, 22);
            this.menu_project_load.Text = "Load";
            this.menu_project_load.Click += new System.EventHandler(this.menu_project_load_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
            // 
            // menu_project_save
            // 
            this.menu_project_save.Name = "menu_project_save";
            this.menu_project_save.Size = new System.Drawing.Size(148, 22);
            this.menu_project_save.Text = "Save";
            this.menu_project_save.Click += new System.EventHandler(this.menu_project_save_Click);
            // 
            // menu_project_saveas
            // 
            this.menu_project_saveas.Name = "menu_project_saveas";
            this.menu_project_saveas.Size = new System.Drawing.Size(148, 22);
            this.menu_project_saveas.Text = "Save As";
            this.menu_project_saveas.Click += new System.EventHandler(this.menu_project_saveas_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(145, 6);
            // 
            // menu_project_properties
            // 
            this.menu_project_properties.Name = "menu_project_properties";
            this.menu_project_properties.Size = new System.Drawing.Size(148, 22);
            this.menu_project_properties.Text = "Properties";
            this.menu_project_properties.Click += new System.EventHandler(this.menu_project_properties_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // menu_project_reseed
            // 
            this.menu_project_reseed.Name = "menu_project_reseed";
            this.menu_project_reseed.Size = new System.Drawing.Size(148, 22);
            this.menu_project_reseed.Text = "Clear && Reseed";
            this.menu_project_reseed.Click += new System.EventHandler(this.menu_project_reseed_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // menu_project_close
            // 
            this.menu_project_close.Name = "menu_project_close";
            this.menu_project_close.Size = new System.Drawing.Size(148, 22);
            this.menu_project_close.Text = "Close";
            // 
            // menu_project_quit
            // 
            this.menu_project_quit.Name = "menu_project_quit";
            this.menu_project_quit.Size = new System.Drawing.Size(148, 22);
            this.menu_project_quit.Text = "Quit";
            this.menu_project_quit.Click += new System.EventHandler(this.menu_project_quit_Click);
            // 
            // menu_polygons
            // 
            this.menu_polygons.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_polygons_import,
            this.menu_polygons_export});
            this.menu_polygons.Name = "menu_polygons";
            this.menu_polygons.Size = new System.Drawing.Size(62, 20);
            this.menu_polygons.Text = "Polygons";
            // 
            // menu_polygons_import
            // 
            this.menu_polygons_import.Enabled = false;
            this.menu_polygons_import.Name = "menu_polygons_import";
            this.menu_polygons_import.Size = new System.Drawing.Size(152, 22);
            this.menu_polygons_import.Text = "Import";
            // 
            // menu_polygons_export
            // 
            this.menu_polygons_export.Name = "menu_polygons_export";
            this.menu_polygons_export.Size = new System.Drawing.Size(152, 22);
            this.menu_polygons_export.Text = "Export";
            this.menu_polygons_export.Click += new System.EventHandler(this.menu_polygons_export_Click);
            // 
            // menu_tools
            // 
            this.menu_tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enu_tools_grid,
            this.toolStripMenuItem3,
            this.menu_tools_preferences});
            this.menu_tools.Name = "menu_tools";
            this.menu_tools.Size = new System.Drawing.Size(44, 20);
            this.menu_tools.Text = "Tools";
            // 
            // enu_tools_grid
            // 
            this.enu_tools_grid.Enabled = false;
            this.enu_tools_grid.Name = "enu_tools_grid";
            this.enu_tools_grid.Size = new System.Drawing.Size(187, 22);
            this.enu_tools_grid.Text = "Grid Computing Options";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(184, 6);
            // 
            // menu_tools_preferences
            // 
            this.menu_tools_preferences.Name = "menu_tools_preferences";
            this.menu_tools_preferences.Size = new System.Drawing.Size(187, 22);
            this.menu_tools_preferences.Text = "Preferences";
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutGAVectorToolStripMenuItem});
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aToolStripMenuItem.Text = "About";
            // 
            // aboutGAVectorToolStripMenuItem
            // 
            this.aboutGAVectorToolStripMenuItem.Name = "aboutGAVectorToolStripMenuItem";
            this.aboutGAVectorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutGAVectorToolStripMenuItem.Text = "About GAVector";
            this.aboutGAVectorToolStripMenuItem.Click += new System.EventHandler(this.aboutGAVectorToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pb_source);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pb_image);
            this.splitContainer1.Size = new System.Drawing.Size(708, 404);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.TabIndex = 12;
            // 
            // pb_source
            // 
            this.pb_source.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_source.Location = new System.Drawing.Point(0, 0);
            this.pb_source.Name = "pb_source";
            this.pb_source.Size = new System.Drawing.Size(341, 400);
            this.pb_source.TabIndex = 6;
            this.pb_source.TabStop = false;
            // 
            // pb_image
            // 
            this.pb_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_image.Location = new System.Drawing.Point(0, 0);
            this.pb_image.Name = "pb_image";
            this.pb_image.Size = new System.Drawing.Size(355, 400);
            this.pb_image.TabIndex = 6;
            this.pb_image.TabStop = false;
            // 
            // sfd_save
            // 
            this.sfd_save.Filter = "GAVector Files (*.gav)|*.gav";
            // 
            // sfd_export
            // 
            this.sfd_export.Filter = "SVG File (*.svg)|*.svg|SFD XML File (*.sfd)|*.sfd|PDF File (*.pdf)|*.pdf";
            // 
            // ofd_open
            // 
            this.ofd_open.Filter = "GAVector Files (*.gav)|*.gav|All Files (*.*)|*.*";
            // 
            // ofd_openimage
            // 
            this.ofd_openimage.Filter = "All Image Files|*.jpg;*.jpeg;*.gif;*.png;*.bmp|JPEG Images (*.jpg,*.jpeg)|*.jpg;*" +
                ".jpeg|GIF Images (*.gif)|*.gif|PNG Images|*.png|All Files (*.*)|*.*";
            // 
            // fm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 488);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ms_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ms_main;
            this.Name = "fm_main";
            this.Text = "GAVector";
            this.Load += new System.EventHandler(this.fm_main_Load);
            this.Enter += new System.EventHandler(this.fm_main_Enter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fm_main_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ms_main.ResumeLayout(false);
            this.ms_main.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip ms_main;
        private System.Windows.Forms.ToolStripMenuItem menu_project;
        private System.Windows.Forms.ToolStripMenuItem menu_project_new;
        private System.Windows.Forms.ToolStripMenuItem menu_project_load;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menu_project_save;
        private System.Windows.Forms.ToolStripMenuItem menu_project_saveas;
        private System.Windows.Forms.ToolStripMenuItem menu_polygons;
        private System.Windows.Forms.ToolStripMenuItem menu_polygons_import;
        private System.Windows.Forms.ToolStripMenuItem menu_tools;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutGAVectorToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pb_source;
        private System.Windows.Forms.PictureBox pb_image;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menu_project_quit;
        private System.Windows.Forms.ToolStripMenuItem menu_project_properties;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menu_polygons_export;
        private System.Windows.Forms.ToolStripMenuItem enu_tools_grid;
        private System.Windows.Forms.SaveFileDialog sfd_save;
        private System.Windows.Forms.SaveFileDialog sfd_export;
        private System.Windows.Forms.OpenFileDialog ofd_open;
        private System.Windows.Forms.ToolStripMenuItem menu_project_close;
        private System.Windows.Forms.OpenFileDialog ofd_openimage;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menu_tools_preferences;
        private System.Windows.Forms.ToolStripMenuItem menu_project_reseed;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

