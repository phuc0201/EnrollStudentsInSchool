using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollStudentsInSchool_
{
    class DataRecovery : MyExecuteNonQuery
    {
        public void Recovery(string ProcName, string parameters)
        {
            string query = $"EXEC {ProcName} {parameters}";
            ExecutenQuery(query);
        }
        public void Recovery(string TableName,string strUpdate, string condition)
        {
            string query = $"UPDATE {TableName} SET {strUpdate} where {condition}";
            ExecutenQuery(query);
        }
    }
}
