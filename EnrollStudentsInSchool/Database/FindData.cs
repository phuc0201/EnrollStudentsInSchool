using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace EnrollStudentsInSchool_
{
    class FindData : MyExecuteNonQuery
    {
        public FindData()
        {
        }
        public bool Find(string TableName, string value)
        {
            string query = $"SELECT * FROM {TableName} WHERE {value}";
            try
            {
                ConnectSql();
                sqlCmd = new SqlCommand(query, sqlConnection);
                dataReader = sqlCmd.ExecuteReader();
                if (dataReader.Read() == true)
                    return true;
                sqlConnection.Close();
            }
            catch
            {
                MessageBox.Show("LỖI TIỀM KIẾM DỮ LIỆU");
            }
         
            return false;
        }
 /*       public bool FindAccount(string UserName, string Password)
        {
            string query = $"Select * from nguoidung where tenNguoiDung = '" + UserName + "' and matKhau = '" + Password + "'";
            string queryAdmin = $"Select * from AdminAccount where Email = '" + UserName + "' and PassW = '" + Password + "'";
            if (Find(queryAdmin))
            {
                return true;
            }
            if (Find(query))
            {
                return true;
            }
            return false;
        }*/
    }
}
