using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace EnrollStudentsInSchool_
{
    class GetColumnNames : MyExecuteNonQuery
    {
        public List<string> getColumnNames(string TableName)
        {
            List<string> columnNames = new List<string>();
            try
            {
                ConnectSql();
                SqlDataAdapter da = new SqlDataAdapter($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{TableName}'", sqlConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                sqlConnection.Close();
                for(int row = 0; row < dt.Rows.Count; row ++)
                {
                    columnNames.Add(dt.Rows[row][0].ToString());
                }
            }
            catch
            {
                MessageBox.Show("LẤY TÊN CỘT LỖI");
            }
            return columnNames;
        }
    }
}
