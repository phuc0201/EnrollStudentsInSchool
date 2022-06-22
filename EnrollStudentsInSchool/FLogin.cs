using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace EnrollStudentsInSchool_
{
    public partial class FLogin : Form
    {
        OverdueAccount overdueAccount = new OverdueAccount();
        GetAccount getAccount = new GetAccount();
        public FLogin()
        {
            InitializeComponent();
            overdueAccount.Load();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llb_SignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister fR = new FormRegister();
            fR.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            GUI_Admin admin = new GUI_Admin();
            admin.ShowDialog();
            /*FindData findAcc = new FindData();
            if (new Regex("[@]").IsMatch(txtMail.Text))
            {
                string[] mail = txtMail.Text.Split('@');
                
                if (mail.Length != 2)
                {
                    MessageBox.Show("Vui lòng nhập lại mail");
                }
                else if (mail[1] == "student.hcmute.edu.vn" && getAccount.CheckAccountExists(mail[0], txtPassword.Text, "0").Length > 0)
                {
                    if (MessageBox.Show("ĐĂNG NHẬP THÀNH CÔNG") == DialogResult.OK)
                    {
                        txtMail.ResetText();
                        txtPassword.ResetText();
                        GUI_Student std = new GUI_Student();
                        std.ShowDialog();
                    }
                }
                else if (mail[1] == "teacher.hcmute.edu.vn" && getAccount.CheckAccountExists(mail[0], txtPassword.Text, "1").Length > 0)
                {
                    MessageBox.Show("Đây là giáo viên");
                }
                else if (mail[1] == "admin.hcmute.edu.vn")
                {
                    if (MessageBox.Show("Admin đăng nhập thành công") == DialogResult.OK)
                    {
                        txtMail.ResetText();
                        txtPassword.ResetText();
                        GUI_Admin admin = new GUI_Admin();
                        admin.ShowDialog();
                    }
                }
                else
                {
                    if (MessageBox.Show("ĐĂNG NHẬP THẤT BẠI") == DialogResult.OK)
                    {
                        txtMail.ResetText();
                        txtPassword.ResetText();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lại mail");
            }*/
        }
    }
}
