using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollStudentsInSchool_
{
    class DeleteData : MyExecuteNonQuery
    {
        DateTime dtNow = DateTime.Now;
        string Date;
        public DeleteData()
        {
            Date = dtNow.Year.ToString() + "-" + dtNow.Month.ToString() + "-" + dtNow.Day.ToString();
        }
        public void Delete(string id, string TableName, string ColumnsName)
        {
            string query = $"UPDATE {TableName} SET ngayxoa = '{Date}' WHERE {ColumnsName} = {id}";
            ExecutenQuery(query);
        }
        public void Delete(string TableName, string condition)
        {
            string query = $"DELETE FROM {TableName} WHERE {condition}";
            ExecutenQuery(query);
        }
        public void Delete(string condition)
        {
            string query = $"EXEC del_ChuongTrinhDaoTao {condition}, '{Date}'";
            ExecutenQuery(query);
        }
    }
}
