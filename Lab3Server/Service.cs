using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//using Microsoft.Data.Sqlite;
using SQLite;

namespace WcfServiceLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Lab3Service : ILab3Service
    {
        static List<Row> rows;

        List<Row> ReadData()
        {
            List<Row> rows = new List<Row>();
            //SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            using (var connection = new SQLiteConnection("C:\\Users\\Пользователь\\Desktop\\bd.sqlite"))
            {
                //var command = connection.CreateCommand(@"
                //                SELECT *
                //                FROM nenorm;");
                //command.CommandText = @"
                //                SELECT *
                //                FROM nenorm;";

                var rowss = connection.Table<Row>();

                foreach (var r in rowss)
                {
                    //Row row = new Row(r.D_name, r.Description, r.P_name, r.Age, r.O_name, r.Phone, r.S_name);
                    //Console.WriteLine($"{r.D_name}, {r.Description}, {r.P_name}, {r.Age}, {r.O_name}, {r.Phone}, {r.S_name}");
                    rows.Add(r);
                }

                //using (var reader = command.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        Row row = new Row(Convert.ToString(reader[0]), Convert.ToString(reader[1]),
                //            Convert.ToString(reader[2]), Convert.ToInt32(reader[3]),
                //            Convert.ToString(reader[4]), Convert.ToString(reader[5]),
                //            Convert.ToString(reader[6]));

                //        rows.Add(row);
                //    }
                //}
            }

            return rows;
        }

        public int GetRowsCount()
        {
            if (rows is null)
            {
                rows = ReadData();
                Console.WriteLine($"\t{rows.Count} rows are read");
            }
            return rows.Count;
        }

        public Row GetRow(int i)
        {
            Console.WriteLine($"\tSending {i} row: {rows[i].D_name}");
            return rows[i];
        }
    }
}
