using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPU221_1.Model;

namespace WPU221_1
{
    class AppContext : DbContext
    {
        public AppContext()
        {
            //Database.EnsureDeleted(); //Удаляет базу с указанным названием
            Database.EnsureCreated(); //Создает базу с указанным названием
        }
        //Класс сущностей: сколько таблиц в базе данных, столько же строк с сущностями
        public DbSet<Note> Notes { get; set; } = null!;

        //Класс отвечает за установку параметров подключения
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=AGREAT\\SQLEXPRESS;Initial Catalog=SimplyNote;Integrated Security=True;Trust Server Certificate=True;");
        }
    }
}
