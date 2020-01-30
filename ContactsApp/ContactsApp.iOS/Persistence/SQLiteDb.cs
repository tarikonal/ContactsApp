using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using ContactsApp.Persistence;
using SQLite;
using Environment = System.Environment;
using System.IO;
using Xamarin.Forms;
using ContactsApp.iOS;

[assembly: Dependency(typeof(SQLiteDb))]
namespace ContactsApp.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}