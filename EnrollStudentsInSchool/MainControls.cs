using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace EnrollStudentsInSchool_
{
    public class MainControls
    {
        public static void Show(Control control, Control Container, DataGridView dataGridView)
        {
            Show(control, Container);
            ResizeDatagridview.AutoResize(dataGridView);
        }
        public static void Show(Control control, Control Container)
        {
            Container.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.Focus();
            Container.Controls.Add(control);
        }
    }
}
