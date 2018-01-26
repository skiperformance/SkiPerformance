using Ski.Data.Entities;
using SQLite;
using System;
using System.IO;

namespace Ski.Data
{
    public sealed class DataEntryPoint
    {
        private static volatile DataEntryPoint instance;
        private static object syncRoot = new Object();
        SQLiteConnection _db;
        public static DataEntryPoint Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DataEntryPoint();
                    }
                }

                return instance;
            }
        }
        private DataEntryPoint()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");

            if (_db == null)
            {
                _db = new SQLiteConnection(dbPath);
            }

            _db.CreateTable<Stay>();
        }



        public void InsertStay(Stay newStay)
        {
            _db.Insert(newStay);           
        }

        public TableQuery<Stay> GetAllStays()
        {
            return _db.Table<Stay>();
        }
    }
}
