using System;
using System.Windows.Forms;

namespace CNC_Assist
{
    public partial class GUI_panel_3DView : UserControl
    {
        public GUI_panel_3DView()
        {
            InitializeComponent();
        }

        private void GUI_panel_3DView_Load(object sender, EventArgs e)
        {

            checkBoxShowAxes.Checked = GlobalSetting.RenderSetting.ShowAxes;
            checkBoxShowCursor.Checked = GlobalSetting.RenderSetting.ShowCursor;
            checkBoxShowGrid.Checked = GlobalSetting.RenderSetting.ShowGrid;
            numericUpDownSizeGrig.Value = GlobalSetting.RenderSetting.GridSize;
            checkBoxShowScanedGrid.Checked = GlobalSetting.RenderSetting.ShowScanedGrid;

            radioButtonShowAllCode.Checked = false;
            radioButtonShowCompleatedCode.Checked = false;
            radioButtonShowNOTCompleatedCode.Checked = false;

            switch (GlobalSetting.RenderSetting.gkodeshow)
            {
                case show3DGkode.all:
                    radioButtonShowAllCode.Checked = true;
                    break;
                case show3DGkode.compleated:
                    radioButtonShowCompleatedCode.Checked = true;
                    break;
                case show3DGkode.NotCompleated:
                    radioButtonShowNOTCompleatedCode.Checked = true;
                    break;
                default:
                    radioButtonShowAllCode.Checked = true;
                    break;
            }
        }
    }
}
