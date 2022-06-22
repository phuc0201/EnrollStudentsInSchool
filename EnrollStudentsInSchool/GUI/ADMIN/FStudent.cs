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
    public partial class FStudent : UserControl
    {
        DateTime dateTime;
        MyExecuteNonQuery myExecuteNonQuery;
        InsertData insert;
        UpdateData update;
        DeleteData delete;
        DataRecovery recovery;
        string TableName = "sinhvien";
        FindData find = new FindData();
        DataGridView dataGridView = new DataGridView();
        string old_CCCD = "";
        string MSSV_Curr = "";
        bool DeletedAccount;
        public FStudent()
        {
            InitializeComponent();
            insert = new InsertData();
            update = new UpdateData();
            delete = new DeleteData();
            recovery = new DataRecovery();
            pnlMain.SetDoubleBuffered();
            dateTime = DateTime.Now;
            lbNamNhapHoc.Text = dateTime.Year.ToString();
            LoadData();
            RefreshInput();
        }
        private void LoadData()
        {
            myExecuteNonQuery = new MyExecuteNonQuery();
            myExecuteNonQuery.LoadData(dgvStudent, TableName);
        }
        private void RefreshInput()
        {
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            DeletedAccount = false;
            txtChuongTrinhDaoTao.Enabled = true;
            old_CCCD = "";
            foreach (Control txt in pnlMain.Controls)
            {
                if (txt is TextBox)
                {
                    txt.ResetText();
                }
            }
        }
        public bool CheckInputInfor()
        {
            if (!pnlMain.CheckInforInputIsEmpty())
            {
                MessageBox.Show("VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN"); return false;
            }
            else if (!find.Find("chuongtrinhdaotao", "maChuongTrinhDaoTao = '" + txtChuongTrinhDaoTao.Text + "' and ngayxoa is NULL"))
            {
                MessageBox.Show("MÃ CHƯƠNG TRÌNH ĐÀO TẠO K TỒN TẠI");
                return false;
            }
            else if (txtCCCDorCMND.Text != old_CCCD)
            {
                if(find.Find($"sinhvien", "SoCCCD = '" + txtCCCDorCMND.Text + "'"))
                {
                    MessageBox.Show("CCCD/CMND ĐÃ TỒN TẠI");
                    return false;
                }    
            }
            else if(!txtFullName.CheckStringContainsSpecialCharacters()|| !txtDantoc.CheckStringContainsSpecialCharacters() || !txtNoisinh.CheckStringContainsSpecialCharacters() || !txtDiachi.CheckAddress() || !txtEmail.CheckStringIsNumberAndChar())
            {
                MessageBox.Show("THÔNG TIN NHẬP KHÔNG HỢP LỆ");  return false;
            }
            else if(!txtCCCDorCMND.CheckStringIsNumber() || (txtCCCDorCMND.Text.Length != 9 && txtCCCDorCMND.Text.Length != 12) || !txtPhoneNumer.CheckStringIsNumber() || txtPhoneNumer.Text.Length!=10 || txtPhoneNumer.Text[0]!='0')
            {
                MessageBox.Show("THÔNG TIN NHẬP KHÔNG HỢP LỆ");  return false;
            }    
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(CheckInputInfor())
            {
                string gioitinh = "0";
                string Ngaysinh = dTP_Birthdate.Value.Year.ToString() + "-" + dTP_Birthdate.Value.Month.ToString() + "-" + dTP_Birthdate.Value.Day.ToString();
                if(cbGioiTinh.Checked == true)
                {
                    gioitinh = "1";
                }
                insert.Insert(txtFullName.Text, Ngaysinh, lbNamNhapHoc.Text, txtChuongTrinhDaoTao.Text, gioitinh, txtEmail.Text + "@gmail.com", txtPhoneNumer.Text,
                      txtDiachi.Text, txtNoisinh.Text,txtDantoc.Text, txtCCCDorCMND.Text);
                LoadData();
                RefreshInput();
            }    
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(DeletedAccount == true)
            {
                MessageBox.Show("TÀI KHOẢN NÀY ĐÃ BỊ KHÓA");
            }
            else
            {
                if (CheckInputInfor())
                {
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = false;
                    txtChuongTrinhDaoTao.Enabled = true;
                    string gioitinh = "0";
                    string Ngaysinh = dTP_Birthdate.Value.Year.ToString() + "-" + dTP_Birthdate.Value.Month.ToString() + "-" + dTP_Birthdate.Value.Day.ToString();
                    if (cbGioiTinh.Checked == true)
                    {
                        gioitinh = "1";
                    }
                    update.Update(MSSV_Curr, txtFullName.Text, Ngaysinh, lbNamNhapHoc.Text, txtChuongTrinhDaoTao.Text, gioitinh, txtEmail.Text + "@gmail.com", txtPhoneNumer.Text, "",
                        txtDiachi.Text, txtNoisinh.Text, txtDantoc.Text, txtCCCDorCMND.Text);
                    LoadData();
                }
            }
            RefreshInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(DeletedAccount == true)
            {
                MessageBox.Show("TÀI KHOẢN ĐÃ BỊ KHÓA");
            }
            else if (MessageBox.Show("BẠN CÓ CHẮC CHẮN XÓA KHÔNG", "THÔNG BÁO", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                delete.Delete(MSSV_Curr, TableName, "maSinhVien");
                LoadData();
                btnDelete.Enabled = false;
                btnAdd.Enabled = true;
            }

            RefreshInput();
        }
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (DeletedAccount == false)
            {
                MessageBox.Show("MÔN CHƯA BỊ XÓA");
            }
            else if (MessageBox.Show("BẠN CÓ CHẮN MUỐN KHÔI PHỤC", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                recovery.Recovery("KhoiPhucSV", $"{MSSV_Curr}, '{txtChuongTrinhDaoTao.Text}'");
                LoadData();
                RefreshInput();
            }
        }
        private void btnTraMa_Click(object sender, EventArgs e)
        {
            if (btnTraMa.Text == "Tra mã")
            {
                dataGridView = new DataGridView();
                dgvStudent.Swap(dataGridView, pnlMain, "chuongtrinhdaotao");
                btnTraMa.Text = "Back";
            }    
            else
            {
                dataGridView.Swap(dgvStudent, pnlMain, "sinhvien");
                btnTraMa.Text = "Tra mã";
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(!(new Regex("[^' ']").IsMatch(txtTimKiemSV.Text)))
            {
                MessageBox.Show("VUI LÒNG NHẬP MÃ SINH VIÊN CẦN TÌM KIẾM");
            }
            else if(!txtTimKiemSV.CheckStringIsNumber())
            {
                MessageBox.Show("MSSV KHÔNG CHỨA KÝ TỰ");
            }    
            else if(!find.Find("sinhvien","maSinhVienv = " + txtTimKiemSV.Text + ""))
            {
                if(MessageBox.Show("SINH VIÊN BẠN TÌM KIẾM KHÔNG TỒN TẠI") == DialogResult.OK)
                {
                    txtTimKiemSV.ResetText();
                }       
            }
            else
            {
                LoadData();
                int dgvLenght = dgvStudent.Rows.Count;
                for (int row = 0; row < dgvLenght-1; row++)
                {
                    if(int.Parse(dgvStudent.Rows[row].Cells[0].Value.ToString()) != int.Parse(txtTimKiemSV.Text))
                    {
                        dgvStudent.Rows.RemoveAt(row);
                        dgvLenght--;
                        row--;
                    }
                }
            }
        }

        private void dgvStudentCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cbGioiTinh.Checked = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                txtChuongTrinhDaoTao.Enabled = false;
                DataGridViewRow row = dgvStudent.Rows[e.RowIndex];
                MSSV_Curr = row.Cells[0].Value.ToString();
                txtFullName.Text = row.Cells[1].Value.ToString();
                lbNamNhapHoc.Text = row.Cells[3].Value.ToString();
                dTP_Birthdate.Text = row.Cells[2].Value.ToString();
                txtChuongTrinhDaoTao.Text = row.Cells[4].Value.ToString();
                if(row.Cells[5].Value.ToString() == "True")
                {
                    cbGioiTinh.Checked = true;
                }
                txtEmail.Text = row.Cells[6].Value.ToString().Split("@")[0];
                txtPhoneNumer.Text = row.Cells[7].Value.ToString();
                if (row.Cells[8].Value.ToString().Length > 0)
                    DeletedAccount = true;
                else
                    DeletedAccount = false;
                txtDiachi.Text = row.Cells[9].Value.ToString();
                txtNoisinh.Text = row.Cells[10].Value.ToString();
                txtDantoc.Text = row.Cells[11].Value.ToString();
                txtCCCDorCMND.Text = row.Cells[12].Value.ToString();
                old_CCCD = txtCCCDorCMND.Text;
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            RefreshInput();
        }


    }
}
