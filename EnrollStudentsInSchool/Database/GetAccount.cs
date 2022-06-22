using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace EnrollStudentsInSchool_
{
    class GetAccount : MyExecuteNonQuery
    {
        public string CheckAccountExists(string UserName, string PassWord, string position)
        {
            string str = "";
            try
            {
                ConnectSql();
                sqlCmd = new SqlCommand($"SELECT  dbo.LoginFunction('{UserName}', '{PassWord}', {position})", sqlConnection);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                str = dt.Rows[0][0].ToString();
            }
            catch
            {
                MessageBox.Show("LỖI KIỂM TRA TÀI KHOẢN TỒN TẠI");
            }
            return str;
        }
        public void Get()
        {
            //if()
        }
    }
}
