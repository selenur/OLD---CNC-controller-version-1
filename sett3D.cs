using System;
using System.Windows.Forms;

namespace CNC_Assist
{
    public partial class Sett3D : Form
    {
        public Sett3D()
        {
            InitializeComponent();
        }

        private void sett3D_Load(object sender, EventArgs e)
        {
            ShowCursor.Checked = GlobalSetting.RenderSetting.ShowCursor;
            ShowAxes.Checked = GlobalSetting.RenderSetting.ShowAxes;
            ShowScanedGrid.Checked = GlobalSetting.RenderSetting.ShowScanedGrid;


            ShowGrid.Checked = GlobalSetting.RenderSetting.ShowGrid;
            numericUpDown1.Value = GlobalSetting.RenderSetting.GridSize;
            numericUpDown2.Value = GlobalSetting.RenderSetting.GridStartX;
            numericUpDown3.Value = GlobalSetting.RenderSetting.GridSizeX;
            numericUpDown4.Value = GlobalSetting.RenderSetting.GridStartY;
            numericUpDown5.Value = GlobalSetting.RenderSetting.GridSizeY;

            checkBoxShowGrate.Checked = GlobalSetting.RenderSetting.ShowWorkArea;
            //ShowCursor.Checked = mf.PreviewSetting.ShowInstrument;
            //checkBox2.Checked = mf.PreviewSetting.ShowGrid;
            //ShowScanedGrid.Checked = mf.PreviewSetting.ShowMatrix;
            //ShowAxes.Checked = mf.PreviewSetting.ShowAxes;

            ////checkBoxShowGrate.Checked = mf.ShowGrate;
            ////numPosXmin.Value = (decimal)mf.GrateXmin;
            ////numPosXmax.Value = (decimal)mf.GrateXmax;
            ////numPosYmin.Value = (decimal)mf.GrateYmin;
            ////numPosYmax.Value = (decimal)mf.GrateYmax;

             numPosXmin.Value = (decimal)GlobalSetting.ControllerSetting.WorkSizeXm;
             numPosXmax.Value = (decimal)GlobalSetting.ControllerSetting.WorkSizeXp;
             numPosYmin.Value = (decimal)GlobalSetting.ControllerSetting.WorkSizeYm;
             numPosYmax.Value = (decimal)GlobalSetting.ControllerSetting.WorkSizeYp;

        }

        private void ShowCursor_CheckedChanged(object sender, EventArgs e)
        {
            GlobalSetting.RenderSetting.ShowCursor = ShowCursor.Checked;
            GlobalSetting.SaveToFile();
        }

        private void ShowAxes_CheckedChanged(object sender, EventArgs e)
        {
            GlobalSetting.RenderSetting.ShowAxes = ShowAxes.Checked;
            GlobalSetting.SaveToFile();
        }

        private void ShowScanedGrid_CheckedChanged(object sender, EventArgs e)
        {
            GlobalSetting.RenderSetting.ShowScanedGrid = ShowScanedGrid.Checked;
            GlobalSetting.SaveToFile();
        }

        private void ShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            GlobalSetting.RenderSetting.ShowGrid = ShowGrid.Checked;
            GlobalSetting.SaveToFile();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GlobalSetting.RenderSetting.GridSize = (int)numericUpDown1.Value;
            GlobalSetting.SaveToFile();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            GlobalSetting.RenderSetting.GridStartX = (int)numericUpDown2.Value;
            GlobalSetting.SaveToFile();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            GlobalSetting.RenderSetting.GridSizeX = (int)numericUpDown3.Value;
            GlobalSetting.SaveToFile();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            GlobalSetting.RenderSetting.GridStartY = (int)numericUpDown4.Value;
            GlobalSetting.SaveToFile();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            GlobalSetting.RenderSetting.GridSizeY = (int)numericUpDown5.Value;
            GlobalSetting.SaveToFile();
        }

        private void checkBoxShowGrate_CheckedChanged(object sender, EventArgs e)
        {
            GlobalSetting.RenderSetting.ShowWorkArea = checkBoxShowGrate.Checked;
            GlobalSetting.SaveToFile();
        }

        private void numPosXmin_ValueChanged(object sender, EventArgs e)
        {
            GlobalSetting.ControllerSetting.WorkSizeXm = (float)numPosXmin.Value;
            GlobalSetting.SaveToFile();
        }

        private void numPosXmax_ValueChanged(object sender, EventArgs e)
        {
            GlobalSetting.ControllerSetting.WorkSizeXp = (float)numPosXmax.Value;
            GlobalSetting.SaveToFile();
        }

        private void numPosYmin_ValueChanged(object sender, EventArgs e)
        {
            GlobalSetting.ControllerSetting.WorkSizeYm = (float)numPosYmin.Value;
            GlobalSetting.SaveToFile();
        }

        private void numPosYmax_ValueChanged(object sender, EventArgs e)
        {
            GlobalSetting.ControllerSetting.WorkSizeYp = (float)numPosYmax.Value;
            GlobalSetting.SaveToFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            GlobalSetting.ControllerSetting.WorkSizeXm = 0;
            GlobalSetting.ControllerSetting.WorkSizeYm = 0;
            GlobalSetting.ControllerSetting.WorkSizeXp = 0;
            GlobalSetting.ControllerSetting.WorkSizeYp = 0;
            GlobalSetting.SaveToFile();
        }
    }
}