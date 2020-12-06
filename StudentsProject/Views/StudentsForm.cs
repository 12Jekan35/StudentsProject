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
    public partial class StudentsForm : Form
    {
        public event Action RefreshData;
        public event Action AddItem;
        public event Action<Student> ChangeData;
        public StudentsForm()
        {
            InitializeComponent();
            studentsView.AutoGenerateColumns = false;
        }

        public void ShowData(List<Student> data)
        {
            studentsView.DataSource = data;
        }

        private void RefreshDataSource(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void changeButton_Click(
            object sender,
            EventArgs e
        )
        {
            var stud = studentsView
                .SelectedRows[0]
                .DataBoundItem as Student;

            if (stud != null)
                ChangeData(stud);
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            AddItem();
        }
    }
}
