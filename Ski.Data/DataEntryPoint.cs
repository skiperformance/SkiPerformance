using Ski.Data.Entities;
using SQLite;
using System;
using System.IO;
using System.Linq;

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
            _db.CreateTable<Run>();
        }



        public int InsertStay(Stay newStay)
        {
            return _db.Insert(newStay);
        }

        public TableQuery<Stay> GetAllStays()
        {
            var stays = _db.Table<Stay>();
            //var runs = _db.Table<Run>();
            //foreach (var stay in stays)
            //{
            //    var currentRuns = runs.Where(r => r.StayId == stay.Id);
            //    stay.Runs = currentRuns.ToList();
            //}
            return stays;
        }

        public void InsertRun(Run newRun)
        {
            _db.Insert(newRun);
        }

        public TableQuery<Run> GetRuns(int stayId)
        {
            return _db.Table<Run>().Where(r => r.StayId == stayId);
        }

        public void DeleteStay(int stayId)
        {
            _db.Delete<Stay>(stayId);

            var runsToDelete = GetRuns(stayId);
            foreach (var item in runsToDelete)
            {
                _db.Delete<Run>(item.Id);
            }
        }
    }
}
