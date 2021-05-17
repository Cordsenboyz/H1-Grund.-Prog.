using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace Grundlæggende_Programmering_Aflevering
{
    public class SQLconnection
    {
        //Connection string that connects to the SQLite database in the Currentdirectory Being this projects folder
        private static readonly string connectionString = $@"Data Source={Environment.CurrentDirectory}\GrundlæggendeProgAflevering.db";
        //Insert method used too insert or update data in the database 
        public static bool Insert(string SQLquery)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SQLiteCommand SQLcom = new SQLiteCommand(SQLquery, con);
                    SQLcom.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (SQLiteException X)
                {
                    Console.WriteLine(X);
                    try
                    {
                        con.Close();
                        return false;
                    }
                    catch(SQLiteException C) 
                    {
                        Console.WriteLine(C);
                        return false;
                    }
                }
            }
        }
        //Select method used to display data from the database in the console with some exception handling
        //so the user knows what went wrong
        public static DataTable Select(string selectquery)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SQLiteDataAdapter SQLAdapt = new SQLiteDataAdapter(selectquery, con);
                    DataTable dataTable = new DataTable();
                    SQLAdapt.Fill(dataTable);
                    con.Close();
                    return dataTable;
                }
                catch (SQLiteException X)
                {
                    Console.WriteLine(X);
                    try
                    {
                        con.Close();
                        return null;
                    }
                    catch (SQLiteException C)
                    {
                        Console.WriteLine(C);
                        return null;
                    }
                }
            }
        }
    }
}
