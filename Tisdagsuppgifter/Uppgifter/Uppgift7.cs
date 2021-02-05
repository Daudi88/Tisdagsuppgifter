namespace Tisdagsuppgifter.Uppgifter
{
    internal class Uppgift7
    {
        private static SQLDatabase db = new SQLDatabase("Animals");

        public static void Run()
        {
            var db = new SQLDatabase();
            var sql = "CREATE DATABASE Humans";
            db.ExecuteSQL(sql);
        }

        public static void Run2()
        {
            var sql = @"CREATE TABLE People (
                        ID int PRIMARY KEY IDENTITY (1,1),
                        firstName nvarchar(50),
                        lastName nvarchar(50),
                        address nvarchar(100),
                        city nvarchar(50),
                        shoeSize int
                        )";
            db.ExecuteSQL(sql);
        }

        public static void Run3()
        {
            db.ExecuteSQL("ALTER TABLE People ADD age int");
        }

        public static void Run4()
        {
            db.ExecuteSQL("ALTER TABLE People DROP COLUMN shoeSize");
        }

        public static void CreateDatabase()
        {
            db.CreateDatabase("Animals");
        }

        public static void CreateTable()
        {
            var sql = "Id int PRIMARY KEY IDENTITY (1,1), Name nvarchar(50)";
            db.DatabaseName = "Cars";
            db.CreateTable("Volvos", sql);
        }

        public static void AlterTable()
        {
            var db = new SQLDatabase("Animals");
            db.RenameColumn("Dogs", "Bark", "Voff");
        }

        public static void DropDatabase()
        {
            var db = new SQLDatabase();
            db.DropDatabase("Cars");
        }

        public static void DropTable()
        {
            var db = new SQLDatabase("Cars");
            db.DropTable("Volvos");
        }
    }
}