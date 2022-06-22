using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollStudentsInSchool_
{
    class OverdueAccount : MyExecuteNonQuery
    {
        public void Load()
        {
            ExecutenQuery("EXEC del_update");
        }
    }
}
