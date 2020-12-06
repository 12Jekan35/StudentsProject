using StudentsProject.Models;
using StudentsProject.Services;
using StudentsProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsProject.Controllers
{
    public class StudentsController
    {
        private StudentsForm _form;
        private StorageContext _context;

        public StudentsController(StorageContext context, StudentsForm form)
        {
            _context = context;
            _form = form;

            _form.RefreshData += RefreshDataHandler;
            _form.ChangeData += ChangeItemHandler;
            _form.AddItem += AddItemHandler;
        }

        public void RefreshDataHandler()
        {
            var students = _context.Students.GetAll();
            _form.ShowData(students);
        }
        public void ChangeItemHandler(Student item)
        {
            var editor = new StudentEditorForm();

            var result = editor.ShowDialog(item, _context.Groups.GetAll());
            if (result != DialogResult.OK)
                return;

            _context.Students.Update(editor.ChangedItem);
            RefreshDataHandler();
        }
        public void AddItemHandler()
        {
            var editor = new StudentEditorForm();

            var result = editor.ShowDialog(_context.Groups.GetAll());
            if (result != DialogResult.OK)
                return;

            _context.Students.Add(editor.ChangedItem);
            RefreshDataHandler();
        }
    }
}
