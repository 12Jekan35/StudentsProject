using StudentsProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsProject.Views
{
    public partial class StudentEditorForm : Form
    {
        public StudentEditorForm()
        {
            InitializeComponent();
        }

        private int Id;
        public Student ChangedItem 
        { 
            get
            {
                return new Student
                {
                    Id = Id,
                    FullName = fullNameBox.Text,
                    Gender = genderBox.SelectedItem.ToString(),
                    Phone = phoneBox.Text,
                    Group = groupBox.SelectedItem as StudentsGroup,
                    GroupId = (groupBox.SelectedItem as StudentsGroup).Id
                };
            }
        }

        public DialogResult ShowDialog(Student item, List<StudentsGroup> groups)
        {
            if (item == null)
                item = new Student();

            Id = item.Id;
            fullNameBox.Text = item.FullName;
            genderBox.SelectedItem = item.Gender;
            phoneBox.Text = item.Phone;
            groupBox.DataSource = groups;
            groupBox.SelectedItem = groupBox.Items.IndexOf(item.Group);

            return ShowDialog();
        }
        public DialogResult ShowDialog(List<StudentsGroup> groups)
        {
            groupBox.DataSource = groups;

            return ShowDialog();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
