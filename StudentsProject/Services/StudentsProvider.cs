using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using StudentsProject.Models;

namespace StudentsProject.Services
{
    public class StudentsProvider
    {
        private SqlConnection _connection;

        public StudentsProvider(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<Student> GetAll()
        {
            var students = new List<Student>();

            try
            {
                _connection.Open();
                var cmd = new SqlCommand(
                    @"
                        SELECT 
                            [Groups].[Id],
                            [Groups].[Name],
                            [Groups].[Year],
                            [Students].[Id],
                            [Students].[FullName], 
                            [Students].[Gender], 
                            [Students].[Phone]
                        FROM
                            [Students]
                        LEFT JOIN
                            [Groups]
                        ON [Students].[GroupId] = [Groups].[Id]
                    ",
                    _connection
                );

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var group = new StudentsGroup
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            YearCreation = reader.GetInt32(2),
                        };
                        var student = new Student
                        {
                            Id = reader.GetInt32(3),
                            FullName = reader.GetString(4),
                            Gender = reader.GetString(5),
                            Phone = reader.GetString(6),
                            GroupId = group.Id,
                            Group = group
                        };

                        students.Add(student);
                    }
                }
            }
            finally
            {
                _connection.Close();
            }

            return students;
        }

        public bool Add(Student student)
        {
            var cmd = new SqlCommand(
                @"
                        INSERT INTO [Students]
                            ([FullName], [Gender], [Phone], [GroupId])
                        VALUES
                            (@FullName, @Gender, @Phone, @GroupId)
                    ",
                _connection
            );
            cmd.Parameters.AddWithValue("@FullName", student.FullName);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@Phone", student.Phone);
            cmd.Parameters.AddWithValue("@GroupId", student.GroupId);

            return MyExecuteNonQuery(cmd);
        }

        public bool Update(Student data)
        {
            var cmd = new SqlCommand(
                @"
                    UPDATE [Students]
                    SET
                        [FullName] = @FullName,
                        [Gender] = @Gender,
                        [Phone] = @Phone,
                        [GroupId] = @GroupId
                    WHERE
                        [Id] = @Id
                ",
                _connection
            );
            cmd.Parameters.AddWithValue("@Id", data.Id);
            cmd.Parameters.AddWithValue("@FullName", data.FullName);
            cmd.Parameters.AddWithValue("@Gender", data.Gender);
            cmd.Parameters.AddWithValue("@Phone", data.Phone);
            cmd.Parameters.AddWithValue("@GroupId", data.GroupId);

            return MyExecuteNonQuery(cmd);
        }

        public bool Delete(int id)
        {
            var cmd = new SqlCommand(
                @"
                    DELETE FROM [Students]
                    WHERE [Id] = @Id
                ",
                _connection
            );
            cmd.Parameters.AddWithValue("@Id", id);

            return MyExecuteNonQuery(cmd);
        }

        private bool MyExecuteNonQuery(SqlCommand cmd)
        {
            bool ok = false;

            try
            {
                _connection.Open();
                var affected = cmd.ExecuteNonQuery();
                ok = affected > 0;
            }
            finally
            {
                _connection.Close();
            }

            return ok;
        }
    }
}
