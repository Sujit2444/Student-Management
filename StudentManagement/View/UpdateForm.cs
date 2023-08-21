using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentManagement.Model;
using StudentManagement.StudentDatabase;

namespace StudentManagement.View
{
    public partial class UpdateForm : Form
    {

        private StudentDatabase.StudentDatabase studentDatabase;

        public UpdateForm()
        {
            InitializeComponent();
            studentDatabase = new StudentDatabase.StudentDatabase();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(studentDatabase.AllStudentId().ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Student student = studentDatabase.GetStudentById(comboBox1.SelectedItem.ToString());
            text_id.Text = student.Id.ToString();
            text_name.Text = student.Name;
            text_dpt.Text = student.Departemnt;
            text_cgpa.Text = student.CGPA.ToString();
            text_age.Text = student.Age.ToString();
            text_email.Text = student.Email;
            text_phone.Text = student.Phone;
            text_date.Text = student.Birthdate;
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            bool success = studentDatabase.UpdateStudent(new Student
            {
                Id = Convert.ToInt32(text_id.Text),
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
                
                MessageBox.Show("Update Successfully Add in our Database");
                new StudentList().Show();
            }
            else
            {
                MessageBox.Show("Update Faild Add in our Database");
            }
        }
    }
}
