using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace EnrollStudentsInSchool_
{
    public static class DataGridViewSwap
    {       
        public static void Swap(this DataGridView dgv1, DataGridView dgv2, Panel pnlMain, string TableName)
        {
            MyExecuteNonQuery myExecuteNonQuery = new MyExecuteNonQuery();
            dgv2.Location = new Point(dgv1.Location.X, dgv1.Location.Y);
            dgv2.Height = dgv1.Height;
            dgv2.Width = dgv1.Width;
            pnlMain.Controls.Remove(dgv1);
            pnlMain.Controls.Add(dgv2);
            myExecuteNonQuery.LoadData(dgv2, TableName);
            ResizeDatagridview.AutoResize(dgv2);
        }
    }
}
