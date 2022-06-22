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
    public partial class FStaff : UserControl
    {
        MyExecuteNonQuery myExecuteNonQuery;
        FindData find = new FindData();
        string TableName = "nhanvien";
        InsertData insert;
        UpdateData update;
        DeleteData delete;
        DataRecovery recovery;
        bool DeletedAccount = false;
        string MaNV = "";
        public FStaff()
        {
            InitializeComponent();
            pnlMain.SetDoubleBuffered();
            insert = new InsertData();
            update = new UpdateData();
            delete = new DeleteData();
            recovery = new DataRecovery();
            LoadData();
            RefreshInput();
        }
        private void LoadData()
        {
            myExecuteNonQuery = new MyExecuteNonQuery();
            myExecuteNonQuery.LoadData(dgvStaff, TableName);
        }
        private void RefreshInput()
        {
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
            DeletedAccount = false;
            btnDelete.Enabled = false;
            btnKhoiPhuc.Enabled = false;
            foreach (Control txt in pnlMain.Controls)
            {
                if (txt is TextBox)
                {
                    txt.ResetText();
                }
            }
        }
        private List<string> getAllValuesOfTable()
        {
            List<string> lstComponents = new List<string>();
            string gioitinh = "0";
            string Ngaysinh = dTPNgaySinh.Value.Year.ToString() + "-" + dTPNgaySinh.Value.Month.ToString() + "-" + dTPNgaySinh.Value.Day.ToString();
            if (cbBSex.Checked == true)
            {
                gioitinh = "1";
            }
            lstComponents.Add($"empty");
            lstComponents.Add($"N'{txtFullName.Text}'");
            lstComponents.Add($"N'{txtChucVu.Text}'");
            lstComponents.Add($"'{Ngaysinh}'");
            lstComponents.Add($"{gioitinh}");
            lstComponents.Add($"'{txtEmail.Text}@gmail.com'");
            lstComponents.Add($"'{txtPhoneNumber.Text}'");
            return lstComponents;
        }
        public bool CheckInputInfor()
        {
            if (!pnlMain.CheckInforInputIsEmpty())
            {
                MessageBox.Show("VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN"); return false;
            }
            else if (!txtFullName.CheckStringContainsSpecialCharacters() || !txtEmail.CheckStringIsNumberAndChar() || !txtChucVu.CheckStringContainsSpecialCharacters())
            {
                MessageBox.Show("THÔNG TIN NHẬP KHÔNG HỢP LỆ"); return false;
            }
            else if(btnAdd.Enabled == true)
            {
                if (!(new Regex("[^' ']").IsMatch(txtUserName.Text)) || !(new Regex("[^' ']").IsMatch(txtPassword.Text)))
                {
                    MessageBox.Show("VUI LÒNG TẠO TÀI KHOẢN ĐĂNG NHẬP CHO NHÂN VIÊN");
                    return false;
                }
                else if (!txtUserName.CheckStringIsNumberAndChar())
                {
                    MessageBox.Show("TÊN DÙNG DÙNG KHÔNG HỢP LỆ");
                    return false;
                }
                else if (find.Find("nguoidung", $"tenNguoiDung = '{txtUserName.Text}'"))
                {
                    MessageBox.Show("TÊN NGƯỜI DÙNG ĐÃ TỒN TẠI");
                    return false;
                }
            }        
            else if (!txtPhoneNumber.CheckStringIsNumber() || txtPhoneNumber.Text.Length != 10 || txtPhoneNumber.Text[0] != '0')
            {
                MessageBox.Show("THÔNG TIN NHẬP KHÔNG HỢP LỆ"); 
                return false;
            }
            return true;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            RefreshInput();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckInputInfor())
            {
                List<string> lst = getAllValuesOfTable();
                lst.RemoveAt(0);
                lst.Add($"'{txtUserName.Text}'");
                lst.Add($"'{txtPassword.Text}'");
                insert.Insert(lst);
                LoadData();
                RefreshInput();
            }    
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(DeletedAccount == true)
            {
                MessageBox.Show("TÀI KHOẢN ĐÃ BỊ KHÓA");
            }   
            else if(MessageBox.Show("BẠN CÓ CHẮC CHẮN XÓA KHÔNG", "THÔNG BÁO", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                delete.Delete(MaNV, TableName, "maNhanVien");
                LoadData();
                RefreshInput();
            }    
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DeletedAccount == true)
            {
                MessageBox.Show("TÀI KHOẢN ĐÃ BỊ KHÓA");
            }
            else if (CheckInputInfor())
            {
                update.Update(1,TableName, getAllValuesOfTable(), $"maNhanVien = {MaNV}");
                LoadData();
                RefreshInput();
            }    
        }
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (DeletedAccount == false)
            {
                MessageBox.Show("TÀI KHOẢN CHƯA BỊ KHÓA");
            }
            else
            {
                update.Update(TableName, "ngayxoa = NULL", $"maNhanVien = {MaNV}");
                LoadData();
                RefreshInput();
            }    
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!(new Regex("[^' ']").IsMatch(txtTimKiem.Text)))
            {
                MessageBox.Show("VUI LÒNG NHẬP MÃ NHÂN VIÊN CẦN TÌM KIẾM");
            }
            else if (!txtTimKiem.CheckStringIsNumber())
            {
                MessageBox.Show("MÃ NHÂN VIÊN KHÔNG HỢP LỆ");
            }
            else if (!find.Find("nhanvien", "maNhanVien = " + txtTimKiem.Text + ""))
            {
                if (MessageBox.Show("NHÂN VIÊN BẠN TÌM KIẾM KHÔNG TỒN TẠI") == DialogResult.OK)
                {
                    txtTimKiem.ResetText();
                }
            }
            else
            {
                LoadData();
                int dgvLenght = dgvStaff.Rows.Count;
                for (int row = 0; row < dgvLenght - 1; row++)
                {
                    if (int.Parse(dgvStaff.Rows[row].Cells[0].Value.ToString()) != int.Parse(txtTimKiem.Text))
                    {
                        dgvStaff.Rows.RemoveAt(row);
                        dgvLenght--;
                        row--;
                    }
                }
            }
        }

        private void DataGridViewClick(object sender, DataGridViewCellEventArgs e)
        {
            cbBSex.Checked = false;
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnKhoiPhuc.Enabled = true;
            DataGridViewRow row = dgvStaff.Rows[e.RowIndex];
            MaNV = row.Cells[0].Value.ToString();
            txtFullName.Text = row.Cells[1].Value.ToString();
            txtChucVu.Text = row.Cells[2].Value.ToString();
            dTPNgaySinh.Text = row.Cells[3].Value.ToString();
            if (row.Cells[4].Value.ToString() == "True")
            {
                cbBSex.Checked = true;
            }
            txtEmail.Text = row.Cells[5].Value.ToString().Split("@")[0];
            txtPhoneNumber.Text = row.Cells[6].Value.ToString();
            if (row.Cells[7].Value.ToString().Length > 0)
                DeletedAccount = true;
            else
                DeletedAccount = false;
        }
    }
}
