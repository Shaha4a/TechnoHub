using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
using TechnoHub.Model;

namespace TechnoHub.Repositories
{
    public class CourseRepository
    {
        public string ConnectionString = "Data Source=DESKTOP-39A9U0N\\SQLEXPRESS;User ID=admin;Password=123@123@; database=Users; TrustServerCertificate=True;";

        public async Task<int> Create(CourseModel course)
        {
            string query = "INSERT INTO [dbo].[Cours] ([name]) VALUES (@Name) Select scope_identity();";
            int Id = 0;
            IDbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            Id = connection.QueryAsync<int>(query, course).Result.FirstOrDefault();
            connection.Close();
            return Id;
        }
        public async Task Update(CourseModel course)
        {
            string query = "UPDATE [dbo].[Cours] SET [name] = @name WHERE id = @id";

            IDbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            connection.Execute(query, course);
            connection.Close();
        }

        public async Task Delete(int id)
        {
            string query = "UPDATE [dbo].[Cours] SET [Status] = 0 WHERE id = @id";
            IDbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            connection.ExecuteAsync(query, new { id });
            connection.Close();

        }

        public async Task<List<CourseModel>> GetById(int id)
        {
            string query = "SELECT [name]  FROM [dbo].[Cours]  WHERE id = @id";
            IDbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            var abc = connection.Query<CourseModel>(query, new { id }).FirstOrDefault();
            if (abc == null)
            {
                return new List<CourseModel>();
            }
            else
            {
                return new List<CourseModel> { abc };
            }
            connection.Close();
        }
        public async Task<List<CourseModel>> GetAll()
        {
            string query = "SELECT [id], [name]  FROM [dbo].[Cours]";
            IDbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            var abc = await connection.QueryAsync<CourseModel>(query);
            return abc.ToList();
            connection.Close();
        }
    }
}

