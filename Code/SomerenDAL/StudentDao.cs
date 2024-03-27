using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class StudentDao : BaseDao
    {
        public List<Student> GetAllStudents()
        {
            string query = "SELECT * FROM STUDENT";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    StudentNumber = (int)dr["StudentNumber"],
                    Class = dr["Class"].ToString(),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    PhoneNumber = dr["PhoneNumber"].ToString(),
                    RoomNumber = (int)dr["RoomNumber"]
                };
                students.Add(student);
            }
            return students;
        }
    }
}