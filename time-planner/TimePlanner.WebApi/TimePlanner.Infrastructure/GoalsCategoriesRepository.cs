using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;

namespace TimePlanner.Infrastructure
{
    public class GoalsCategoriesRepository : IGoalCategoriesRepository
    {
        private string connectionStringName = "MainConnectionString";
        IConfiguration configuration;

        public GoalsCategoriesRepository(IConfiguration configuration)
        {
            this.configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<Guid> AddCategory(GoalCategory category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var id = Guid.NewGuid();
            await this.ExecuteNonQueryAsync($"INSERT INTO [GoalsCategories] (id, name) VALUES ('{id}','{category.Name}')");

            return id;
        }

        public async Task DeleteCategory(Guid id)
        {
            var existing = (await this.ExecuteQueryAsync($"SELECT * FROM [GoalsCategories] WHERE id='{id}'"))
                .FirstOrDefault();

            if (existing == null)
                throw new NotImplementedException("Заменить на нормальную обработку отсутствия");

            await this.ExecuteNonQueryAsync($"DELETE FROM [GoalsCategories] WHERE id='{id}'");
        }

        public async Task EditCategory(GoalCategory category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var existing = (await this.ExecuteQueryAsync($"SELECT * FROM [GoalsCategories] WHERE id='{category.Id}'"))
                .FirstOrDefault();

            if (existing == null)
                throw new NotImplementedException("Заменить на нормальную обработку отсутствия");

            existing.Name = category.Name;

            await this.ExecuteNonQueryAsync($"UPDATE [GoalsCategories] SET Name='{existing.Name}' WHERE id= '{existing.Id}'");
        }


        public async Task<IEnumerable<GoalCategory>> GetAllAsync(Func<GoalCategory, bool> selectFunc = null)
        {
            var result = await this.ExecuteQueryAsync("SELECT * FROM [GoalsCategories]");

            if (selectFunc != null)
                return result;

            return result.Where(selectFunc);
        }

        private async Task ExecuteNonQueryAsync(string sql)
        {
            using (var connection = new SqlConnection(
                this.configuration.GetConnectionString(connectionStringName)))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                    await command.ExecuteNonQueryAsync();
            }
        }

        private async Task<IEnumerable<GoalCategory>> ExecuteQueryAsync(string sql)
        {
            var result = new List<GoalCategory>();
            using (var connection = new SqlConnection(
                this.configuration.GetConnectionString(connectionStringName)))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    var reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        result.Add(new GoalCategory
                        {
                            Name = reader["Name"].ToString(),
                            Id = Guid.Parse(reader["Id"].ToString()),
                        });
                    }
                }
            }

            return result;
        }
    }
}
