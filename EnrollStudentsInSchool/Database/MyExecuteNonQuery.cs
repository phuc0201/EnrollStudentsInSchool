using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
namespace EnrollStudentsInSchool_
{
    class MyExecuteNonQuery
    {
        public SqlCommand sqlCmd;
        public SqlDataReader dataReader;
        public SqlConnection sqlConnection;
        public SqlDataAdapter da;
        public DataTable dt;
        public MyExecuteNonQuery()
        {
             ConnectSql();
        }
        public void ConnectSql()
        {
            try
            {
                sqlConnection = Connection.GetSqlConnection();
                sqlConnection.Open();
            }
            catch
            {
                MessageBox.Show("Lỗi kết bối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void LoadData(DataGridView dgv, string TableName)
        {
            try
            {
                da = new SqlDataAdapter("SELECT * FROM " + TableName, sqlConnection);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
                sqlConnection.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không load được data. Lỗi rồi!!!");
            }
        }
        public void ExecutenQuery(string strExeCuteNonQuery)
        {
            ConnectSql();
            try
            {
                sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strExeCuteNonQuery;
                sqlCmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
