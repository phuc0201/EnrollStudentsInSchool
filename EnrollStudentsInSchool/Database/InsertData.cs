using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollStudentsInSchool_
{
    class InsertData : MyExecuteNonQuery
    {
        public void Insert(string Ten, string NgaySinh, string Namhoc, string maCTDT, string gioitinh, string email, string sdt, string diachi, string noisinh,
            string dantoc, string soCCCD)
        {
            string query = $"EXEC register_sv N'{Ten}', '{NgaySinh}', {Namhoc}, '{maCTDT}', {gioitinh}, '{email}', '{sdt}', NULL, N'{diachi}', N'{noisinh}', N'{dantoc}', '{soCCCD}'";
            ExecutenQuery(query);
        }
        public void Insert(List<string> componentOfTable)
        {
            string query = $"EXEC register_nv ";
            for (int component = 0; component < componentOfTable.Count; component++)
            {
                query += componentOfTable[component] + ",";
            }
            query = query.Remove(query.Length - 1);
            ExecutenQuery(query);
        }
        public void Insert(string TableName, List<string> componentOfTable)
        {
            string query = "";
            for (int component = 0; component < componentOfTable.Count; component++)
            {
                query += componentOfTable[component] + ",";
            }
            query = query.Remove(query.Length - 1);
            ExecutenQuery($"INSERT INTO {TableName} VALUES ({query})");
        }
    }
}