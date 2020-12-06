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
    public class SpecialtiesController
    {
        private SpecialtiesForm _view;
        private StorageContext _context;

        public SpecialtiesController(StorageContext context, SpecialtiesForm view)
        {
            _view = view;
            _view.Load += LoadHandler;
            _view.RefreshData += RefreshDataHandler;
            _view.ChangeData += ChangeDataHandler;
            _view.AddItem += AddItemHandler;

            _context = context;
        }

        public void LoadHandler(object o, EventArgs e)
        {
            RefreshDataHandler();
        }

        public void RefreshDataHandler()
        {
            try
            {
                var specialties = _context.Specialties.GetAll();
                _view.ShowData(specialties);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при чтении данных");
            }
        }

        public void ChangeDataHandler(Specialty data)
        {
            var editor = new SpecialtyEditorForm();
            var result = editor.ShowDialog(data);

            if (result != DialogResult.OK)
                return;

            try
            {
                _context.Specialties.Update(data.Id, editor.ChangedItem);
                RefreshDataHandler();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при обновлении данных");
            }

        }
        public void AddItemHandler()
        {
            var editor = new SpecialtyEditorForm();

            var result = editor.ShowDialog();
            if (result != DialogResult.OK)
                return;

            _context.Specialties.Add(editor.ChangedItem);
            RefreshDataHandler();
        }

    }
}
