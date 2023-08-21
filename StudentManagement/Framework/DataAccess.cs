using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Framework
{
    public class DataAccess
    {
        private SqlConnection connection;
        string connectionString = "Data Source=DESKTOP-28R1S0T;Initial Catalog=Student Management;Integrated Security=True";

        public DataAccess()
        {
            connection = new SqlConnection(connectionString);

        }


        public SqlConnection Connection()
        {
            return connection;
        }


    }

}

