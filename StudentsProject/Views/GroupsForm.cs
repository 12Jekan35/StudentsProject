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
    public partial class GroupsForm : Form
    {
        public event Action RefreshData;
        public event Action AddItem;
        public event Action<StudentsGroup> ChangeData;
        public GroupsForm()
        {
            InitializeComponent();
            groupsView.AutoGenerateColumns = false;
        }
        public void ShowData(List<StudentsGroup> data)
        {
            groupsView.DataSource = data;
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
            var group = groupsView
                .SelectedRows[0]
                .DataBoundItem as StudentsGroup;

            if (group != null)
                ChangeData(group);
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            AddItem();
        }
    }
}
