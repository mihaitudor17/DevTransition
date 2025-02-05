using Microsoft.Data.Sqlite;
using Xunit;
using Assert = Xunit.Assert;

namespace Tests.Database
{
    public class Connection
    {
        private string _connectionString = "Data Source=NumbersFromString;";

        public Connection()
        {
            SQLitePCL.Batteries.Init();
        }

        [Fact]
        public void CanConnectToSQLiteDatabase_ReturnsTrue_WhenConnectionSuccessful()
        {
            var connection = new SqliteConnection(_connectionString);

            try
            {
                connection.Open(); 
                Assert.Equal(System.Data.ConnectionState.Open, connection.State); 
            }
            catch (Exception ex)
            {
                Assert.Fail($"Could not establish connection: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
