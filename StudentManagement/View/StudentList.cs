using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentManagement.Framework;
using StudentManagement.Model;

namespace StudentManagement.View
{
    public partial class StudentList : Form
    {
        private StudentDatabase.StudentDatabase studentDatabase = new StudentDatabase.StudentDatabase();

        private string studentid;
        public StudentList()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StudentList_Load(object sender, EventArgs e)
        {
            foreach (Student student in studentDatabase.AllStudent())
            {
                dataGridView1.Rows.Add(student.Id, student.Name, student.Departemnt,student.CGPA, student.Age, student.Email,student.Birthdate,student.Phone);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddStudent().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new UpdateForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool success = studentDatabase.DeleteStudentById(studentid);
            if (success)
            {
                MessageBox.Show("Delete Successfully from in our Database");
                new StudentList().Show();
            }
            else
            {
                MessageBox.Show("Delete Faild from our Database");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            studentid = row.Cells["studentId"].Value.ToString();
        }
    }
}

