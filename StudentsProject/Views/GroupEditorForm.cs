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
    public partial class GroupEditorForm : Form
    {
        private int Id;
        public StudentsGroup ChangedItem
        {
            get
            {
                return new StudentsGroup
                {
                    Id = Id,
                    Name = nameBox.Text,
                    YearCreation = int.Parse(yearTextBox.Text),
                    Specialty = specialtyBox.SelectedItem as Specialty,
                    SpecialtyId = (specialtyBox.SelectedItem as Specialty).Id
                };
            }
        }
        public GroupEditorForm()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(StudentsGroup item, List<Specialty> specialties)
        {
            if (item == null)
                item = new StudentsGroup();

            Id = item.Id;
            nameBox.Text = item.Name;
            yearTextBox.Text = item.YearCreation.ToString();
            specialtyBox.DataSource = specialties;
            specialtyBox.SelectedItem = specialtyBox.Items.IndexOf(item.Specialty);

            return ShowDialog();
        }
        public DialogResult ShowDialog(List<Specialty> specialties)
        {
            
            specialtyBox.DataSource = specialties;

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
