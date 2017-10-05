namespace glovia_obic7.Infrastructure
{
    class DataContext : SqliteContext
    {
        public DataContext() : base("Data Source = convert.db")
        {
        }

        public static DataContext Create()
        {
            return new DataContext();
        }
    }
}
