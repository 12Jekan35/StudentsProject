using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using StudentsProject.Models;

namespace StudentsProject.Services
{
    public class GroupsProvider
    {
        private SqlConnection _connection;

        public GroupsProvider(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<StudentsGroup> GetAll()
        {
            var groups = new List<StudentsGroup>();

            try
            {
                _connection.Open();
                var cmd = new SqlCommand(
                    @"
                        SELECT 
                            [Specialties].[Id],
                            [Specialties].[Code], 
                            [Specialties].[Name],
                            [Groups].[Id],
                            [Groups].[Name],
                            [Groups].[Year]
                        FROM
                            [Groups]
                        LEFT JOIN
                            [Specialties]
                        ON [Groups].[SpecialtyId] = [Specialties].[Id]
                    ",
                    _connection
                );

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var specialty = new Specialty
                        {
                            Id = reader.GetInt32(0),
                            Code = reader.GetString(1),
                            Name = reader.GetString(2),
                        };
                        var group = new StudentsGroup
                        {
                            Id = reader.GetInt32(3),
                            Name = reader.GetString(4),
                            YearCreation = reader.GetInt32(5),
                            SpecialtyId = specialty.Id,
                            Specialty = specialty
                        };

                        groups.Add(group);
                    }
                }
            }
            finally
            {
                _connection.Close();
            }

            return groups;
        }

        public bool Add(StudentsGroup data)
        {
            var cmd = new SqlCommand(
                @"
                        INSERT INTO [Groups]
                            ([Name], [Year], [SpecialtyId])
                        VALUES
                            (@Name, @Year, @SpecialtyId)
                    ",
                _connection
            );
            cmd.Parameters.AddWithValue("@Name", data.Name);
            cmd.Parameters.AddWithValue("@Year", data.YearCreation);
            cmd.Parameters.AddWithValue("@SpecialtyId", data.SpecialtyId);

            return MyExecuteNonQuery(cmd);
        }

        public bool Update(StudentsGroup data)
        {
            var cmd = new SqlCommand(
                @"
                    UPDATE [Groups]
                    SET
                        [Name] = @Name,
                        [Year] = @Year,
                        [SpecialtyId] = @SpecialtyId
                    WHERE
                        [Id] = @Id
                ",
                _connection
            );
            cmd.Parameters.AddWithValue("@Id", data.Id);
            cmd.Parameters.AddWithValue("@Name", data.Name);
            cmd.Parameters.AddWithValue("@Year", data.YearCreation);
            cmd.Parameters.AddWithValue("@SpecialtyId", data.Specialty.Id);

            return MyExecuteNonQuery(cmd);
        }

        public bool Delete(int id)
        {
            var cmd = new SqlCommand(
                @"
                    DELETE FROM [Groups]
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
