using System;

namespace Tisdagsuppgifter.Uppgifter
{
    internal class Uppgift6
    {
        public static void Run()
        {
            var db = new SQLDatabase();
            var list = db.GetDatabases();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}