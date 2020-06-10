using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DAL.Models;

namespace DAL.Repository
{
    public class DataModify
    {

        public static void FillDataFromDb(int _tableNumber)
        {
            DbClass.sql = $"SELECT * FROM EL_Msg_{_tableNumber}";
            DbClass.cmd.CommandType = System.Data.CommandType.Text;
            DbClass.cmd.CommandText = DbClass.sql;

            try
            {
                DbClass.da = new SqlDataAdapter(DbClass.cmd);
                DbClass.ds = new DataSet();
                DbClass.da.Fill(DbClass.ds, "Events");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static EventEntity GetRecordByEevent(int _event)
        {
            EventEntity eventEntity = new EventEntity();

            if (DbClass.ds != null)
            {
                foreach (DataRow item in DbClass.ds.Tables[0].Rows)
                {
                    if ((short)item.ItemArray[2] == _event)
                    {
                        eventEntity.Sys_ID = (short)item.ItemArray[0];
                        eventEntity.Group = (short)item.ItemArray[1];
                        eventEntity.Event = (short)item.ItemArray[2];
                        eventEntity.Address = (string)item.ItemArray[3];
                        eventEntity.Tag = (string)item.ItemArray[4];
                        eventEntity.Line1 = (string)item.ItemArray[5];
                        eventEntity.Line2 = (string)item.ItemArray[6];
                        eventEntity.Line3 = (string)item.ItemArray[7];
                        eventEntity.Line4 = (string)item.ItemArray[8];
                        eventEntity.PicFile = (string)item.ItemArray[9];
                        eventEntity.DocFile = (string)item.ItemArray[10];
                    }
                }
            }

            return eventEntity;
        }

        public static void AddNewEvent(EventEntity _eventEntity)
        {
            if (_eventEntity != null)
            {
                var newRow = DbClass.ds.Tables[0].NewRow();
                newRow[0] = _eventEntity.Sys_ID;
                newRow[1] = _eventEntity.Group;
                newRow[2] = _eventEntity.Event;
                newRow[3] = _eventEntity.Address;
                newRow[4] = _eventEntity.Tag;
                newRow[5] = _eventEntity.Line1;
                newRow[6] = _eventEntity.Line2;
                newRow[7] = _eventEntity.Line3;
                newRow[8] = _eventEntity.Line4;
                newRow[9] = _eventEntity.PicFile;
                newRow[10] = _eventEntity.DocFile;

                DbClass.ds.Tables[0].Rows.Add(newRow);
            }
        }

        public static void UpdateEvent(EventEntity _eventEntity)
        {
            throw new NotImplementedException();
        }

        public static int GetTableGroupRecordsCount(int _groupNumber)
        {
            var count = 0;

            if (DbClass.ds != null)
            {
                foreach (DataRow item in DbClass.ds.Tables[0].Rows)
                {
                    if ((short)item.ItemArray[1] == _groupNumber)
                        count++;
                }
            }

            return count;
        }

        public static void SaveChangesToDb(string _tableName)
        {
            throw new NotImplementedException();
        }
    }
}
