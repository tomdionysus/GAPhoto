namespace GAPhoto
{
    partial class fm_projectproperties
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
            this.gb_seed = new System.Windows.Forms.GroupBox();
            this.pnl_matrixseeding = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_matrix_granularity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_matrix_seed_blocks = new System.Windows.Forms.RadioButton();
            this.rb_matrix_seed_circles = new System.Windows.Forms.RadioButton();
            this.rb_matrixseed = new System.Windows.Forms.RadioButton();
            this.rb_randomseed = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_paths = new System.Windows.Forms.CheckBox();
            this.cb_points = new System.Windows.Forms.CheckBox();
            this.cb_curves = new System.Windows.Forms.CheckBox();
            this.cb_lines = new System.Windows.Forms.CheckBox();
            this.cb_limitpoints = new System.Windows.Forms.CheckBox();
            this.nud_pointlimit = new System.Windows.Forms.NumericUpDown();
            this.cb_limitpolygons = new System.Windows.Forms.CheckBox();
            this.nud_polylimit = new System.Windows.Forms.NumericUpDown();
            this.cb_bghistogram = new System.Windows.Forms.CheckBox();
            this.cb_filledcurves = new System.Windows.Forms.CheckBox();
            this.cb_filledpolygons = new System.Windows.Forms.CheckBox();
            this.tt_bgcolhistogram = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbx_additionalshapes = new System.Windows.Forms.CheckBox();
            this.cbx_shaperemoval = new System.Windows.Forms.CheckBox();
            this.cbx_shapesplit = new System.Windows.Forms.CheckBox();
            this.cbx_shapemerging = new System.Windows.Forms.CheckBox();
            this.cbx_allowpointswapping = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nud_threadlimit = new System.Windows.Forms.NumericUpDown();
            this.nud_colourmovement = new System.Windows.Forms.NumericUpDown();
            this.nud_pointmovement = new System.Windows.Forms.NumericUpDown();
            this.nud_pointchanges = new System.Windows.Forms.NumericUpDown();
            this.nud_polychanges = new System.Windows.Forms.NumericUpDown();
            this.btn_ok = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gb_seed.SuspendLayout();
            this.pnl_matrixseeding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_matrix_granularity)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pointlimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_polylimit)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_threadlimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_colourmovement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pointmovement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pointchanges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_polychanges)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_seed
            // 
            this.gb_seed.Controls.Add(this.pnl_matrixseeding);
            this.gb_seed.Controls.Add(this.rb_matrixseed);
            this.gb_seed.Controls.Add(this.rb_randomseed);
            this.gb_seed.Location = new System.Drawing.Point(18, 18);
            this.gb_seed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_seed.Name = "gb_seed";
            this.gb_seed.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gb_seed.Size = new System.Drawing.Size(300, 289);
            this.gb_seed.TabIndex = 0;
            this.gb_seed.TabStop = false;
            this.gb_seed.Text = "Seeding";
            // 
            // pnl_matrixseeding
            // 
            this.pnl_matrixseeding.Controls.Add(this.label2);
            this.pnl_matrixseeding.Controls.Add(this.nud_matrix_granularity);
            this.pnl_matrixseeding.Controls.Add(this.label1);
            this.pnl_matrixseeding.Controls.Add(this.rb_matrix_seed_blocks);
            this.pnl_matrixseeding.Controls.Add(this.rb_matrix_seed_circles);
            this.pnl_matrixseeding.Location = new System.Drawing.Point(9, 100);
            this.pnl_matrixseeding.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl_matrixseeding.Name = "pnl_matrixseeding";
            this.pnl_matrixseeding.Size = new System.Drawing.Size(282, 115);
            this.pnl_matrixseeding.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Pixels";
            // 
            // nud_matrix_granularity
            // 
            this.nud_matrix_granularity.Location = new System.Drawing.Point(140, 74);
            this.nud_matrix_granularity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nud_matrix_granularity.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_matrix_granularity.Name = "nud_matrix_granularity";
            this.nud_matrix_granularity.Size = new System.Drawing.Size(58, 26);
            this.nud_matrix_granularity.TabIndex = 10;
            this.nud_matrix_granularity.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Granularty";
            this.tt_bgcolhistogram.SetToolTip(this.label1, "The distance between circles and blocks when seeding");
            // 
            // rb_matrix_seed_blocks
            // 
            this.rb_matrix_seed_blocks.AutoSize = true;
            this.rb_matrix_seed_blocks.Location = new System.Drawing.Point(50, 40);
            this.rb_matrix_seed_blocks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_matrix_seed_blocks.Name = "rb_matrix_seed_blocks";
            this.rb_matrix_seed_blocks.Size = new System.Drawing.Size(81, 24);
            this.rb_matrix_seed_blocks.TabIndex = 8;
            this.rb_matrix_seed_blocks.TabStop = true;
            this.rb_matrix_seed_blocks.Text = "Blocks";
            this.tt_bgcolhistogram.SetToolTip(this.rb_matrix_seed_blocks, "Seed with square blocks placed at intervals");
            this.rb_matrix_seed_blocks.UseVisualStyleBackColor = true;
            // 
            // rb_matrix_seed_circles
            // 
            this.rb_matrix_seed_circles.AutoSize = true;
            this.rb_matrix_seed_circles.Location = new System.Drawing.Point(50, 5);
            this.rb_matrix_seed_circles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_matrix_seed_circles.Name = "rb_matrix_seed_circles";
            this.rb_matrix_seed_circles.Size = new System.Drawing.Size(81, 24);
            this.rb_matrix_seed_circles.TabIndex = 7;
            this.rb_matrix_seed_circles.TabStop = true;
            this.rb_matrix_seed_circles.Text = "Circles";
            this.tt_bgcolhistogram.SetToolTip(this.rb_matrix_seed_circles, "Seed with Circles spaced at intervals");
            this.rb_matrix_seed_circles.UseVisualStyleBackColor = true;
            // 
            // rb_matrixseed
            // 
            this.rb_matrixseed.AutoSize = true;
            this.rb_matrixseed.Location = new System.Drawing.Point(9, 65);
            this.rb_matrixseed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_matrixseed.Name = "rb_matrixseed";
            this.rb_matrixseed.Size = new System.Drawing.Size(172, 24);
            this.rb_matrixseed.TabIndex = 1;
            this.rb_matrixseed.TabStop = true;
            this.rb_matrixseed.Text = "Use Matrix Seeding";
            this.tt_bgcolhistogram.SetToolTip(this.rb_matrixseed, "Begin with a set of polygons derived from a sample of the image (Good for Complex" +
        " Shapes and sets of shapes)");
            this.rb_matrixseed.UseVisualStyleBackColor = true;
            this.rb_matrixseed.Click += new System.EventHandler(this.rb_matrixseed_Click);
            // 
            // rb_randomseed
            // 
            this.rb_randomseed.AutoSize = true;
            this.rb_randomseed.Location = new System.Drawing.Point(9, 29);
            this.rb_randomseed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rb_randomseed.Name = "rb_randomseed";
            this.rb_randomseed.Size = new System.Drawing.Size(137, 24);
            this.rb_randomseed.TabIndex = 0;
            this.rb_randomseed.TabStop = true;
            this.rb_randomseed.Text = "Random Seed";
            this.tt_bgcolhistogram.SetToolTip(this.rb_randomseed, "Begin with a blank canvas and a single ThreadSafeRandom polygon (Useful for colle" +
        "ctions of simple shapes)");
            this.rb_randomseed.UseVisualStyleBackColor = true;
            this.rb_randomseed.Click += new System.EventHandler(this.rb_randomseed_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_paths);
            this.groupBox1.Controls.Add(this.cb_points);
            this.groupBox1.Controls.Add(this.cb_curves);
            this.groupBox1.Controls.Add(this.cb_lines);
            this.groupBox1.Controls.Add(this.cb_limitpoints);
            this.groupBox1.Controls.Add(this.nud_pointlimit);
            this.groupBox1.Controls.Add(this.cb_limitpolygons);
            this.groupBox1.Controls.Add(this.nud_polylimit);
            this.groupBox1.Controls.Add(this.cb_bghistogram);
            this.groupBox1.Controls.Add(this.cb_filledcurves);
            this.groupBox1.Controls.Add(this.cb_filledpolygons);
            this.groupBox1.Location = new System.Drawing.Point(327, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(420, 289);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Polygons && Curves";
            // 
            // cb_paths
            // 
            this.cb_paths.AutoSize = true;
            this.cb_paths.Location = new System.Drawing.Point(9, 135);
            this.cb_paths.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_paths.Name = "cb_paths";
            this.cb_paths.Size = new System.Drawing.Size(174, 24);
            this.cb_paths.TabIndex = 19;
            this.cb_paths.Text = "Use Complex Paths";
            this.tt_bgcolhistogram.SetToolTip(this.cb_paths, "Use complex paths to describe sections of the image. Complex paths are\r\nfilled sh" +
        "apes consisting of straight and curved sections that may contain holes.");
            this.cb_paths.UseVisualStyleBackColor = true;
            // 
            // cb_points
            // 
            this.cb_points.AutoSize = true;
            this.cb_points.Location = new System.Drawing.Point(9, 29);
            this.cb_points.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_points.Name = "cb_points";
            this.cb_points.Size = new System.Drawing.Size(112, 24);
            this.cb_points.TabIndex = 18;
            this.cb_points.Text = "Use Points";
            this.tt_bgcolhistogram.SetToolTip(this.cb_points, "Use points and circles to describe sections of the image.");
            this.cb_points.UseVisualStyleBackColor = true;
            // 
            // cb_curves
            // 
            this.cb_curves.AutoSize = true;
            this.cb_curves.Location = new System.Drawing.Point(225, 63);
            this.cb_curves.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_curves.Name = "cb_curves";
            this.cb_curves.Size = new System.Drawing.Size(117, 24);
            this.cb_curves.TabIndex = 17;
            this.cb_curves.Text = "Use Curves";
            this.tt_bgcolhistogram.SetToolTip(this.cb_curves, "Use curved lines to describe sections of the image.");
            this.cb_curves.UseVisualStyleBackColor = true;
            // 
            // cb_lines
            // 
            this.cb_lines.AutoSize = true;
            this.cb_lines.Location = new System.Drawing.Point(9, 65);
            this.cb_lines.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_lines.Name = "cb_lines";
            this.cb_lines.Size = new System.Drawing.Size(106, 24);
            this.cb_lines.TabIndex = 16;
            this.cb_lines.Text = "Use Lines";
            this.tt_bgcolhistogram.SetToolTip(this.cb_lines, "Use straight lines to describe sections of the image.");
            this.cb_lines.UseVisualStyleBackColor = true;
            this.cb_lines.CheckedChanged += new System.EventHandler(this.cb_lines_CheckedChanged);
            // 
            // cb_limitpoints
            // 
            this.cb_limitpoints.AutoSize = true;
            this.cb_limitpoints.Location = new System.Drawing.Point(9, 242);
            this.cb_limitpoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_limitpoints.Name = "cb_limitpoints";
            this.cb_limitpoints.Size = new System.Drawing.Size(162, 24);
            this.cb_limitpoints.TabIndex = 15;
            this.cb_limitpoints.Text = "Limit No. of Points";
            this.tt_bgcolhistogram.SetToolTip(this.cb_limitpoints, "Limit the number of points in each polygon");
            this.cb_limitpoints.UseVisualStyleBackColor = true;
            // 
            // nud_pointlimit
            // 
            this.nud_pointlimit.Location = new System.Drawing.Point(225, 240);
            this.nud_pointlimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nud_pointlimit.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nud_pointlimit.Name = "nud_pointlimit";
            this.nud_pointlimit.Size = new System.Drawing.Size(88, 26);
            this.nud_pointlimit.TabIndex = 14;
            this.nud_pointlimit.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // cb_limitpolygons
            // 
            this.cb_limitpolygons.AutoSize = true;
            this.cb_limitpolygons.Location = new System.Drawing.Point(9, 206);
            this.cb_limitpolygons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_limitpolygons.Name = "cb_limitpolygons";
            this.cb_limitpolygons.Size = new System.Drawing.Size(182, 24);
            this.cb_limitpolygons.TabIndex = 13;
            this.cb_limitpolygons.Text = "Limit No. of Polygons";
            this.tt_bgcolhistogram.SetToolTip(this.cb_limitpolygons, "Limit the number of polygons used to describe the image");
            this.cb_limitpolygons.UseVisualStyleBackColor = true;
            // 
            // nud_polylimit
            // 
            this.nud_polylimit.Location = new System.Drawing.Point(225, 205);
            this.nud_polylimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nud_polylimit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_polylimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_polylimit.Name = "nud_polylimit";
            this.nud_polylimit.Size = new System.Drawing.Size(88, 26);
            this.nud_polylimit.TabIndex = 12;
            this.nud_polylimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cb_bghistogram
            // 
            this.cb_bghistogram.AutoSize = true;
            this.cb_bghistogram.Location = new System.Drawing.Point(9, 171);
            this.cb_bghistogram.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_bghistogram.Name = "cb_bghistogram";
            this.cb_bghistogram.Size = new System.Drawing.Size(280, 24);
            this.cb_bghistogram.TabIndex = 2;
            this.cb_bghistogram.Text = "Background Color From Histogram";
            this.tt_bgcolhistogram.SetToolTip(this.cb_bghistogram, "Compute the background colour from a histogram of the original image. \r\nThe most " +
        "common colour in the image will be used as the background.\r\nIf this is unset, th" +
        "e background will be white.");
            this.cb_bghistogram.UseVisualStyleBackColor = true;
            // 
            // cb_filledcurves
            // 
            this.cb_filledcurves.AutoSize = true;
            this.cb_filledcurves.Location = new System.Drawing.Point(225, 98);
            this.cb_filledcurves.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_filledcurves.Name = "cb_filledcurves";
            this.cb_filledcurves.Size = new System.Drawing.Size(184, 24);
            this.cb_filledcurves.TabIndex = 1;
            this.cb_filledcurves.Text = "Use Filled Polycurves";
            this.tt_bgcolhistogram.SetToolTip(this.cb_filledcurves, "Use polycurves to describe sections of the image.\r\n");
            this.cb_filledcurves.UseVisualStyleBackColor = true;
            this.cb_filledcurves.CheckedChanged += new System.EventHandler(this.cb_curves_CheckedChanged);
            // 
            // cb_filledpolygons
            // 
            this.cb_filledpolygons.AutoSize = true;
            this.cb_filledpolygons.Location = new System.Drawing.Point(9, 100);
            this.cb_filledpolygons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_filledpolygons.Name = "cb_filledpolygons";
            this.cb_filledpolygons.Size = new System.Drawing.Size(173, 24);
            this.cb_filledpolygons.TabIndex = 0;
            this.cb_filledpolygons.Text = "Use Filled Polygons";
            this.tt_bgcolhistogram.SetToolTip(this.cb_filledpolygons, "Use straight lines to describe sections of the image.");
            this.cb_filledpolygons.UseVisualStyleBackColor = true;
            this.cb_filledpolygons.CheckedChanged += new System.EventHandler(this.cb_polygons_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Max Polygon Changes";
            this.tt_bgcolhistogram.SetToolTip(this.label3, "The maximum number of polygons to change in each generation.\r\nHigher numbers are " +
        "equivalent to higher levels of mutation.");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Max Point Changes";
            this.tt_bgcolhistogram.SetToolTip(this.label4, "The maximum number of points in each polygon to change in each generation.\r\nHighe" +
        "r numbers are equivalent to higher levels of mutation.");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Max Point Movement";
            this.tt_bgcolhistogram.SetToolTip(this.label5, "The maximum number of pixels a PointF can move in either x or y during a mutation" +
        ".\r\n");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 151);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Max Colour Movement";
            this.tt_bgcolhistogram.SetToolTip(this.label6, "The maximum change in a R G or B color value during a mutation.\r\n");
            // 
            // cbx_additionalshapes
            // 
            this.cbx_additionalshapes.AutoSize = true;
            this.cbx_additionalshapes.Location = new System.Drawing.Point(318, 29);
            this.cbx_additionalshapes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_additionalshapes.Name = "cbx_additionalshapes";
            this.cbx_additionalshapes.Size = new System.Drawing.Size(205, 24);
            this.cbx_additionalshapes.TabIndex = 20;
            this.cbx_additionalshapes.Text = "Allow Additional Shapes";
            this.tt_bgcolhistogram.SetToolTip(this.cbx_additionalshapes, "If checked, allows the environment to add new shapes during mutation");
            this.cbx_additionalshapes.UseVisualStyleBackColor = true;
            // 
            // cbx_shaperemoval
            // 
            this.cbx_shaperemoval.AutoSize = true;
            this.cbx_shaperemoval.Location = new System.Drawing.Point(318, 69);
            this.cbx_shaperemoval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_shaperemoval.Name = "cbx_shaperemoval";
            this.cbx_shaperemoval.Size = new System.Drawing.Size(189, 24);
            this.cbx_shaperemoval.TabIndex = 21;
            this.cbx_shaperemoval.Text = "Allow Shape Removal";
            this.tt_bgcolhistogram.SetToolTip(this.cbx_shaperemoval, "If checked, allows the environment to remove shapes during mutation");
            this.cbx_shaperemoval.UseVisualStyleBackColor = true;
            // 
            // cbx_shapesplit
            // 
            this.cbx_shapesplit.AutoSize = true;
            this.cbx_shapesplit.Location = new System.Drawing.Point(318, 149);
            this.cbx_shapesplit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_shapesplit.Name = "cbx_shapesplit";
            this.cbx_shapesplit.Size = new System.Drawing.Size(184, 24);
            this.cbx_shapesplit.TabIndex = 22;
            this.cbx_shapesplit.Text = "Allow Shape Splitting";
            this.tt_bgcolhistogram.SetToolTip(this.cbx_shapesplit, "If checked, allows the environment to split shapes during a mutation");
            this.cbx_shapesplit.UseVisualStyleBackColor = true;
            // 
            // cbx_shapemerging
            // 
            this.cbx_shapemerging.AutoSize = true;
            this.cbx_shapemerging.Location = new System.Drawing.Point(318, 191);
            this.cbx_shapemerging.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_shapemerging.Name = "cbx_shapemerging";
            this.cbx_shapemerging.Size = new System.Drawing.Size(184, 24);
            this.cbx_shapemerging.TabIndex = 23;
            this.cbx_shapemerging.Text = "Allow Shape Merging";
            this.tt_bgcolhistogram.SetToolTip(this.cbx_shapemerging, "If checked, allows the environment to merge shapes during a mutation");
            this.cbx_shapemerging.UseVisualStyleBackColor = true;
            this.cbx_shapemerging.Enter += new System.EventHandler(this.cbx_shapemerging_Enter);
            // 
            // cbx_allowpointswapping
            // 
            this.cbx_allowpointswapping.AutoSize = true;
            this.cbx_allowpointswapping.Location = new System.Drawing.Point(318, 109);
            this.cbx_allowpointswapping.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_allowpointswapping.Name = "cbx_allowpointswapping";
            this.cbx_allowpointswapping.Size = new System.Drawing.Size(186, 24);
            this.cbx_allowpointswapping.TabIndex = 24;
            this.cbx_allowpointswapping.Text = "Allow Point Swapping";
            this.tt_bgcolhistogram.SetToolTip(this.cbx_allowpointswapping, "If checked, allows the environment to swap points in a shape \r\nduring a mutation");
            this.cbx_allowpointswapping.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 234);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Max Threads";
            this.tt_bgcolhistogram.SetToolTip(this.label7, "The maximum change in a R G or B color value during a mutation.\r\n");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nud_threadlimit);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbx_allowpointswapping);
            this.groupBox2.Controls.Add(this.cbx_shapemerging);
            this.groupBox2.Controls.Add(this.cbx_shapesplit);
            this.groupBox2.Controls.Add(this.cbx_shaperemoval);
            this.groupBox2.Controls.Add(this.cbx_additionalshapes);
            this.groupBox2.Controls.Add(this.nud_colourmovement);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nud_pointmovement);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.nud_pointchanges);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nud_polychanges);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(18, 317);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(729, 275);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mutation Settings";
            // 
            // nud_threadlimit
            // 
            this.nud_threadlimit.Hexadecimal = true;
            this.nud_threadlimit.Location = new System.Drawing.Point(188, 231);
            this.nud_threadlimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nud_threadlimit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_threadlimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_threadlimit.Name = "nud_threadlimit";
            this.nud_threadlimit.Size = new System.Drawing.Size(88, 26);
            this.nud_threadlimit.TabIndex = 26;
            this.nud_threadlimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_colourmovement
            // 
            this.nud_colourmovement.Hexadecimal = true;
            this.nud_colourmovement.Location = new System.Drawing.Point(188, 146);
            this.nud_colourmovement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nud_colourmovement.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_colourmovement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_colourmovement.Name = "nud_colourmovement";
            this.nud_colourmovement.Size = new System.Drawing.Size(88, 26);
            this.nud_colourmovement.TabIndex = 19;
            this.nud_colourmovement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_pointmovement
            // 
            this.nud_pointmovement.Location = new System.Drawing.Point(188, 106);
            this.nud_pointmovement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nud_pointmovement.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_pointmovement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_pointmovement.Name = "nud_pointmovement";
            this.nud_pointmovement.Size = new System.Drawing.Size(88, 26);
            this.nud_pointmovement.TabIndex = 17;
            this.nud_pointmovement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_pointchanges
            // 
            this.nud_pointchanges.Location = new System.Drawing.Point(188, 66);
            this.nud_pointchanges.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nud_pointchanges.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_pointchanges.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_pointchanges.Name = "nud_pointchanges";
            this.nud_pointchanges.Size = new System.Drawing.Size(88, 26);
            this.nud_pointchanges.TabIndex = 15;
            this.nud_pointchanges.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_polychanges
            // 
            this.nud_polychanges.Location = new System.Drawing.Point(188, 26);
            this.nud_polychanges.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nud_polychanges.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_polychanges.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_polychanges.Name = "nud_polychanges";
            this.nud_polychanges.Size = new System.Drawing.Size(88, 26);
            this.nud_polychanges.TabIndex = 13;
            this.nud_polychanges.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(634, 602);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(112, 35);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(513, 602);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fm_projectproperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 648);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_seed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fm_projectproperties";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Project Properties";
            this.gb_seed.ResumeLayout(false);
            this.gb_seed.PerformLayout();
            this.pnl_matrixseeding.ResumeLayout(false);
            this.pnl_matrixseeding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_matrix_granularity)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pointlimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_polylimit)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_threadlimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_colourmovement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pointmovement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pointchanges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_polychanges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_seed;
        private System.Windows.Forms.RadioButton rb_matrixseed;
        private System.Windows.Forms.RadioButton rb_randomseed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_bghistogram;
        private System.Windows.Forms.CheckBox cb_filledcurves;
        private System.Windows.Forms.CheckBox cb_filledpolygons;
        private System.Windows.Forms.Panel pnl_matrixseeding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_matrix_granularity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_matrix_seed_blocks;
        private System.Windows.Forms.RadioButton rb_matrix_seed_circles;
        private System.Windows.Forms.ToolTip tt_bgcolhistogram;
        private System.Windows.Forms.CheckBox cb_limitpoints;
        private System.Windows.Forms.NumericUpDown nud_pointlimit;
        private System.Windows.Forms.CheckBox cb_limitpolygons;
        private System.Windows.Forms.NumericUpDown nud_polylimit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nud_pointchanges;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_polychanges;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nud_pointmovement;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nud_colourmovement;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbx_shaperemoval;
        private System.Windows.Forms.CheckBox cbx_additionalshapes;
        private System.Windows.Forms.CheckBox cbx_shapemerging;
        private System.Windows.Forms.CheckBox cbx_shapesplit;
        private System.Windows.Forms.CheckBox cbx_allowpointswapping;
        private System.Windows.Forms.CheckBox cb_lines;
        private System.Windows.Forms.CheckBox cb_curves;
        private System.Windows.Forms.CheckBox cb_points;
        private System.Windows.Forms.CheckBox cb_paths;
        private System.Windows.Forms.NumericUpDown nud_threadlimit;
        private System.Windows.Forms.Label label7;
    }
}