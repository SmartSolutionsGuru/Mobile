using SQLite;

namespace SmartSolutions.Mobile.Database
{
    public class InventoryControlDb
    {
        public static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<InventoryControlDb> Instance = new AsyncLazy<InventoryControlDb>(async () =>
        {
            var instance = new InventoryControlDb();
            //CreateTableResult result = await Database.CreateTableAsync<TodoItem>();
            return instance;
        });

        public InventoryControlDb()
        {
            Database = new SQLiteAsyncConnection(DbConstants.DatabasePath, DbConstants.Flags);
        }


    }
}
