using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadingWinFormsAppAsAGroupProject
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtMessages.Text = "";
            try {
                ClassProcessing.ProcessClasses(txtMessages);
            } catch(Exception ex) {
                txtMessages.AppendText("Something went very wrong: " + Environment.NewLine + ex.Message);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
          
        }
    }
}
