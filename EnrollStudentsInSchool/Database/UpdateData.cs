using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace EnrollStudentsInSchool_
{
    class UpdateData : MyExecuteNonQuery
    {
        GetColumnNames getColumnNames = new GetColumnNames();
        public void Update(string Mssv, string hoten, string ngaySinh, string NamNhapHoc, string MaCTDT, string gioitinh, string email, string sdt, string ngayxoa, string diachi, string noisinh,
            string dantoc, string CCCD)
        {
            string query = $"EXEC update_sv {Mssv}, N'{hoten}', '{ngaySinh}', {NamNhapHoc}, '{MaCTDT}', {gioitinh}, '{email}', '{sdt}', NULL, N'{diachi}', N'{noisinh}', N'{dantoc}', '{CCCD}'";
            ExecutenQuery(query);
        }
        public void Update(int startpos, string TableName, List<string> componentOfTable, string condition)
        {
            string query = "";
            for(int component = startpos; component < componentOfTable.Count; component++)
            {
                query += getColumnNames.getColumnNames(TableName)[component] + " = " + componentOfTable[component] + ",";
            }
            query = query.Remove(query.Length - 1);
            ExecutenQuery($"UPDATE {TableName} SET {query} WHERE {condition}");
        }
        public void Update(string TableName, string strUpdate, string condition)
        {
            string query = $"UPDATE {TableName} SET {strUpdate} where {condition}";
            ExecutenQuery(query);
        }
    }
}

/*
 * UPDATE table_name SET column1 = value1, column2 = value2, ... WHERE condition;
 * 
 */