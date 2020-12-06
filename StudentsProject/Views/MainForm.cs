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
    public partial class MainForm : Form
    {
        public event Action OpenStudents;
        public event Action OpenGroups;
        public event Action OpenSpecialties;
        public MainForm()
        {
            InitializeComponent();
        }

        private void openStudentsButton_Click(object sender, EventArgs e)
        {
            OpenStudents();
        }

        private void openGroupsButton_Click(object sender, EventArgs e)
        {
            OpenGroups();
        }

        private void openSpecialtiesButton_Click(object sender, EventArgs e)
        {
            OpenSpecialties();
        }
    }
}
