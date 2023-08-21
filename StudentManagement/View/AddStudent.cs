using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentManagement.Model;

namespace StudentManagement.View
{
    public partial class AddStudent : Form
    {
        private StudentDatabase.StudentDatabase studentDatabase = new StudentDatabase.StudentDatabase();
        public AddStudent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new StudentList().Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool success = studentDatabase.AddNewStudent(new Student()
            {
                Name = text_name.Text,
                Departemnt = text_dpt.Text,
                CGPA = Convert.ToDouble(text_cgpa.Text),
                Age = Convert.ToInt32(text_age.Text),
                Email = text_email.Text,
                Phone = text_phone.Text,
                Birthdate = text_date.Text
                
            });

            if (success)
            {
                MessageBox.Show("Item Successfully Inserted");
                new StudentList().Show();
            }
            else
            {
                MessageBox.Show("Item Fails to Inserted");
            } 
        }
    }
}
