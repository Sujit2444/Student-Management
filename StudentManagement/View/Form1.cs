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
using StudentManagement.Service;
using StudentManagement.View;
using User = StudentManagement.Model.User;

namespace StudentManagement
{
    public partial class Form1 : Form
    {
        private StudentDatabase.StudentDatabase studentDatabase = new StudentDatabase.StudentDatabase();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = studentDatabase.userlogin(new User {UserName = textBox1.Text, password = textBox2.Text});
            if (success)
            {
                new StudentList().Show();
            }
            else
            {
                MessageBox.Show("Login faied");
            }


        }

       
    }
}
