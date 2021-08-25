using AppExercice.Model;
using AppExercice.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppExercice.Common
{

    public class DeleteCommand : ICommand
    {
        private StoresCatalog _catalog;
        private StoresViewModel _viewModel;

        public DeleteCommand(StoresCatalog catalog, StoresViewModel viewModel)
        {
            _catalog = catalog;
            _viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return _viewModel.SelectedStore != null;
        }

        public void Execute(object parameter)
        {
            // Delete from catalog
            _catalog.Delete(_viewModel.SelectedStore.Phone);
            // Set selection to null
            _viewModel.SelectedStore = null;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }

}

