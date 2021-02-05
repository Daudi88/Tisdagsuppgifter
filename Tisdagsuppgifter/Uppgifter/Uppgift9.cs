using System;
using System.Collections.Generic;
using System.Text;

namespace Tisdagsuppgifter.Uppgifter
{
    class Uppgift9
    {
        public static void Run()
        {
            var crud = new CRUD();
            var david = new Person
            {
                FirstName = "David",
                LastName = "Ström",
                Address = "Vigelsjövägen 22A",
                City = "Norrtälje",
                Age = 32
            };
            crud.Create(david);
        }

        public static void Run2()
        {
            var crud = new CRUD();
            var person = crud.Read("ström");
            Console.WriteLine(person.Address);
            Console.ReadLine();
        }
    }
}
