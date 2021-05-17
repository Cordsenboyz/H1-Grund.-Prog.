using System;
using System.Data.SQLite;
using System.Data;

namespace Grundlæggende_Programmering_Aflevering
{
    class Program : SQLconnection
    {
        //Adds an ITEM in to the database look in "Firma" class under Addvare Method for more info
        static private void AddData(Firma P)
        {
            Console.Clear();
            Console.WriteLine(" _______________________________ ");
            Console.WriteLine("| Navn:                         |");
            Console.WriteLine("| Pris:                         |");
            Console.WriteLine("| Antal:                        |");
            Console.WriteLine("|_______________________________|");
            Console.SetCursorPosition(8, 1);
            string varenavn = Console.ReadLine();
            Console.SetCursorPosition(8, 2);
            string prisstr = Console.ReadLine();
            double pris = Double.Parse(prisstr);
            Console.SetCursorPosition(9, 3);
            int antal = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition(0, 5);
            Vare V = new Vare(varenavn, pris, antal);
            P.AddVare(V);
            Console.WriteLine("Succesfully Inserted Item into Database");
            Console.Write("Press any key to continue...");
            Console.ReadLine();
            Menu(P);
        }
        //Adds a placement for an item in the database
        static private void AddPlacering(Firma P)
        {
            Console.Clear();
            string selectquery = $"SELECT id, navn FROM Vare";
            DataTable dataTable = new DataTable();
            dataTable = Select(selectquery);
            foreach (DataRow row in dataTable.Rows)
            {
                string placeringstring = string.Format("ID: {0} | Navn: {1}", row.ItemArray);
                Console.WriteLine(placeringstring);
            }
            string userinput = Console.ReadLine();
            bool errorCheck = int.TryParse(userinput, out int result);
            if (errorCheck)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (Convert.ToInt32(row.ItemArray[0]) == result)
                    {
                        Console.Clear();
                        Console.WriteLine(" _______________________________ ");
                        Console.WriteLine("| Hylde:                        |");
                        Console.WriteLine("| Plads:                        |");
                        Console.WriteLine("|_______________________________|");
                        Console.SetCursorPosition(9, 1);
                        string hylde = Console.ReadLine();
                        Console.SetCursorPosition(9, 2);
                        double plads = Convert.ToDouble(Console.ReadLine());
                        Insert($"INSERT INTO Placering (hylde, plads, vare) VALUES ('{hylde}','{plads}','{result}')");
                        break;
                    }
                }
            }
            Menu(P);
        }
        //Deletes data from the database and lists the ID and NAME of the current items in the database so you can give it an ID to
        //delete the wanted items
        static private void DeleteData(Firma P)
        {
            Console.Clear();
            string selectquery = $"SELECT id, navn FROM Vare";
            DataTable dataTable = new DataTable();
            dataTable = Select(selectquery);
            foreach (DataRow row in dataTable.Rows)
            {
                string deletestring = string.Format("ID: {0} | Navn: {1}", row.ItemArray);
                Console.WriteLine(deletestring);
            }
            Console.WriteLine("Write the ID number of the item you want removed");
            string userinput = Console.ReadLine();
            bool errorCheck = int.TryParse(userinput, out int result);
            if (errorCheck)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (Convert.ToInt32(row.ItemArray[0]) == result)
                    {
                        Insert($"DELETE FROM Vare WHERE id = {result}");
                        break;
                    }
                }
            }
            Menu(P);
        }
        //Displays the Current Data about the ITEMS in the database using the SELECT method in the SQLconnection Class
        static private void SelectData(Firma P)
        {
            Console.Clear();
            string selectquery = $"SELECT * FROM selectquery";
            DataTable dataTable = new DataTable();
            dataTable = Select(selectquery);
            foreach (DataRow row in dataTable.Rows)
            {
                string selectstring = string.Format("ID: {0} | Navn: {1} | Pris: {2} | Antal: {3} | Hylde: {4} | Plads: {5}", row.ItemArray);
                Console.WriteLine(selectstring);
            }
            Console.ReadKey();
            Menu(P);
        }
        //updates the data of an ITEM in the database it also displays the current ITEMS in the database so you can provide a ID for updating
        //using the Insert Method in the SQLconnection Class
        static private void UpdateData(Firma P)
        {
            Console.Clear();
            string selectquery = $"SELECT id, navn FROM Vare";
            DataTable dataTable = new DataTable();
            dataTable = Select(selectquery);
            foreach (DataRow row in dataTable.Rows)
            {
                string updatestring = string.Format("ID: {0} | Navn: {1}", row.ItemArray);
                Console.WriteLine(updatestring);
            }
            Console.WriteLine("Write the ID number of the item you want updated");
            string userinput = Console.ReadLine();
            bool errorCheck = int.TryParse(userinput, out int result);
            if (errorCheck)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (Convert.ToInt32(row.ItemArray[0]) == result)
                    {
                        Console.Clear();
                        Console.WriteLine(" _______________________________ ");
                        Console.WriteLine("| Navn:                         |");
                        Console.WriteLine("| Pris:                         |");
                        Console.WriteLine("| Antal:                        |");
                        Console.WriteLine("|_______________________________|");
                        Console.SetCursorPosition(8, 1);
                        string varenavn = Console.ReadLine();
                        Console.SetCursorPosition(8, 2);
                        double pris = Convert.ToDouble(Console.ReadLine());
                        Console.SetCursorPosition(9, 3);
                        int antal = Convert.ToInt32(Console.ReadLine());
                        Insert($"UPDATE Vare SET navn ='{varenavn}', pris = '{pris}', stock = '{antal}' WHERE id = {result}");
                        break;
                    }
                }
            }
            Menu(P);
        }
        //Menu Method called by main just for making it able to return too this method and not have to close the program down
        //switch case to make sure the user is giving a valid input
        static private void Menu(Firma firma)
        {
            Console.Clear();
            Console.WriteLine(" _________________ ");
            Console.WriteLine("| 1. Insert       |");
            Console.WriteLine("| 2. Placering    |");
            Console.WriteLine("| 3. Delete       |");
            Console.WriteLine("| 4. Select       |");
            Console.WriteLine("| 5. Update       |");
            Console.WriteLine("| 6. Exit         |");
            Console.WriteLine("|_________________|");
            Console.Write(">");
            ConsoleKeyInfo menuChoice = Console.ReadKey(true);
            bool errorCheck = int.TryParse(menuChoice.KeyChar.ToString(), out int result);
            if (errorCheck == true && result < 7 && result > 0)
            {
                switch (result)
                {
                    case 1:
                        {
                            AddData(firma);
                            break;
                        }
                    case 2:
                        {
                            AddPlacering(firma);
                            break;
                        }
                    case 3:
                        {
                            DeleteData(firma);
                            break;
                        }
                    case 4:
                        {
                            SelectData(firma);
                            break;
                        }                        
                    case 5:
                        {
                            UpdateData(firma);
                            break;
                        }                    
                    case 6:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }

        static void Main(string[] args)
        {
            Firma firma = new Firma();
            Menu(firma);
            

            Console.ReadKey();
        }
    }
}