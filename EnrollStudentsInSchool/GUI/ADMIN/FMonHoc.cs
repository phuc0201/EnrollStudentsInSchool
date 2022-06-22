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
    public partial class FMonHoc : UserControl
    {
        FindData find = new FindData();
        MyExecuteNonQuery myExecuteNonQuery;
        DataGridView dataGridView;
        string TableName = "monhoc";
        InsertData insert;
        UpdateData update;
        DeleteData delete;
        DataRecovery recover;
        bool Deleted = false;
        public FMonHoc()
        {
            InitializeComponent();
            insert = new InsertData();
            update = new UpdateData();
            delete = new DeleteData();
            recover = new DataRecovery();
            LoadData();
            RefreshInput();
            pnlMain.SetDoubleBuffered();
        }
        private void LoadData()
        {
            myExecuteNonQuery = new MyExecuteNonQuery();
            myExecuteNonQuery.LoadData(dgvMonhoc, TableName);
        }
        private void RefreshInput()
        {
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
            txtMaMH.Enabled = true;
            btnDelete.Enabled = false;
            Deleted = false;
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
            lstComponents.Add($"'{txtMaMH.Text}'");
            lstComponents.Add($"N'{txtTenMH.Text}'");
            lstComponents.Add($"{cbBSoTC.Text}");
            lstComponents.Add($"{txtNamApDung.Text}");
            lstComponents.Add($"N'{cbBTheLoai.Text}'");
            lstComponents.Add($"N'{txtMoTaTT.Text}'");
            lstComponents.Add($"N'{txtMoTaCT.Text}'");
            lstComponents.Add($"N'{txtTLThamKhao.Text}'");
            lstComponents.Add($"N'{txtMucTieuDauRa.Text}'");
            lstComponents.Add($"N'{cbBHinhThucDanhGia.Text}'");
            lstComponents.Add($"'{txtMaChuongTrinhDaoTao.Text}'");
            lstComponents.Add("NULL");
            return lstComponents;
        }
        private bool CheckInputInfor()
        {
            if(!pnlMain.CheckInforInputIsEmpty())
            {
                MessageBox.Show("VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN");
                return false;
            }
            else if(!txtTenMH.CheckStringContainsSpecialCharacters())
            {
                MessageBox.Show("TÊN MÔN HỌC KHÔNG HỢP LỆ");
                return false;
            }
            else if(!txtMaMH.CheckStringIsNumberAndChar())
            {
                MessageBox.Show("MÃ MÔN HỌC KHÔNG HỢP LỆ");
                return false;
            }    
            else if (!find.Find("chuongtrinhdaotao", "maChuongTrinhDaoTao = '" + txtMaChuongTrinhDaoTao.Text + "' and ngayxoa is NULL"))
            {
                MessageBox.Show("MÃ CHƯƠNG TRÌNH ĐÀO TẠO K TỒN TẠI");
                return false;
            }
            else if (btnUpdate.Enabled == false && find.Find(TableName, "maMonHoc = '" + txtMaMH.Text + "'"))
            {
                MessageBox.Show("MÃ MÔN HỌC ĐÃ TỒN TẠI");
                return false;
            }
            else if(!txtNamApDung.CheckStringIsNumber())
            {
                MessageBox.Show("NĂM ÁP DỤNG KHÔNG HỢP LỆ");
                return false;
            }    
            return true;
        }

        private void btnTraMaClick(object sender, EventArgs e)
        {
            if (btnTraMa.Text == "Tra mã")
            {
                dataGridView = new DataGridView();
                dgvMonhoc.Swap(dataGridView, pnlMain, "chuongtrinhdaotao");
                btnTraMa.Text = "Back";
            }
            else
            {
                dataGridView.Swap(dgvMonhoc, pnlMain, TableName);
                btnTraMa.Text = "Tra mã";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(CheckInputInfor())
            {
                insert.Insert(TableName, getAllValuesOfTable());
                LoadData();
                RefreshInput();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Deleted == true)
            {
                MessageBox.Show("MÔN HỌC ĐANG BỊ KHÓA");
            }
            else
            {
                if(MessageBox.Show("BẠN CÓ CHẮC MUỐN XÓA", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    delete.Delete($"'{txtMaMH.Text}'", "monhoc", "maMonHoc");
                    LoadData();
                    RefreshInput();
                }    
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(Deleted == true)
            {
                MessageBox.Show("MÔN HỌC NÀY ĐANG BỊ KHÓA");
            }   
            else
            {
                if (CheckInputInfor())
                {
                    update.Update(1, TableName, getAllValuesOfTable(), $"maMonHoc = '{txtMaMH.Text}'");
                    LoadData();
                    RefreshInput();
                }
            }    
        }
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if(Deleted == false)
            {
                MessageBox.Show("MÔN CHƯA BỊ XÓA");
            }    
            else if(MessageBox.Show("BẠN CÓ CHẮN MUỐN KHÔI PHỤC","THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                recover.Recovery("KhoiPhucMH", $"'{txtMaMH.Text}', '{txtMaChuongTrinhDaoTao.Text}'");
                LoadData();
                RefreshInput();
            }      
        }
        private void DataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            txtMaMH.Enabled = false;
            btnKhoiPhuc.Enabled = true;
            DataGridViewRow row = dgvMonhoc.Rows[e.RowIndex];
            txtMaMH.Text = row.Cells[0].Value.ToString();
            txtTenMH.Text = row.Cells[1].Value.ToString();
            cbBSoTC.Text = row.Cells[2].Value.ToString();
            txtNamApDung.Text = row.Cells[3].Value.ToString();
            cbBTheLoai.Text = row.Cells[4].Value.ToString();
            txtMoTaTT.Text = row.Cells[5].Value.ToString();
            txtMoTaCT.Text = row.Cells[6].Value.ToString();
            txtTLThamKhao.Text = row.Cells[7].Value.ToString();
            txtMucTieuDauRa.Text = row.Cells[8].Value.ToString();
            cbBHinhThucDanhGia.Text = row.Cells[9].Value.ToString();
            txtMaChuongTrinhDaoTao.Text = row.Cells[10].Value.ToString();
            if(row.Cells[11].Value.ToString().Length > 0)
            {
                Deleted = true;
            }   
            else
            {
                Deleted = false;
            }    
        }

        private void btnTimKiemMH_Click(object sender, EventArgs e)
        {
            if (!(new Regex("[^' ']").IsMatch(txtTimKiem.Text)))
            {
                MessageBox.Show("VUI LÒNG NHẬP MÃ MÔN HỌC CẦN TÌM KIẾM");
            }
            else if (!txtTimKiem.CheckStringIsNumberAndChar())
            {
                MessageBox.Show("MÃ MÔN HỌC KHÔNG HỢP LỆ");
            }
            else if (!find.Find("monhoc", "maMonHoc = '" + txtTimKiem.Text + "'"))
            {
                if (MessageBox.Show("MÔN HỌC BẠN TÌM KIẾM KHÔNG TỒN TẠI") == DialogResult.OK)
                {
                    txtTimKiem.ResetText();
                }
            }
            else
            {
                LoadData();
                int dgvLenght = dgvMonhoc.Rows.Count;
                for (int row = 0; row < dgvLenght - 1; row++)
                {
                    if (dgvMonhoc.Rows[row].Cells[0].Value.ToString() != txtTimKiem.Text)
                    {
                        dgvMonhoc.Rows.RemoveAt(row);
                        dgvLenght--;
                        row--;
                    }
                }
            }
        }
    }
}
