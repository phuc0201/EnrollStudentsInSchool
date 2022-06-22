using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace EnrollStudentsInSchool_
{
    public partial class FormRegister : System.Windows.Forms.Form
    {
        DateTime realTime;
        public FormRegister()
        {
            InitializeComponent();
            this.Width = 1486;
            this.Height = 836;
            realTime = DateTime.Now;
            lbYearOfRegistration.Text = realTime.Year.ToString();
        }

        private bool CheckInfoEntry()
        {
            foreach (Control pnl in this.Controls)
            {
                if(pnl is Panel && (string)pnl.Tag == "pnlInfor")
                {
                    foreach (Control txt in pnl.Controls)
                    {
                        if (txt is TextBox)
                        {
                            if (!(new Regex("[^' ']").IsMatch(txt.Text)))
                            {
                                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                            else
                            {
                                if ((string)txt.Tag == "char")
                                {
                                    if (new Regex("[0-9~`!@#$%^&*/();:?<>.,|\\[\\]\\-{}_=+]").IsMatch(txt.Text))
                                    {
                                        MessageBox.Show("Vui lòng kiểm tra lại thông tin đã nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                                else if (new Regex("[^0-9]").IsMatch(txt_noCCCD.Text) || txt_noCCCD.Text.Length != 9 || txt_noCCCD.Text.Length != 12)
                                {
                                    MessageBox.Show("Vui lòng kiểm tra lại số cccd/cmnd đã nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                                else if (new Regex("[^0-9]").IsMatch(txtPhoneNumber.Text) || txtPhoneNumber.Text.Length != 10 || txtPhoneNumber.Text[0]!='0')
                                {
                                    MessageBox.Show("Vui lòng kiểm tra lại số điện thoại đã nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                                else if(new Regex("[^0-9]").IsMatch(txtNamtotnghiep.Text))
                                {
                                    MessageBox.Show("Vui lòng kiểm tra lại năm tốt nghiệp đã nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                                else
                                {
                                    if(new Regex("[~`!@#$%^&*();:?<>.|\\[\\]\\-{}_=+]").IsMatch(txtDiachi.Text))
                                    {
                                        MessageBox.Show("Vui lòng kiểm tra lại địa chỉ đã nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                    if (new Regex("[^0-9a-zA-Z]").IsMatch(txtEmail.Text))
                                    {
                                        MessageBox.Show("Vui lòng kiểm tra lại email đã nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
        private float GradesCalculation()
        {
            try
            {
                float Subject_01 = 0f;
                float Subject_02 = 0f;
                float Subject_03 = 0f;
                float DiemUuTien = 0f;
                foreach (Control txt in pnlStudyResult.Controls)
                {
                    if (txt is TextBox)
                    {
                        if(float.Parse(txt.Text) < 0f || float.Parse(txt.Text) > 10f)
                        {
                            return -1f;
                        }    
                        if ((string)txt.Tag == "Môn 1")
                        {
                            Subject_01 += float.Parse(txt.Text);
                        }
                        else if ((string)txt.Tag == "Môn 2")
                        {
                            Subject_02 += float.Parse(txt.Text);
                        }
                        else if ((string)txt.Tag == "Môn 3")
                        {
                            Subject_03 += float.Parse(txt.Text);
                        }
                    }
                }
                if (cbB_KhuVucUuTien.Text == "KV1")
                {
                    DiemUuTien = 0.75f;
                }
                if (cbB_KhuVucUuTien.Text == "KV2")
                {
                    DiemUuTien = 0.25f;
                }
                if (cbB_KhuVucUuTien.Text == "KV2 - NT")
                {
                    DiemUuTien = 0.5f;
                }
                lbGrades.Text = ((float)Subject_01 / 5 + (float)Subject_02 / 5 + (float)Subject_03 / 5 + DiemUuTien).ToString();
            }
            catch
            {
                return -1f;
            }
            return float.Parse(lbGrades.Text);
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if(GradesCalculation() < 0)
            {
                MessageBox.Show("Vui lòng kiểm tra phần nhập điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        { 
            if(CheckInfoEntry())
            {
                if (GradesCalculation() == 0)
                {
                    MessageBox.Show("Khỏi xét cũng biết rớt :)) năm sau làm lại bạn nhé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(GradesCalculation() > 0)
                {
                    if (MessageBox.Show("Nộp hồ sơ thành công vui lòng check mail để biết kết quả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        FSetUserName f = new FSetUserName();
                        f.ShowDialog();
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Vui lòng kiểm tra phần nhập điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
