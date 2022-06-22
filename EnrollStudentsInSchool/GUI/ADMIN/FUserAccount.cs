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
    public partial class FUserAccount : UserControl
    {
        MyExecuteNonQuery myExecuteNonQuery;
        DataRecovery recovery = new DataRecovery();
        UpdateData update = new UpdateData();
        FindData find = new FindData();
        string TableName = "nguoidung";
        public FUserAccount()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            myExecuteNonQuery = new MyExecuteNonQuery();
            myExecuteNonQuery.LoadData(dgvUserAccount, TableName);
        }
        
        private void DataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDoiMK.Enabled = true;
            DataGridViewRow row = dgvUserAccount.Rows[e.RowIndex];
            lbUserName.Text = row.Cells[0].Value.ToString();
            lbPassWord.Text = row.Cells[1].Value.ToString();
        }
        private bool CheckInforInput()
        {
            if(!(new Regex("[^' ']").IsMatch(txtNewPass.Text)))
            {
                MessageBox.Show("PHẢI TẠO MK MỚI TRƯỚC KHI ẤN ĐỔI");
                return false;
            }    
            return true;
        }
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            btnDoiMK.Enabled = false;
            if(CheckInforInput())
            {
                update.Update(TableName, $"matKhau = '{txtNewPass.Text}'",  $"tenNguoiDung = '{lbUserName.Text}'");
            }
            lbUserName.Text = "______";
            lbPassWord.Text = "______";
            LoadData();
        }

        private void btnTkDangKhoa_Click(object sender, EventArgs e)
        {
            int dgvLenght = dgvUserAccount.Rows.Count-1;
            for(int row = 0; row < dgvLenght; row++)
            {
                if (dgvUserAccount.Rows[row].Cells[4].Value.ToString().Length > 0)
                {
                    if (find.Find("sinhvien", $"maSinhVien = {dgvUserAccount.Rows[row].Cells[4].Value.ToString()} and ngayxoa is NULL"))
                    {
                        dgvUserAccount.Rows.RemoveAt(row);
                        dgvLenght--;
                        row--;
                    }    
                }
                else if(dgvUserAccount.Rows[row].Cells[3].Value.ToString().Length > 0)
                {
                    if (find.Find("nhanvien", $"maNhanVien = {dgvUserAccount.Rows[row].Cells[3].Value.ToString()} and ngayxoa is NULL"))
                    {
                        dgvUserAccount.Rows.RemoveAt(row);
                        dgvLenght--;
                        row--;
                    }
                }    
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
