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
                            var member = new Member
                            {
                                Id = (int)reader["Id"],
                                FirstName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : null,
                                LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : null,
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                                PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : null,
                            };

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
                            member = new Member
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
                            member = new Member
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
            }

            return member;
        }

        public Member GetMemberFullInfoById(int memberId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetMembersByFirstName(string memberFirstName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetMembersByLastName(string memberLastName)
        {
            throw new NotImplementedException();
        }

        public void UpdateMember(Member member)
        {
            throw new NotImplementedException();
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
    }
}
