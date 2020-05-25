using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CustomApp
{
    class Menu
    {
        public static void NewNote()
        {
            string option;
            do
            {
                Console.WriteLine("What would you like to add to the note? (maximum of 254 characters)");
                option = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(option) || option.Length > 254);
            string option2;
            DateTime date;
            do
            {
                Console.WriteLine("When was this note created? (date format only)");
                option2 = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(option2) || !DateTime.TryParse(option2, out date));
            //Initiates a MySQL connection and executes a MySQL command to insert data into a table
            _ = new Database(Program.cs);
            MySqlCommand comm = Database.con.CreateCommand();
            comm.CommandText = "INSERT INTO totalNotes(userID,noteDate,noteText) VALUES(@userID, @noteDate, @noteText)";
            comm.Parameters.AddWithValue("@noteDate", date);
            comm.Parameters.AddWithValue("@noteText", option);
            comm.Parameters.AddWithValue("@userID", 1);
            comm.ExecuteNonQuery();
            Database.con.Close();
            Console.WriteLine("The note was successfully added to the database!");
        }
        public static void ReadNote()
        {
            string option;
            DateTime date;
            do
            {
                Console.WriteLine("When was this note created? (date format only)");
                option = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(option) || !DateTime.TryParse(option, out date));
            //Initiates a MySQL connection and executes a MySQL command to search for columns in a table
            DataTable dt = new DataTable();
            _ = new Database(Program.cs);
            using (MySqlCommand cmd = new MySqlCommand("select * from totalNotes where noteDate = @notedate", Database.con))
            {
                cmd.Parameters.AddWithValue("@notedate", date);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["noteID"].ToString() + " " + reader["noteText"].ToString() + " " + reader["noteDate"].ToString());
                }
                Database.con.Close();
            }
        }
    }
}
