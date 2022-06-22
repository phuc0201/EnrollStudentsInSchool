using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace EnrollStudentsInSchool_
{
    public class ResizeDatagridview
    {
        public static void AutoResize(DataGridView dgv)
        {
            for (int col = 0; col < dgv.Columns.Count; col++)
            {
                dgv.Columns[col].Width = dgv.Width / dgv.Columns.Count;
            }
        }
    }
}