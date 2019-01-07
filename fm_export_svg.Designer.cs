namespace GAPhoto
{
    partial class fm_export_svg
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_sizex = new System.Windows.Forms.TextBox();
            this.cb_units = new System.Windows.Forms.ComboBox();
            this.tb_sizey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_scale = new System.Windows.Forms.TextBox();
            this.bt_export = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.cb_gzip = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Output Size";
            // 
            // tb_sizex
            // 
            this.tb_sizex.Location = new System.Drawing.Point(80, 9);
            this.tb_sizex.Name = "tb_sizex";
            this.tb_sizex.Size = new System.Drawing.Size(51, 20);
            this.tb_sizex.TabIndex = 1;
            // 
            // cb_units
            // 
            this.cb_units.FormattingEnabled = true;
            this.cb_units.Items.AddRange(new object[] {
            "px",
            "cm",
            "mm",
            "em",
            "point"});
            this.cb_units.Location = new System.Drawing.Point(137, 8);
            this.cb_units.Name = "cb_units";
            this.cb_units.Size = new System.Drawing.Size(71, 21);
            this.cb_units.TabIndex = 2;
            this.cb_units.Text = "px";
            // 
            // tb_sizey
            // 
            this.tb_sizey.Location = new System.Drawing.Point(80, 35);
            this.tb_sizey.Name = "tb_sizey";
            this.tb_sizey.Size = new System.Drawing.Size(51, 20);
            this.tb_sizey.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Scaling";
            // 
            // tb_scale
            // 
            this.tb_scale.Location = new System.Drawing.Point(80, 75);
            this.tb_scale.Name = "tb_scale";
            this.tb_scale.Size = new System.Drawing.Size(51, 20);
            this.tb_scale.TabIndex = 5;
            this.tb_scale.Text = "100%";
            // 
            // bt_export
            // 
            this.bt_export.Location = new System.Drawing.Point(133, 124);
            this.bt_export.Name = "bt_export";
            this.bt_export.Size = new System.Drawing.Size(75, 23);
            this.bt_export.TabIndex = 6;
            this.bt_export.Text = "Export";
            this.bt_export.UseVisualStyleBackColor = true;
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(52, 124);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 7;
            this.bt_cancel.Text = "Cancel";
            this.bt_cancel.UseVisualStyleBackColor = true;
            // 
            // cb_gzip
            // 
            this.cb_gzip.AutoSize = true;
            this.cb_gzip.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cb_gzip.Location = new System.Drawing.Point(12, 101);
            this.cb_gzip.Name = "cb_gzip";
            this.cb_gzip.Size = new System.Drawing.Size(150, 17);
            this.cb_gzip.TabIndex = 8;
            this.cb_gzip.Text = "GZip Compression (SVGZ)";
            this.cb_gzip.UseVisualStyleBackColor = true;
            // 
            // fm_export_svg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 157);
            this.Controls.Add(this.cb_gzip);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_export);
            this.Controls.Add(this.tb_scale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_sizey);
            this.Controls.Add(this.cb_units);
            this.Controls.Add(this.tb_sizex);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "fm_export_svg";
            this.Text = "Export to SVG";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_sizex;
        private System.Windows.Forms.ComboBox cb_units;
        private System.Windows.Forms.TextBox tb_sizey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_scale;
        private System.Windows.Forms.Button bt_export;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.CheckBox cb_gzip;
    }
}