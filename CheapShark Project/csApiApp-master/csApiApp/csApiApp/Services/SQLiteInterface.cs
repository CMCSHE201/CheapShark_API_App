using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;

// Uses sqlite-net-pcl
using SQLite;
using csApiApp.Models;
using System.Diagnostics;

namespace csApiApp.Services
{
    public class SQLiteInterface
    {
        // Set the path of the database to the local app data folder.
        private string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "csApiApp.db3");

        public SQLiteInterface()
        {
            // Create the database if it doesn't exist.
            CreateDatabase();
            Debug.WriteLine($"Database path: {dbPath}");
        }

        public void CreateDatabase()
        {
            // Create the database if it doesn't exist.
            if (!File.Exists(dbPath))
            {
                using (var db = new SQLiteConnection(dbPath))
                {
                    db.CreateTable<Store>();
                }
            }
        }

        public void AddStore(Store store)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                db.InsertOrReplace(store);
            }
        }

        public void AddStores(List<Store> stores)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                db.InsertAll(stores);
            }
        }

        public List<Store> GetStores()
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                return db.Table<Store>().ToList();
            }
        }
    }
}