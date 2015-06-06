using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CNC_App.ConstructorGkode
{
    public partial class frmCycler : Form
    {
        private MainForm mf;

        public frmCycler(MainForm _mf)
        {
            mf = _mf;
            InitializeComponent();
        }

        private void frmCycler_Load(object sender, EventArgs e)
        {

        }
    }
}
