using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tisdagsuppgifter.Uppgifter
{
    class Uppgift8
    {
        public static void Run()
        {
            var sql = File.ReadAllText(@"C:\Code\.NET20D\Objektorienterad arkitektur\Övningsuppgifter\Tisdagsuppgifter\People.sql");
            var db = new SQLDatabase("Humans");
            db.ExecuteSQL(sql);
        }
    }
}
