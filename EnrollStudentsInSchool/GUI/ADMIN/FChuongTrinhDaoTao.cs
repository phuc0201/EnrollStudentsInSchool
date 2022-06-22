using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnrollStudentsInSchool_
{
    public partial class FChuongTrinhDaoTao : UserControl
    {
        FindData find = new FindData();
        MyExecuteNonQuery myExecuteNonQuery;
        InsertData insert;
        UpdateData update;
        DeleteData delete;
        DataRecovery recover;
        string TableName = "chuongtrinhdaotao";
        bool Deleted = false;
        public FChuongTrinhDaoTao()
        {
            InitializeComponent();
            insert = new InsertData();
            update = new UpdateData();
            delete = new DeleteData();
            recover = new DataRecovery();
            pnlMain.SetDoubleBuffered();
            LoadData();
            RefreshInput();
        }
        private void LoadData()
        {
            myExecuteNonQuery = new MyExecuteNonQuery();
            myExecuteNonQuery.LoadData(dgvChuongTrinhDaoTao, TableName);
        }
        private void RefreshInput()
        {
            Deleted = false;
            btnUpdate.Enabled = false;
            txtMaChuongTrinhDaoTao.Enabled = true;
            btnAdd.Enabled = true;
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
            lstComponents.Add($"'{txtMaChuongTrinhDaoTao.Text}'");
            lstComponents.Add($"N'{txtTenChuongTrinhDaoTao.Text}'");
            lstComponents.Add($"{txtSoTC.Text}");
            lstComponents.Add($"{txtNamBatDau.Text}");
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
            else if(btnUpdate.Enabled == false)
            {
                if (find.Find("chuongtrinhdaotao", $"maChuongTrinhDaoTao = '{txtMaChuongTrinhDaoTao.Text}'") || !txtMaChuongTrinhDaoTao.CheckStringIsNumberAndChar())
                {
                    MessageBox.Show("MÃ CHƯƠNG TRÌNH ĐÀO TẠO KHÔNG HỢP LỆ");
                    return false;
                }
            }
            else if(!txtTenChuongTrinhDaoTao.CheckStringContainsSpecialCharacters())
            {
                MessageBox.Show("TÊN CHƯƠNG TRÌNH ĐÀO TẠO KHÔNG HỢP LỆ");
                return false;
            }
            else if(!txtSoTC.CheckStringIsNumber())
            {
                MessageBox.Show("SỐ TC CHỈ CHỨA SỐ VUI LÒNG KIỂM TRA LẠI");
                return false;
            } 
            else if(!txtNamBatDau.CheckStringIsNumber())
            {
                MessageBox.Show("NĂM BẮT ĐẦU LÀ SỐ VUI LÒNG KIỂM TRA LẠI");
                return false;
            }    
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(CheckInputInfor())
            {
                MessageBox.Show("THÊM THÀNH CÔNG");              
                insert.Insert(TableName, getAllValuesOfTable());
                LoadData();
                RefreshInput();
            }     
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(Deleted == true)
            {
                MessageBox.Show("CHƯƠNG TRÌNH ĐÀO TẠO NÀY ĐANG BỊ KHÓA");
            }    
            else if(CheckInputInfor())
            {                
                update.Update(1,TableName, getAllValuesOfTable(), $"maChuongTrinhDaoTao = '{txtMaChuongTrinhDaoTao.Text}'");
                LoadData();
                RefreshInput();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(Deleted == true)
            {
                MessageBox.Show("CHƯƠNG TRÌNH ĐÀO TẠO NÀY ĐANG BỊ KHÓA");
            }   
            else
            {
                if (MessageBox.Show("BẠN CÓ CHẮC LÀ MUỐN XÓA KHÔNG", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    delete.Delete($"'{txtMaChuongTrinhDaoTao.Text}'");
                    LoadData();
                    RefreshInput();
                }    
            }    
        }
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if(Deleted == false)
            {
                MessageBox.Show("MÃ CHƯƠNG TRÌNH CHƯA BỊ XÓA");
            }   
            else
            {
                if (MessageBox.Show("BẠN CÓ MUỐN KHÔI PHỤC LẠI CÁC THÀNH PHẦN LIÊN QUAN KHÔNG", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    recover.Recovery("KhoiPhuc_CTDT", $"'{txtMaChuongTrinhDaoTao.Text}'");
                }
                else
                {
                    recover.Recovery(TableName, "ngayxoa = NULL", $"maChuongTrinhDaoTao = '{txtMaChuongTrinhDaoTao.Text}'");
                }    
            }
            LoadData();
            RefreshInput();
        }
        private void DataGridviewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            txtMaChuongTrinhDaoTao.Enabled = false;
            btnKhoiPhuc.Enabled = true;
            DataGridViewRow row = dgvChuongTrinhDaoTao.Rows[e.RowIndex];
            txtMaChuongTrinhDaoTao.Text = row.Cells[0].Value.ToString();
            txtTenChuongTrinhDaoTao.Text = row.Cells[1].Value.ToString();
            txtSoTC.Text = row.Cells[2].Value.ToString();
            txtNamBatDau.Text = row.Cells[3].Value.ToString();
            if(row.Cells[4].Value.ToString().Length > 0)
            {
                Deleted = true;
            }   
            else
            {
                Deleted = false;
            }    
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            RefreshInput();
        }
    }
}
