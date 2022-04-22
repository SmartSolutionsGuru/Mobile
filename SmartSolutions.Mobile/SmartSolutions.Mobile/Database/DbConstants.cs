using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SmartSolutions.Mobile.Database
{
    public static class DbConstants
    {
        public const string DbName = "SmartSolutions.InventoryControl.db3";
        // open the database in read/write mode
        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite
                                                    // create the database if it doesn't exist
                                                    | SQLite.SQLiteOpenFlags.Create
                                                    // enable multi-threaded database access
                                                    | SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(basePath, DbName);
            }
        }
    }
}
