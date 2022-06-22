using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnrollStudentsInSchool_
{
    public partial class FLopHocPhan : UserControl
    {
        FindData find = new FindData();
        MyExecuteNonQuery myExecuteNonQuery;
        string TableName = "lophocphan";
        DataGridView dataGridView = new DataGridView();
        InsertData insert;
        UpdateData update;
        DeleteData delete;
        public FLopHocPhan()
        {
            InitializeComponent();
            pnlMain.SetDoubleBuffered();
            insert = new InsertData();
            update = new UpdateData();
            delete = new DeleteData();
            LoadData();
            RefreshInput();
        }
        private void LoadData()
        {
            myExecuteNonQuery = new MyExecuteNonQuery();
            myExecuteNonQuery.LoadData(dgvLopHocPhan, TableName);
            int dgvLenght = dgvLopHocPhan.Rows.Count - 1;
            for (int row=0; row < dgvLenght; row++)
            {
                if(find.Find("nhanvien", $"maNhanVien = {dgvLopHocPhan.Rows[row].Cells[4].Value.ToString()} and ngayxoa is not NULL"))
                {
                    dgvLopHocPhan.Rows.RemoveAt(row);
                    dgvLenght--;
                    row--;
                }
            }
            for (int row = 0; row < dgvLenght; row++)
            {
                if (find.Find("monhoc", $"maMonHoc = '{dgvLopHocPhan.Rows[row].Cells[1].Value.ToString()}' and ngayxoa is not NULL"))
                {
                    dgvLopHocPhan.Rows.RemoveAt(row);
                    dgvLenght--;
                    row--;
                }
            }
        }
        private void RefreshInput()
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            lbMaLopHocPhan.Text = "";
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
            lstComponents.Add($"{lbMaLopHocPhan.Text}");
            lstComponents.Add($"'{txtMaMH.Text}'");
            lstComponents.Add($"{txtNamHoc.Text}");
            lstComponents.Add($"N'{cbBHocKy.Text}'");
            lstComponents.Add($"{txtMaGV.Text}");
            lstComponents.Add($"N'{cbBNgonNguGiangDay.Text}'");
            lstComponents.Add($"N'{txtMoTa.Text}'");
            lstComponents.Add($"{txtSoLuongSV.Text}");
            return lstComponents;
        }
        private bool CheckInputInfor()
        {
            if(!pnlMain.CheckInforInputIsEmpty())
            {
                MessageBox.Show("VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN");
                return false;
            }    
            else if(!txtNamHoc.CheckStringIsNumber() || !txtSoLuongSV.CheckStringIsNumber())
            {
                MessageBox.Show("THÔNG TIN NHẬP KHÔNG HỢP LỆ");
                return false;
            }   
            else if(int.Parse(txtSoLuongSV.Text) < 20 || int.Parse(txtSoLuongSV.Text) > 150)
            {
                MessageBox.Show("SỐ LƯỢNG SINH VIÊN PHẢI NHIỀU HƠN 20 VÀ TỐI ĐA LÀ 150 SINH VIÊN");
                return false;
            }    
            else if (!find.Find("monhoc", "maMonHoc = '" + txtMaMH.Text + "'"))
            {
                MessageBox.Show("MÃ MÔN HỌC KHÔNG HỢP LỆ");
                return false;
            }
            else if (!txtMaGV.CheckStringIsNumber() || !find.Find("nhanvien", "maNhanVien = " + txtMaGV.Text + " AND (theLoai = N'Giảng viên' or theLoai = N'Chuyên viên')"))
            {
                MessageBox.Show("MÃ GIÁO VIÊN KHÔNG HỢP LỆ");
                return false;
            }
            else if(find.Find("monhoc", $"maMonHoc = '{txtMaMH.Text}' and ngayxoa is not NULL"))
            {
                MessageBox.Show("MÔN HỌC ĐANG BỊ KHÓA");
                return false;
            }
            else if (find.Find("nhanvien", $"maNhanVien = '{txtMaGV.Text}' and ngayxoa is not NULL"))
            {
                MessageBox.Show("NHÂN VIÊN ĐANG BỊ KHÓA");
                return false;
            }
            return true;
        }
        private void btnTraMa_MonHoc_Click(object sender, EventArgs e)
        {
            if (btnTraMa_MonHoc.Text == "Tra mã")
            {
                if (btnTraMa_GV.Text == "Back")
                {
                    dataGridView.Swap(dgvLopHocPhan, pnlMain, "lophocphan");
                    btnTraMa_GV.Text = "Tra mã";
                }
                dgvLopHocPhan.Swap(dataGridView, pnlMain, "monhoc");
                btnTraMa_MonHoc.Text = "Back";
            }
            else
            {
                dataGridView.Swap(dgvLopHocPhan, pnlMain, "lophocphan");
                btnTraMa_MonHoc.Text = "Tra mã";
            }

        }

        private void btnTraMa_GV_Click(object sender, EventArgs e)
        {
            if (btnTraMa_GV.Text == "Tra mã")
            {
                if (btnTraMa_MonHoc.Text == "Back")
                {
                    dataGridView.Swap(dgvLopHocPhan, pnlMain, "lophocphan");
                    btnTraMa_MonHoc.Text = "Tra mã";
                }
                dgvLopHocPhan.Swap(dataGridView, pnlMain, "nhanvien");
                btnTraMa_GV.Text = "Back";
            }
            else
            {
                dataGridView.Swap(dgvLopHocPhan, pnlMain, "lophocphan");
                btnTraMa_GV.Text = "Tra mã";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckInputInfor())
            {
                List<string> lst = getAllValuesOfTable();
                lst.RemoveAt(0);
                insert.Insert(TableName, lst);
                LoadData();
                RefreshInput();
            }    
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete.Delete(TableName, $"maLopHocPhan = {lbMaLopHocPhan.Text}");
            LoadData();
            RefreshInput();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
             if (CheckInputInfor())
             {
                update.Update(1,TableName,getAllValuesOfTable(), $"maLopHocPhan = {lbMaLopHocPhan.Text}");
                LoadData();
                RefreshInput();
             }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            RefreshInput();
        }

        private void DataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = false;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLopHocPhan.Rows[e.RowIndex];
                lbMaLopHocPhan.Text = row.Cells[0].Value.ToString();
                txtMaMH.Text = row.Cells[1].Value.ToString();
                txtNamHoc.Text = row.Cells[2].Value.ToString();
                cbBHocKy.Text = row.Cells[3].Value.ToString();
                txtMaGV.Text = row.Cells[4].Value.ToString();
                cbBNgonNguGiangDay.Text = row.Cells[5].Value.ToString();
                txtMoTa.Text = row.Cells[6].Value.ToString();
                txtSoLuongSV.Text = row.Cells[7].Value.ToString();
            }
        }
    }
}