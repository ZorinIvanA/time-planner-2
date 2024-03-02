using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;

namespace TimePlanner.Infrastructure
{
    public class GoalsCategoriesRepository : IGoalCategoriesRepository
    {
        IConfiguration configuration;

        public GoalsCategoriesRepository(IConfiguration configuration)
        {
            this.configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<IEnumerable<GoalCategory>> GetAllAsync()
        {
            throw new NotImplementedException();

             var result = new List<GoalCategory>();

            using (var connection = new SqlConnection(
                this.configuration.GetConnectionString("MainConnectionString")))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM [GoalsCategories]", connection))
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
