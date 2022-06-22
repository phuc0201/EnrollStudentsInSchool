using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnrollStudentsInSchool_
{
    public partial class GUI_Admin : Form
    {
        public GUI_Admin()
        {
            InitializeComponent();
            pnlMaincontrols.SetDoubleBuffered();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            FStudent fstd = new FStudent();
            MainControls.Show(fstd, pnlMaincontrols, fstd.dgvStudent);
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            FStaff fStaff = new FStaff();
            MainControls.Show(fStaff, pnlMaincontrols, fStaff.dgvStaff);
        }

        private void btnMonhoc_Click(object sender, EventArgs e)
        {
            FMonHoc fmh = new FMonHoc();
            MainControls.Show(fmh, pnlMaincontrols, fmh.dgvMonhoc);
        }

        private void btnChuongTrinhDaoTao_Click(object sender, EventArgs e)
        {
            FChuongTrinhDaoTao fChuongTrinhDaoTao = new FChuongTrinhDaoTao();
            MainControls.Show(fChuongTrinhDaoTao, pnlMaincontrols, fChuongTrinhDaoTao.dgvChuongTrinhDaoTao);
        }

        private void btnLopHocPhan_Click(object sender, EventArgs e)
        {
            FLopHocPhan fLopHocPhan = new FLopHocPhan();
            MainControls.Show(fLopHocPhan, pnlMaincontrols, fLopHocPhan.dgvLopHocPhan);
        }
        private void btnUserAccount_Click(object sender, EventArgs e)
        {
            FUserAccount fUserAccount = new FUserAccount();
            MainControls.Show(fUserAccount, pnlMaincontrols, fUserAccount.dgvUserAccount);
        }
        private void HomeClick(object sender, EventArgs e)
        {
            pnlMaincontrols.Controls.Clear();
        }

        private void btnPhanBoLop_Click(object sender, EventArgs e)
        {
            FPhanBoLop fPhanBoLop = new FPhanBoLop();
            MainControls.Show(fPhanBoLop, pnlMaincontrols, fPhanBoLop.dgvPhanBoLop);
        }
    }
}
