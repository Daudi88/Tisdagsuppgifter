using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Tisdagsuppgifter.Uppgifter
{
    class Uppgift4
    {
        public static void Run()
        {
            var db = new SQLDatabase();
            var sql = "SELECT physical_name, size FROM sys.database_files";
            var dt = db.GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["physical_name"]}, );
            }
        }
    }
}
