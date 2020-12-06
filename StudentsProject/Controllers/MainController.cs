using StudentsProject.Services;
using StudentsProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject.Controllers
{
    public class MainController
    {
        private MainForm _form;
        private StorageContext _context;

        public MainController(MainForm form, StorageContext context)
        {
            _form = form;
            _context = context;

            _form.OpenGroups += OpenGroupsHandler;
            _form.OpenSpecialties += OpenSpecialtiesHandler;
            _form.OpenStudents += OpenStudentsHandler;
        }
        private void OpenGroupsHandler()
        {
            var groupsForm = new GroupsForm();
            var groupsController = new GroupsController(_context, groupsForm);

            _form.Hide();
            groupsForm.ShowDialog();
            _form.Show();
        }
        private void OpenStudentsHandler()
        {
            var studForm = new StudentsForm();
            var studController = new StudentsController(_context, studForm);

            _form.Hide();
            studForm.ShowDialog();
            _form.Show();
        }
        private void OpenSpecialtiesHandler()
        {
            var specForm = new SpecialtiesForm();
            var specController = new SpecialtiesController(_context, specForm);

            _form.Hide();
            specForm.ShowDialog();
            _form.Show();
        }
    }
}
