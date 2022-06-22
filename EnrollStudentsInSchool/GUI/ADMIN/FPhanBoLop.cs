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
    public partial class FPhanBoLop : UserControl
    {
        MyExecuteNonQuery myExecuteNonQuery;
        InsertData insert = new InsertData();
        UpdateData update = new UpdateData();
        DeleteData delete = new DeleteData();
        FindData find = new FindData();
        string TableName = "thamgiahoc";
        string MaLop = "";
        string MaSV = "";
        public FPhanBoLop()
        {
            InitializeComponent();
            LoadData();
            RefreshInput();
        }
        private void LoadData()
        {
            myExecuteNonQuery = new MyExecuteNonQuery();
            myExecuteNonQuery.LoadData(dgvPhanBoLop, TableName);
        }
        private void RefreshInput()
        {
            btnNhapDiem.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            foreach (Control txt in pnlMain.Controls)
            {
                if (txt is TextBox)
                {
                    txt.ResetText();
                }
            }
        }
        private bool CheckInforInput()
        {
            if (!(new Regex("[^' ']").IsMatch(txtMaLop.Text)) || !(new Regex("[^' ']").IsMatch(txtMaSV.Text)))
            {
                MessageBox.Show("VUI LÒNG NHẬP ĐÀY ĐỦ THÔNG TIN");
                return false;
            }
            else if (!txtMaLop.CheckStringIsNumber() || !txtMaSV.CheckStringIsNumber())
            {
                MessageBox.Show("MÃ LỚP HOẶC MÃ SV NHẬP CHƯA HỢP LỆ");
                return false;
            }    
            else if(!find.Find("lophocphan", $"maLopHocPhan = {txtMaLop.Text}"))
            {
                MessageBox.Show("MÃ LỚP HỌC PHẦN KHÔNG TỒN TẠI");
                return false;
            }    
            else if(!find.Find("sinhvien", $"maSinhVien = {txtMaSV.Text}"))
            {
                MessageBox.Show("MÃ SINH VIÊN KHÔNG TỒN TẠI");
                return false;
            }    
            return true;
        }    
        private List<string> getAllValuesOfTable()
        {
            string[] DiemChu = new string[] { "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín", "mười" };
            List<string> lstComponents = new List<string>();
            if(btnAdd.Enabled == true)
            {
                lstComponents.Add(txtMaLop.Text);
                lstComponents.Add(txtMaSV.Text);
            }
            else
            {
                lstComponents.Add(MaLop);
                lstComponents.Add(MaSV);
            }                 
            lstComponents.Add(cbBDiem.Text);           
            lstComponents.Add($"N'{DiemChu[int.Parse(cbBDiem.Text) - 1]}'");
            return lstComponents;
        }
        private void DataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNhapDiem.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = false;
            DataGridViewRow row = dgvPhanBoLop.Rows[e.RowIndex];
            MaLop = row.Cells[0].Value.ToString();
            MaSV = row.Cells[1].Value.ToString();
        }

        private void btnTimLop_Click(object sender, EventArgs e)
        {
            int dgvLenght = dgvPhanBoLop.Rows.Count-1;
            for (int row = 0; row < dgvLenght; row++)
            {
                if (dgvPhanBoLop.Rows[row].Cells[0].Value.ToString() != txtMaLop.Text)
                {
                    dgvPhanBoLop.Rows.RemoveAt(row);
                    dgvLenght--;
                    row--;
                }
            }
        }

        private void btnTimSV_Click(object sender, EventArgs e)
        {
            int dgvLenght = dgvPhanBoLop.Rows.Count - 1;
            for (int row = 0; row < dgvLenght; row++)
            {
                if (dgvPhanBoLop.Rows[row].Cells[1].Value.ToString() != txtMaSV.Text)
                {
                    dgvPhanBoLop.Rows.RemoveAt(row);
                    dgvLenght--;
                    row--;
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            RefreshInput();
        }

        private void btnNhapDiem_Click(object sender, EventArgs e)
        {
            update.Update(2, TableName, getAllValuesOfTable(), $"maLopHocPhan = {MaLop} AND maSinhVien = {MaSV}");
            LoadData(); RefreshInput();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(CheckInforInput())
            {
                List<string> lst = getAllValuesOfTable();
                lst.RemoveAt(3);
                lst.RemoveAt(2);
                lst.Add("NULL");
                lst.Add("NULL");
                insert.Insert(TableName, lst);
                LoadData(); RefreshInput();
            }    
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("BẠN CÓ CHẮC CHẤN MUỐN XÓA VÌ NÓ SẼ BỊ XÓA VĨNH VIỄN", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                delete.Delete(TableName, $"maLopHocPhan = {MaLop} and maSinhVien = {MaLop}");
                LoadData(); RefreshInput();
            }    
        }
    }
}
