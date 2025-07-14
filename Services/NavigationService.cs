using System;

namespace QuoteSwift
{
    public class NavigationService : INavigationService
    {
        readonly IDataService dataService;

        public NavigationService(IDataService service)
        {
            dataService = service;
            Pass = new Pass(null, null, null, null);
        }

        public Pass Pass { get; set; }

        public void CreateNewQuote()
        {
            var vm = new CreateQuoteViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmCreateQuote(vm, Pass))
            {
                form.ShowDialog();
            }
        }

        public void ViewAllQuotes()
        {
            var vm = new QuotesViewModel(dataService);
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmViewQuotes(vm, this))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }

        public void ViewAllPumps()
        {
            var vm = new ViewPumpViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewPump(vm, this, Pass))
            {
                form.ShowDialog();
            }
        }

        public void CreateNewPump()
        {
            var vm = new AddPumpViewModel(dataService);
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmAddPump(vm, this))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }

        public void ViewAllParts()
        {
            var vm = new ViewPartsViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewParts(vm, this, Pass))
            {
                form.ShowDialog();
            }
        }

        public void AddNewPart()
        {
            var vm = new AddPartViewModel(dataService);
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmAddPart(vm, this))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }

        public void AddCustomer()
        {
            var vm = new AddCustomerViewModel(dataService);
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmAddCustomer(vm, this))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }

        public void ViewCustomers()
        {
            var vm = new ViewCustomersViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewCustomers(vm, this, Pass))
            {
                form.ShowDialog();
            }
        }

        public void AddBusiness()
        {
            var vm = new AddBusinessViewModel(dataService);
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmAddBusiness(vm, this))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }

        public void ViewBusinesses()
        {
            var vm = new ViewBusinessesViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewAllBusinesses(vm, this, Pass))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesAddresses()
        {
            var vm = new ViewBusinessAddressesViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewBusinessAddresses(vm, this, Pass))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesPOBoxAddresses()
        {
            var vm = new ViewPOBoxAddressesViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewPOBoxAddresses(vm, this, Pass))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesEmailAddresses()
        {
            var vm = new ManageEmailsViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmManageAllEmails(vm, this, Pass))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesPhoneNumbers()
        {
            var vm = new ManagePhoneNumbersViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmManagingPhoneNumbers(vm, this, Pass))
            {
                form.ShowDialog();
            }
        }

        public void EditBusinessAddress()
        {
            var vm = new ViewBusinessAddressesViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmEditBusinessAddress(vm, Pass))
            {
                form.ShowDialog();
            }
        }

        public void EditBusinessEmailAddress()
        {
            var vm = new ManageEmailsViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmEditEmailAddress(vm, Pass))
            {
                form.ShowDialog();
            }
        }

        public void EditPhoneNumber()
        {
            var vm = new ManagePhoneNumbersViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmEditPhoneNumber(vm, Pass))
            {
                form.ShowDialog();
            }
        }
    }
}
