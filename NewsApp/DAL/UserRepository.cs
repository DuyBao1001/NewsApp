using Microsoft.Data.SqlClient;
using NewsApp.Data;

namespace NewsApp.DAL
{
    internal class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository() : base()
        {
        }

        public bool CheckUserNameExists(string userName)
        {
            try
            {
                using SqlConnection connection = GetConnection();
                connection.Open();
                string query = "SELECT UserName FROM Account WHERE UserName = @userName";
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@userName", userName);
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
            catch (SqlException sqle)
            {
                throw new NotImplementedException(sqle.Message);
            }
        }



        public override bool Delete(Account obj)
        {
            //try
            //{
            //    using SqlConnection connection = GetConnection();
            //    connection.Open();
            //    string query = "DELETE FROM Account WHERE AccountID = @accountId";
            //    SqlCommand command = new(query, connection);
            //    command.Parameters.AddWithValue("@accountId", obj.AccountID);
            //    return command.ExecuteNonQuery() > 0;
            //}
            //catch (SqlException sqle)
            //{
            //    Console.WriteLine(sqle.Message);
            //    return false;
            //}
            throw new NotImplementedException();
        }

        public override IList<Account> GetAll()
        {
            try
            {
                using SqlConnection connection = GetConnection();
                connection.Open();
                string query = "SELECT * FROM Account";
                SqlCommand command = new(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                return [];
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
                return [];
            }
        }

        public override Account? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Login(Account account)
        {
            try
            {
                using SqlConnection connection = GetConnection();
                String query = "SELECT UserName FROM Account WHERE UserName = @userName AND Password = @password";
                SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@userName", account.Username);
                command.Parameters.AddWithValue("@password", account.Password);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
                return false;
            }
        }

    }
}