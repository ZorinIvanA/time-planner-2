﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Timeplanner.Core.Implementations;
using Timeplanner.Core.Interfaces;
using TimePlanner.Domain.Interfaces;
using TimePlanner.Domain.Models;

namespace TimePlanner.Infrastructure.Repositories
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

        public async Task<IOperationResult<Guid>> AddCategory(GoalCategory category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var id = Guid.NewGuid();
            await ExecuteNonQueryAsync($"INSERT INTO [goals_categories] (id, name) VALUES ('{id}','{category.Name}')");

            return new Success<Guid>(id);
        }

        public async Task<IOperationResult> DeleteCategory(Guid id)
        {
            var existing = (await ExecuteQueryAsync($"SELECT * FROM [goals_categories] WHERE id='{id}'"))
                .FirstOrDefault();

            if (existing == null)
                return new ElementNotFound($"Не найдена категория с id {id}");

            await ExecuteNonQueryAsync($"DELETE FROM [goals_categories] WHERE id='{id}'");

            return new Success();
        }

        public async Task<IOperationResult> EditCategory(GoalCategory category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var existing = (await ExecuteQueryAsync($"SELECT * FROM [goals_categories] WHERE id='{category.Id}'"))
                .FirstOrDefault();

            if (existing == null)
                return new ElementNotFound($"Не найдена категория с id {category.Id}");

            existing.Name = category.Name;

            await ExecuteNonQueryAsync($"UPDATE [goals_categories] SET Name='{existing.Name}' WHERE id= '{existing.Id}'");

            return new Success();
        }


        public async Task<IOperationResult<IEnumerable<GoalCategory>>> GetAllAsync(Func<GoalCategory, bool> selectFunc = null)
        {
            var result = await ExecuteQueryAsync("SELECT * FROM [goals_categories]");

            if (selectFunc != null)
                return new Success<IEnumerable<GoalCategory>>(result);

            return new Success<IEnumerable<GoalCategory>>(result.Where(selectFunc));
        }

        private async Task ExecuteNonQueryAsync(string sql)
        {
            using (var connection = new SqlConnection(
                configuration.GetConnectionString(connectionStringName)))
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
                configuration.GetConnectionString(connectionStringName)))
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
