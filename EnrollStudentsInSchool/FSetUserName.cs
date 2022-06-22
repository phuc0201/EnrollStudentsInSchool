using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnrollStudentsInSchool_
{
    public partial class FSetUserName : Form
    {
        public string username = "username";
        public FSetUserName()
        {
            InitializeComponent();
        }

        private void btnSetName_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
