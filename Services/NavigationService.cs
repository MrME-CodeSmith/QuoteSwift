using System;

namespace QuoteSwift
{
    public class NavigationService : INavigationService
    {
        readonly IDataService dataService;
        SortedDictionary<string, Quote> quoteMap;
        BindingList<Business> businessList;
        BindingList<Pump> pumpList;
        Dictionary<string, Part> partMap;

        public NavigationService(IDataService service)
        {
            dataService = service;
            quoteMap = dataService.LoadQuoteMap();
            businessList = dataService.LoadBusinessList();
            pumpList = dataService.LoadPumpList();
            partMap = dataService.LoadPartList();
        }

        void AssignCollections(Pass pass)
        {
            if (pass == null) return;
            pass.PassQuoteMap = quoteMap;
            pass.PassBusinessList = businessList;
            pass.PassPumpList = pumpList;
            pass.PassPartList = partMap;
        }

        public void CreateNewQuote(Pass pass)
        {
            AssignCollections(pass);
            var vm = new CreateQuoteViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmCreateQuote(vm))
            {
                form.ShowDialog();
            }
            quoteMap = vm.Pass.PassQuoteMap;
            businessList = vm.Pass.PassBusinessList;
            pumpList = vm.Pass.PassPumpList;
            partMap = vm.Pass.PassPartList;
        }

        public void ViewAllQuotes(Pass pass)
        {
            AssignCollections(pass);
            var vm = new QuotesViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmViewQuotes(vm, this))
            {
                form.ShowDialog();
            }
            quoteMap = vm.Pass.PassQuoteMap;
            businessList = vm.Pass.PassBusinessList;
            pumpList = vm.Pass.PassPumpList;
            partMap = vm.Pass.PassPartList;
        }

        public void ViewAllPumps(Pass pass)
        {
            AssignCollections(pass);
            var vm = new ViewPumpViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmViewPump(vm, this))
            {
                form.ShowDialog();
            }
            pumpList = vm.Pass.PassPumpList;
        }

        public void CreateNewPump(Pass pass)
        {
            AssignCollections(pass);
            var vm = new AddPumpViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmAddPump(vm, this))
            {
                form.ShowDialog();
            }
            pumpList = vm.Pass.PassPumpList;
        }

        public void ViewAllParts(Pass pass)
        {
            AssignCollections(pass);
            var vm = new ViewPartsViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmViewParts(vm, this))
            {
                form.ShowDialog();
            }
            partMap = vm.Pass.PassPartList;
        }

        public void AddNewPart(Pass pass)
        {
            AssignCollections(pass);
            var vm = new AddPartViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmAddPart(vm, this))
            {
                form.ShowDialog();
            }
            partMap = vm.Pass.PassPartList;
        }

        public void AddCustomer(Pass pass)
        {
            AssignCollections(pass);
            var vm = new AddCustomerViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmAddCustomer(vm, this))
            {
                form.ShowDialog();
            }
            businessList = vm.Pass.PassBusinessList;
            quoteMap = vm.Pass.PassQuoteMap;
        }

        public void ViewCustomers(Pass pass)
        {
            AssignCollections(pass);
            var vm = new ViewCustomersViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmViewCustomers(vm, this))
            {
                form.ShowDialog();
            }
        }

        public void AddBusiness(Pass pass)
        {
            AssignCollections(pass);
            var vm = new AddBusinessViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmAddBusiness(vm, this))
            {
                form.ShowDialog();
            }
            businessList = vm.Pass.PassBusinessList;
        }

        public void ViewBusinesses(Pass pass)
        {
            AssignCollections(pass);
            var vm = new ViewBusinessesViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmViewAllBusinesses(vm, this))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesAddresses(Pass pass)
        {
            AssignCollections(pass);
            var vm = new ViewBusinessAddressesViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmViewBusinessAddresses(vm, this))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesPOBoxAddresses(Pass pass)
        {
            AssignCollections(pass);
            var vm = new ViewPOBoxAddressesViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmViewPOBoxAddresses(vm, this))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesEmailAddresses(Pass pass)
        {
            AssignCollections(pass);
            var vm = new ManageEmailsViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmManageAllEmails(vm, this))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesPhoneNumbers(Pass pass)
        {
            AssignCollections(pass);
            var vm = new ManagePhoneNumbersViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmManagingPhoneNumbers(vm, this))
            {
                form.ShowDialog();
            }
        }

        public void EditBusinessAddress(Pass pass)
        {
            AssignCollections(pass);
            var vm = new ViewBusinessAddressesViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmEditBusinessAddress(vm))
            {
                form.ShowDialog();
            }
        }

        public void EditBusinessEmailAddress(Pass pass)
        {
            AssignCollections(pass);
            var vm = new ManageEmailsViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmEditEmailAddress(vm))
            {
                form.ShowDialog();
            }
        }

        public void EditPhoneNumber(Pass pass)
        {
            AssignCollections(pass);
            var vm = new ManagePhoneNumbersViewModel(dataService);
            vm.UpdatePass(pass);
            using (var form = new FrmEditPhoneNumber(vm))
            {
                form.ShowDialog();
            }
        }
    }
}
