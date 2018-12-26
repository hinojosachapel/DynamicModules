using System.Collections.ObjectModel;
using System.Linq;
using Prism.Mvvm;
using DM.Core.Model;
using DM.Core.Services;

namespace DM.ModuleTwo.ViewModels
{
    public class DataGridViewModel : BindableBase
    {
        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { SetProperty(ref _customers, value); }
        }

        public DataGridViewModel(ICustomerService service)
        {
            Customers = new ObservableCollection<Customer>();
            Customers.AddRange(service.GetAllCustomers().OrderBy(c => c.LastName));
        }
    }
}
