using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using TechnoHub.Model;
using System.Linq;
using Microsoft.VisualBasic;

namespace TechnoHub.Repositories
{
    public class UserRepository
    {
        public string ConnectionString = "Data Source=DESKTOP-39A9U0N\\SQLEXPRESS;User ID=admin;Password=123@123@; database=Users; TrustServerCertificate=True;";

        public async  Task<int> Create(UserModel user)
        {
            string query = "INSERT INTO [dbo].[StudentTable] ([name],[surname],[lastname],[birhday] ,[Status]) VALUES (@Name, @Surname, @lastName, @birthday,  0) Select scope_identity();";
            int Id = 0;
            IDbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            Id = connection.QueryAsync<int>(query, user).Result.FirstOrDefault();
            connection.Close();
            return Id;
        }
        public async Task Update(UserModel user)
        {
            string query = "UPDATE [dbo].[User] SET [name] = @name,[surname] = @surname,[lastname] =  @lastname,[birhday] =  @birthday, [Status] = @status WHERE int = @id";

            IDbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            connection.Execute(query, user);
            connection.Close();
        }

        public async Task<List<UserModel>> GetById(int id) 
        {
            string query = "SELECT [int],[name],[surname] ,[lastname] ,[birhday]   ,[Status]  FROM [dbo].[User]  WHERE int = @id";
            IDbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            var abc = connection.Query<UserModel>(query, new { id }).FirstOrDefault();
            if (abc == null)
            {
                return new List<UserModel>();
            }
            else
            {
                return new List<UserModel> { abc };
            }
            connection.Close();
        }
        public async Task<List<UserModel>> GetAll()
        {
            string query = "SELECT [int],[name],[surname],[lastname],[birhday],[Status]  FROM [dbo].[StudentTable]";
            IDbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            var abc = await connection.QueryAsync<UserModel>(query);
            return abc.ToList();
            connection.Close();
        }
        public async Task Delete(int id)
        {
            string query = "UPDATE [dbo].[User] SET [Status] = 0 WHERE int = @id";
            IDbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            connection.ExecuteAsync(query, new { id });
            connection.Close();

        }
    }
}
