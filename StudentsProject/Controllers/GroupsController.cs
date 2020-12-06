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
    public class GroupsController
    {
        private GroupsForm _form;
        private StorageContext _context;

        public GroupsController(StorageContext context, GroupsForm form)
        {
            _context = context;
            _form = form;

            _form.ChangeData += ChangeItemHandler;
            _form.RefreshData += RefreshDataHandler;
            _form.AddItem += AddItemHandler;
        }
        public void RefreshDataHandler()
        {
            var groups = _context.Groups.GetAll();
            _form.ShowData(groups);
        }
        public void ChangeItemHandler(StudentsGroup item)
        {
            var editor = new GroupEditorForm();

            var result = editor.ShowDialog(item, _context.Specialties.GetAll());
            if (result != DialogResult.OK)
                return;

            _context.Groups.Update(editor.ChangedItem);
            RefreshDataHandler();
        }
        public void AddItemHandler()
        {
            var editor = new GroupEditorForm();

            var result = editor.ShowDialog(_context.Specialties.GetAll());
            if (result != DialogResult.OK)
                return;

            _context.Groups.Add(editor.ChangedItem);
            RefreshDataHandler();
        }
    }
}
