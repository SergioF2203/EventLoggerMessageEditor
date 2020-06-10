using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DAL.Models;
using DAL.Repository;

namespace TestDbConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter num of a table: ");
            var numTable = Console.ReadLine();

            DbClass.OpenConnection();

            DataModify.FillDataFromDb(Int32.Parse(numTable));

            //DbClass.sql = $"SELECT * FROM EL_Msg_{numTable}";
            ////DbClass.sql = "SELECT [Address], [Line1] FROM EL_Events.dbo.EL_Msg_2 WHERE [Event] = 32";
            //DbClass.cmd.CommandType = System.Data.CommandType.Text;
            //DbClass.cmd.CommandText = DbClass.sql;

            try
            {
                DbClass.sql = "UPDATE EL_Events.dbo.EL_Msg_2 SET Sys_ID = @Sys_ID WHERE Event = @Event";
                DbClass.da.UpdateCommand = new SqlCommand(DbClass.sql);
                DbClass.da.UpdateCommand.Parameters.Add("@Sys_ID", SqlDbType.SmallInt, 2, "Sys_ID");
                SqlParameter sqlParameter = DbClass.da.UpdateCommand.Parameters.Add("@Event", SqlDbType.SmallInt);
                sqlParameter.SourceColumn = "Event";
                sqlParameter.SourceVersion = DataRowVersion.Original;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            DbClass.CloseConnection();


            // GET A RECORD BY ID

            //Console.WriteLine("input event: ");
            //short ev = short.Parse(Console.ReadLine());
            //DataModify.GetRecordByEevent(ev);

            //*************************

            // ADD ENTRY TO THE TABLE

            var eventEntity = new EventEntity();
            eventEntity.Sys_ID = 7777;
            eventEntity.Group = 7;
            eventEntity.Event = 678;
            eventEntity.Line1 = "test1";
            eventEntity.Line2 = "test2";
            eventEntity.Line3 = "test3";
            eventEntity.Line4 = "test4";

            var newRow = DbClass.ds.Tables[0].NewRow();
            newRow[0] = eventEntity.Sys_ID;
            newRow[1] = eventEntity.Group;
            newRow[2] = eventEntity.Event;
            newRow[3] = eventEntity.Address;
            newRow[4] = eventEntity.Tag;
            newRow[5] = eventEntity.Line1;
            newRow[6] = eventEntity.Line2;
            newRow[7] = eventEntity.Line3;
            newRow[8] = eventEntity.Line4;
            newRow[9] = eventEntity.PicFile;
            newRow[10] = eventEntity.DocFile;

            DbClass.ds.Tables[0].Rows.Add(newRow);

            //*************************

            //DbClass.dt.Rows[0].BeginEdit();
            //DbClass.ds.Tables["Events"].Rows[0][0] = 3111;
            //DbClass.dt.Rows[0].EndEdit();
            //Console.WriteLine(DbClass.dt.Rows[0].RowState);
            //DbClass.da.SelectCommand = DbClass.cmd;
            //SqlCommandBuilder sqlComDuilde = new SqlCommandBuilder(DbClass.da);

            //DbClass.OpenConnection();

            //DbClass.da.Update(DbClass.ds, "Events");





            foreach (DataRow item in DbClass.ds.Tables["Events"].Rows)
            {
                var cells = item.ItemArray;
                foreach (var cell in cells)
                {
                    Console.Write(cell + " ");
                }
                Console.WriteLine();

            }



        }
    }
}
