using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnrollStudentsInSchool_
{
    public partial class GUI_Student : Form
    {
        public GUI_Student()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInfor_Click(object sender, EventArgs e)
        {
            FormInforStudent finfor = new FormInforStudent();
            MainControls.Show(finfor, pnlMaincontrol);
        }
    }
}
