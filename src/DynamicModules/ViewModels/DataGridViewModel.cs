using System.Collections.ObjectModel;
using Prism.Mvvm;
using DM.Core.Model;
using DM.Core.Services;

namespace DM.Demo.ViewModels
{
    public class DataGridViewModel : BindableBase
    {
        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set { SetProperty(ref customers, value); }
        }

        public DataGridViewModel(ICustomerService service)
        {
            Customers = new ObservableCollection<Customer>();
            Customers.AddRange(service.GetAllCustomers());
        }
    }
}
