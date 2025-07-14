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
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmCreateQuote(vm))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
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
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmViewPump(vm, this))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
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
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmViewParts(vm, this))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }

        public void AddNewPart()
        {
            var vm = new AddPartViewModel(dataService);
            vm.UpdatePass(Pass.PassPartList, Pass.PassPumpList, Pass.PartToChange, Pass.ChangeSpecificObject);
            vm.LoadData();
            using (var form = new FrmAddPart(vm, this))
            {
                form.SetPass(Pass);
                form.ShowDialog();
            }
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
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmViewCustomers(vm, this))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
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
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmViewAllBusinesses(vm, this))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }

        public void ViewBusinessesAddresses()
        {
            var vm = new ViewBusinessAddressesViewModel(dataService);
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmViewBusinessAddresses(vm, this))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }

        public void ViewBusinessesPOBoxAddresses()
        {
            var vm = new ViewPOBoxAddressesViewModel(dataService);
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmViewPOBoxAddresses(vm, this))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }

        public void ViewBusinessesEmailAddresses()
        {
            var vm = new ManageEmailsViewModel(dataService);
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmManageAllEmails(vm, this))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }

        public void ViewBusinessesPhoneNumbers()
        {
            var vm = new ManagePhoneNumbersViewModel(dataService);
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmManagingPhoneNumbers(vm, this))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }

        public void EditBusinessAddress()
        {
            var vm = new ViewBusinessAddressesViewModel(dataService);
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmEditBusinessAddress(vm))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }

        public void EditBusinessEmailAddress()
        {
            var vm = new ManageEmailsViewModel(dataService);
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmEditEmailAddress(vm))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }

        public void EditPhoneNumber()
        {
            var vm = new ManagePhoneNumbersViewModel(dataService);
            vm.UpdatePass(Pass);
            vm.LoadData();
            using (var form = new FrmEditPhoneNumber(vm))
            {
                form.ShowDialog();
            }
            Pass = vm.Pass;
        }
    }
}
