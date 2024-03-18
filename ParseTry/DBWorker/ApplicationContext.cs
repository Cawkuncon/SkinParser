using Microsoft.EntityFrameworkCore;
using ParseTry.BuffParser;
using ParseTry.Main;
using ParseTry.MarketParser;

namespace ParseTry.DBWorker
{
    //контекст БД
    public class ApplicationContext : DbContext
    {
        //Таблица скинов
        public DbSet<ItemMarket> Items { get; set; }
        public DbSet<ItemBuff> BuffItems { get; set; }
        public DbSet<ResultItem> ResultItems { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        //Конфигурирование БД
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Skins;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
