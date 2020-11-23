using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace sqlite5
{
    class Program
    {

        static void Main(string[] args)
        {
            Program p = new Program();
            SQLiteConnection Connect = new SQLiteConnection(@"Data Source=C:\Users\Root\kr1.db; Version=3;");
            p.ShowV(Connect);
            //string commandTextDelete = "DELETE FROM LIKARI WHERE @lik_id = 5";

            
            //SQLiteCommand CommandDelete = new SQLiteCommand(commandTextDelete, Connect);
           
            Console.ReadKey();
            
           
        }

        void ShowV(SQLiteConnection Connect)
        {
            string commandText = "SELECT prizv FROM LIKARI WHERE lik_id = 3";
            SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
            Connect.Open();
            Console.WriteLine(Command.ExecuteScalar());
            Connect.Close();
        }
    }
}
