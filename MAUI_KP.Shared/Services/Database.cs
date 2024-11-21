using MAUI_KP.Shared.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_KP.Shared.Services
{
    public class Database : DbContext
    {
        #region TABLES

        public DbSet<Employer> Employers { get; set; }

        #endregion

        #region CONSTRUCTOR
        public Database()
        {
            File = Path.Combine("../", "Database.db3");
            Initialize();
        }

        /// <summary>
        /// Constructor for mobile app
        /// </summary>
        /// <param name="filenameWithPath"></param>
        public Database(string filenameWithPath)
        {
            File = filenameWithPath;
            //Console.WriteLine(filenameWithPath);
            Initialize();
        }

        void Initialize()
        {
            if (!Initialized)
            {
                Initialized = true;

                SQLitePCL.Batteries_V2.Init();

                Database.Migrate();
            }
        }

        public static string File { get; protected set; }
        public string WritePath()
        {
            return ($"Filename={Path.Combine("../", "Database.db3")}");
        }
        public static bool Initialized { get; protected set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite($"Filename={File}");
        }

        #endregion

        public List<Employer> GetEmployers()
        {
            return Employers.ToList();


        }
        public Employer FindEmployer(string name)
        {
            using (var connection = new SqliteConnection($"Filename={Path.Combine("../", "Database.db3")}"))
            {
                connection.Open();

                var selectCommand = new SqliteCommand
                {
                    Connection = connection,
                    CommandText = "SELECT * FROM Employers WHERE Name = @name"
                };
                selectCommand.Parameters.AddWithValue("@name", name);

                using (var reader = selectCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Employer
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Post = reader.GetString(3),
                            Age = reader.GetInt32(4)
                        };
                    }
                }
            }
            return null; // Если не найден, возвращаем null
        }
        public bool AddEmployer(string name, string surname, string secondname, int age, string post)
        {
            Employer employer = new Employer();
            employer.Name = name;
            employer.Surname = surname;
            employer.SecondName = secondname;
            employer.Post = post;
            employer.Age = age;
            Employers.Add(employer);
            this.SaveChanges();
            return true;
        }
        public bool DeleteEmployer(int id) //Удаление записи
        {
            using (var connection = new SqliteConnection($"Filename={Path.Combine("../", "Database.db3")}"))
            {
                connection.Open();

                // Выполняем команду удаления
                var deleteCommand = new SqliteCommand
                {
                    Connection = connection,
                    CommandText = "DELETE FROM Employers WHERE Id = @Id"
                };
                deleteCommand.Parameters.AddWithValue("@Id", id);

                // Проверяем количество удаленных строк
                int affectedRows = deleteCommand.ExecuteNonQuery();

                // Если строка была удалена, возвращаем true
                return affectedRows > 0;
            }
        }

        public void Reload()
        {
            Database.CloseConnection();
            Database.OpenConnection();
        }
    }
}
