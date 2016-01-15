using System;
using System.Windows.Forms;

namespace CNC_Assist
{
    public partial class LoadingData : Form
    {
        public LoadingData()
        {
            InitializeComponent();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = DataLoader.percentCompleated;
            label1.Text = DataLoader.descryption;

            if (DataLoader.status == DataLoader.eDataSetStatus.none) this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DataLoader.RequestStop();
            this.Close();
        }
    }
}
