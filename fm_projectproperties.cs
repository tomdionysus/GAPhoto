using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GAPhoto
{
    public partial class fm_projectproperties : Form
    {
        public fm_projectproperties()
        {
            InitializeComponent();
        }

        public void LoadProperties(GAProjectProperties prop)
        {
            rb_randomseed.Checked = (prop.Seeding == GASeeding.RandomSeed);
            rb_matrixseed.Checked = (prop.Seeding == GASeeding.MatrixSeed);

            rb_matrix_seed_circles.Checked = (prop.MatrixSeedingType == GAMatrixSeedingType.Circles);
            rb_matrix_seed_blocks.Checked = (prop.MatrixSeedingType == GAMatrixSeedingType.Blocks);

            nud_matrix_granularity.Value = prop.Granularity;

            cb_points.Checked = prop.UsePoints;
            cb_lines.Checked = prop.UseLines;
            cb_curves.Checked = prop.UseCurves;
            cb_filledpolygons.Checked = prop.UseFilledPolygons;
            cb_filledcurves.Checked = prop.UseFilledPolycurves;
            cb_paths.Checked = prop.UsePaths;
            cb_bghistogram.Checked = prop.BackgroundColorFromHistogram;
            cb_limitpolygons.Checked = prop.LimitPolygons;
            nud_polylimit.Value = prop.PolygonLimit;
            cb_limitpoints.Checked = prop.LimitPoints;
            nud_pointlimit.Value = prop.PointLimit;

            nud_threadlimit.Value = prop.ThreadLimit;

            nud_polychanges.Value = prop.MaxPolygonChanges;
            nud_pointchanges.Value = prop.MaxPointChanges;
            nud_pointmovement.Value = prop.MaxPointMovement;
            nud_colourmovement.Value = prop.MaxColorMovement;

            cbx_additionalshapes.Checked = prop.AllowAdditionalShapes;
            cbx_shaperemoval.Checked = prop.AllowShapeRemoval;
            cbx_allowpointswapping.Checked = prop.AllowPointSwapping;
            cbx_shapesplit.Checked = prop.AllowShapeSplitting;
            cbx_shapemerging.Checked = prop.AllowShapeMerging;

            CheckMatrixSeedingPanel();
        }
        public GAProjectProperties GetProperties()
        {
            GAProjectProperties prop = new GAProjectProperties();

            if (rb_randomseed.Checked) prop.Seeding = GASeeding.RandomSeed;
            if (rb_matrixseed.Checked) prop.Seeding = GASeeding.MatrixSeed;

            if (rb_matrix_seed_circles.Checked) prop.MatrixSeedingType = GAMatrixSeedingType.Circles;
            if (rb_matrix_seed_blocks.Checked) prop.MatrixSeedingType = GAMatrixSeedingType.Blocks;

            prop.Granularity = (int)nud_matrix_granularity.Value;

            prop.UsePoints = cb_points.Checked;
            prop.UseLines = cb_lines.Checked;
            prop.UseCurves = cb_curves.Checked;
            prop.UseFilledPolygons = cb_filledpolygons.Checked;
            prop.UseFilledPolycurves = cb_filledcurves.Checked;
            prop.UsePaths = cb_paths.Checked;
            prop.BackgroundColorFromHistogram = cb_bghistogram.Checked;
            prop.LimitPolygons = cb_limitpolygons.Checked;
            prop.PolygonLimit = (int)nud_polylimit.Value;
            prop.LimitPoints = cb_limitpoints.Checked;
            prop.PointLimit = (int)nud_pointlimit.Value;

            prop.ThreadLimit = (Int16)nud_threadlimit.Value;

            prop.MaxPolygonChanges = (int)nud_polychanges.Value;
            prop.MaxPointChanges = (int)nud_pointchanges.Value;
            prop.MaxPointMovement = (int)nud_pointmovement.Value;
            prop.MaxColorMovement = (int)nud_colourmovement.Value;

            prop.AllowAdditionalShapes = cbx_additionalshapes.Checked;
            prop.AllowShapeRemoval = cbx_shaperemoval.Checked;
            prop.AllowPointSwapping = cbx_allowpointswapping.Checked;
            prop.AllowShapeMerging = cbx_shapemerging.Checked;
            prop.AllowShapeSplitting = cbx_shapesplit.Checked;

            return prop;
        }

        private void rb_matrixseed_Click(object sender, EventArgs e)
        {
            CheckMatrixSeedingPanel();
        }
        private void rb_randomseed_Click(object sender, EventArgs e)
        {
            CheckMatrixSeedingPanel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cb_polygons_CheckedChanged(object sender, EventArgs e)
        {
            EnsureOneType();
        }

        private void EnsureOneType()
        {
            // Ensure at least one of the possible object types is checked
            if (!cb_points.Checked &&
                 !cb_lines.Checked &&
                 !cb_filledpolygons.Checked &&
                 !cb_filledcurves.Checked &&
                 !cb_paths.Checked
               )
            {
                cb_points.Checked = true;
            }
        }
        private void cb_curves_CheckedChanged(object sender, EventArgs e)
        {
            EnsureOneType();
        }

        private void cbx_shapemerging_Enter(object sender, EventArgs e)
        {
            CheckMatrixSeedingPanel();
        }

        private void CheckMatrixSeedingPanel()
        {
            pnl_matrixseeding.Enabled = rb_matrixseed.Checked;
            // Enable/Disable the Matrix Panel
        }

        private void cb_lines_CheckedChanged(object sender, EventArgs e)
        {
            EnsureOneType();
        }


    }
}