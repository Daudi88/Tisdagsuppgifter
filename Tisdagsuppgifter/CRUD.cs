using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Tisdagsuppgifter
{
    class CRUD
    {
        public void Create(Person person)
        {
            var db = new SQLDatabase("Population");

            var sql = @"INSERT People (firstName, lastName, address, city, age) 
                        VALUES (@f_name, @l_name, @address, @city, @age)";

            var parameters = new (string, string)[]
            {
                ("@f_name", person.FirstName),
                ("@l_name", person.LastName),
                ("@address", person.Address),
                ("@city", person.City),
                ("@age", person.Age.ToString())
            };

            db.ExecuteSQL(sql, parameters);
        }

        public Person Read(string name)
        {
            var db = new SQLDatabase("Population");
            var person = new Person();
            var dt = new DataTable();
            if (name.Contains(" "))
            {
                var names = name.Split(" ");
                var sql = "SELECT * FROM People WHERE firstName LIKE @f_name AND lastName LIKE @l_name";
                dt = db.GetDataTable(sql, ("@f_name", names[0]), ("@l_name", names[^1]));
            }
            else
            {
                var sql = "SELECT * FROM People WHERE firstName LIKE @name OR lastName LIKE @name";
                dt = db.GetDataTable(sql, ("@name", name));
            }
            foreach (DataRow row in dt.Rows)
            {
                person = GetPerson(row);
            }
            return person;
        }

        private Person GetPerson(DataRow row)
        {
            return new Person
            {
                Id = (int)row["Id"],
                FirstName = row["firstName"].ToString(),
                LastName = row["lastName"].ToString(),
                Address = row["address"].ToString(),
                City = row["city"].ToString(),
                Age = (int)row["age"]
            };
        }

        public void Update(Person person)
        {

        }

        public void Delete(Person person)
        {

        }
    }
}
