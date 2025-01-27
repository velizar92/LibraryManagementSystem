using LibraryManagementSystem.ModelsLibrary;
using Microsoft.Data.SqlClient;

namespace LibraryManagementSystem.DataAccessLibrary.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly string _connectionString;

        public MemberRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddMember(Member member)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("INSERT INTO Members(FirstName, LastName, Email, PhoneNumber, IsDeleted) " +
                                                    "VALUES(@FirstName, @LastName, @Email, @PhoneNumber, @IsDeleted)", connection))
                {
                    command.Parameters.AddWithValue("@FirstName", member.FirstName);
                    command.Parameters.AddWithValue("@LastName", member.LastName);
                    command.Parameters.AddWithValue("@Email", member.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", member.PhoneNumber);
                    command.Parameters.AddWithValue("@IsDeleted", 0);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        
        public IEnumerable<Member> GetAllMembers()
        {
            List<Member> members = new List<Member>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Members " +
                                                    "WHERE IsDeleted = 0", connection))
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var member = GetMemberData(reader);

                            members.Add(member);
                        }
                    }
                }
            }

            return members;
        }

        public Member GetMemberByEmail(string memberEmail)
        {
            Member member = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Members " +
                                                    "WHERE Email = @Email", connection))
                {
                    command.Parameters.AddWithValue("@Email", memberEmail);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            member = GetMemberData(reader);
                        }
                    }
                }
            }

            return member;
        }

        public Member GetMemberById(int memberId)
        {
            Member member = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Members " +
                                                    "WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", memberId);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            member = GetMemberData(reader);
                        }
                    }
                }
            }

            return member;
        }

        public Member GetMemberFullInfoById(int memberId)
        {
            Member member = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT m.Id, m.FirstName, m.LastName, m.Email, m.PhoneNumber, " +
                                                    "bb.BorrowDate, bb.ReturnDate, b.Title, b.Author, b.Genre, b.PublishedYear " +
                                                    "FROM Members AS m " +
                                                    "JOIN BorrowedBooks AS bb ON bb.MemberId = m.Id " +
                                                    "JOIN Books AS b ON bb.BookId = b.Id " +
                                                    "WHERE m.Id = @MemberId AND m.IsDeleted = 0", connection))
                {
                    command.Parameters.AddWithValue("@MemberId", memberId);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (member == null)
                            {
                                member = GetMemberData(reader);
                                member.BorrowedBooks = new List<BorrowedBooks>();
                            }

                            member.BorrowedBooks.Add(new BorrowedBooks
                            {
                                BorrowDate = reader["BorrowDate"] != DBNull.Value ? (DateTime?)reader["BorrowDate"] : null,
                                ReturnDate = reader["ReturnDate"] != DBNull.Value ? (DateTime?)reader["ReturnDate"] : null,
                                Book = new Book
                                {
                                    Title = reader["Title"] != DBNull.Value ? reader["Title"].ToString() : null,
                                    Author = reader["Author"] != DBNull.Value ? reader["Author"].ToString() : null,
                                    Genre = reader["Genre"] != DBNull.Value ? reader["Genre"].ToString() : null,
                                    PublishedYear = reader["PublishedYear"] != DBNull.Value ? reader["PublishedYear"].ToString() : null,
                                }
                            });

                        }
                    }
                }
            }

            return member;
        }

        public IEnumerable<Member> GetMembersByFirstName(string memberFirstName)
        {
            List<Member> members = new List<Member>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Members " +
                                                    "WHERE FirstName = @FirstName", connection))
                {

                    command.Parameters.AddWithValue("@FirstName", memberFirstName);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var member = GetMemberData(reader);
                            
                            members.Add(member);
                        }
                    }
                }
            }

            return members;
        }

        public IEnumerable<Member> GetMembersByLastName(string memberLastName)
        {
            List<Member> members = new List<Member>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Members " +
                                                    "WHERE LastName = @LastName", connection))
                {

                    command.Parameters.AddWithValue("@LastName", memberLastName);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var member = GetMemberData(reader);

                            members.Add(member);
                        }
                    }
                }
            }

            return members;
        }

        public void UpdateMember(Member member)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("UPDATE Members " +
                                                    "SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber " +
                                                    "WHERE Id = @MemberId", connection))
                {
                    command.Parameters.AddWithValue("@MemberId", member.Id);
                    command.Parameters.AddWithValue("@FirstName", member.FirstName);
                    command.Parameters.AddWithValue("@LastName", member.LastName);
                    command.Parameters.AddWithValue("@Email", member.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", member.PhoneNumber);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteMemberById(int memberId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("UPDATE Members " +
                                                    "SET IsDeleted = 1, DeletedOn = @DeletedOn " +
                                                    "WHERE Id = @MemberId", connection))
                {
                    command.Parameters.AddWithValue("@MemberId", memberId);
                    command.Parameters.AddWithValue("@DeletedOn", DateTime.UtcNow);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private Member GetMemberData(SqlDataReader reader)
        {
            return new Member
            {
                Id = (int)reader["Id"],
                FirstName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : null,
                LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : null,
                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : null,
            };
        }
    }
}
