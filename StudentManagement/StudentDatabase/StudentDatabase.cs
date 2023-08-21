using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using StudentManagement.Framework;
using StudentManagement.Model;
using StudentManagement.View;

namespace StudentManagement.StudentDatabase
{
    public class StudentDatabase
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        //private SqlDataAdapter  sqlDataAdapter;
        private SqlDataReader sqlDataReader;
        private DataAccess dataAccess;

        public StudentDatabase()
        {
            dataAccess = new DataAccess();
            sqlCommand = new SqlCommand();
        }


        public List<Student> AllStudent()
        {
            List<Student> Students = new List<Student>();

            sqlConnection = dataAccess.Connection();
            sqlConnection.Open();

            sqlCommand.CommandText =
                "SELECT * FROM Student";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Students.Add(new Student
                {
                    Id = sqlDataReader.GetInt32(0),
                    Name = sqlDataReader.GetString(1),
                    Departemnt = sqlDataReader.GetString(2),
                    CGPA = sqlDataReader.GetDouble(3),
                    Age = sqlDataReader.GetInt32(4),
                    Email = sqlDataReader.GetString(5),
                    Phone = sqlDataReader.GetString(6),
                    Birthdate = sqlDataReader.GetDateTime(7).ToString(),

                });
            }

            sqlConnection.Close();

            return Students;
        }


        public bool userlogin(User user)
        {


            sqlConnection = dataAccess.Connection();
            sqlConnection.Open();

            sqlCommand.CommandText="SELECT * FROM [User] WHERE Username = '"+user.UserName+"' AND UserPassword = '"+user.password+"'";
            sqlCommand.CommandType=CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                sqlConnection.Close();
                return true;
            }

            sqlConnection.Close();

            return false;
        }
    

        public bool AddNewStudent(Student student)
        {

            sqlConnection = dataAccess.Connection();
            sqlConnection.Open();

            sqlCommand.CommandText = "INSERT INTO Student(StudentName, Department, CGPA, Age, Email , Phone, Birthdate) VALUES('" + student.Name + "', '" + student.Departemnt + "','" + student.CGPA + "','" + student.Age+ "','" + student.Email + "','" + student.Phone + "','"+student.Birthdate+"')";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            if (sqlCommand.ExecuteNonQuery() > -1)
            {
                sqlConnection.Close();
                return true;
            }

            sqlConnection.Close();

            return false;
        }

        public List<string> AllStudentId()
        {
            List<string> ids = new List<string>();
            sqlConnection = dataAccess.Connection();
            sqlConnection.Open();

            sqlCommand.CommandText =
                "SELECT StudentID FROM Student";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                ids.Add(sqlDataReader.GetInt32(0).ToString());
            }

            sqlConnection.Close();

            return ids;


        }

        public Student GetStudentById(string studentId)
        {
            Student student = new Student();
            sqlConnection = dataAccess.Connection();
            sqlConnection.Open();

           int id = Convert.ToInt32(studentId);

            sqlCommand.CommandText = "SELECT * FROM Student WHERE StudentId = '" + studentId + "'";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                student.Id = sqlDataReader.GetInt32(0);
                student.Name = sqlDataReader.GetString(1);
                student.Departemnt = sqlDataReader.GetString(2);
                student.CGPA = sqlDataReader.GetDouble(3);
                student.Age = sqlDataReader.GetInt32(4);
                student.Email = sqlDataReader.GetString(5);
                student.Phone = sqlDataReader.GetString(6);
                student.Birthdate = sqlDataReader.GetDateTime(7).ToString();

            }

            sqlConnection.Close();

            return student;
        }

        public bool UpdateStudent(Student student)
        {
            sqlConnection = dataAccess.Connection();
            sqlConnection.Open();
            sqlCommand.CommandText = "UPDATE Student SET StudentName='" + student.Name + "', Department = '" + student.Departemnt + "', CGPA = '" + student.CGPA + "', Email = '" + student.Email + "', Phone = '" + student.Phone + "', Birthdate = '" + student.Birthdate + "' WHERE StudentId = '" + student.Id + "'";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            if (sqlCommand.ExecuteNonQuery() > -1)
            {
                sqlConnection.Close();
                return true;
            }

            sqlConnection.Close();

            return false;
        }


        public bool DeleteStudentById(string studentId)
        {
            int id = Convert.ToInt32(studentId); 
            sqlConnection = dataAccess.Connection();
            sqlConnection.Open();
            sqlCommand.CommandText = "DELETE FROM Student WHERE StudentId = '" + id + "'";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;

            if (sqlCommand.ExecuteNonQuery() > -1)
            {
                sqlConnection.Close();
                return true;
            }

            sqlConnection.Close();

            return false;

        }
    }
}