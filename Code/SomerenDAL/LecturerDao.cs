using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;
using System;

namespace SomerenDAL
{
    public class LecturerDao : BaseDao
    {
        public List<Lecturer> GetAllLecturers()
        {
            string query = "SELECT * FROM LECTURER";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Lecturer> ReadTables(DataTable dataTable)
        {
            List<Lecturer> lecturers = new List<Lecturer>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Lecturer lecturer = new Lecturer()
                {
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    PhoneNumber = dr["PhoneNumber"].ToString(),
                    Birthdate = (DateTime)dr["Birthdate"]
                };
                lecturers.Add(lecturer);
            }
            return lecturers;
        }
    }
}
