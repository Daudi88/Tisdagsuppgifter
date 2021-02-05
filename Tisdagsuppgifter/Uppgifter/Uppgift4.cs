using System;

namespace Tisdagsuppgifter.Uppgifter
{
    internal class Uppgift4
    {
        public static void Run()
        {
            while (true)
            {
                Console.Write("Ange databas: ");
                var db = new SQLDatabase(Console.ReadLine());
                try
                {
                    var list = db.GetFilePath();
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Felaktig inmatning! Försök igen.");
                }
                finally
                {
                    Console.WriteLine("Kul att du ville testa...");
                }
            }
        }
    }
}