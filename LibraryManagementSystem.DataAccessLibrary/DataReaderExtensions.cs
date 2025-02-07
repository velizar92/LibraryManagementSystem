using LibraryManagementSystem.ModelsLibrary;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystem.DataAccessLibrary
{
    public static class DataReaderExtensions
    {
        public static Book GetBookData(SqlDataReader reader)
        {
            return new Book
            {
                Id = (int)reader["Id"],
                Title = reader["Title"] != DBNull.Value ? reader["Title"].ToString() : null,
                Author = reader["Author"] != DBNull.Value ? reader["Author"].ToString() : null,
                Genre = reader["Genre"] != DBNull.Value ? reader["Genre"].ToString() : null,
                PublishedYear = reader["PublishedYear"] != DBNull.Value ? reader["PublishedYear"].ToString() : null,
            };
        }
    }
}
