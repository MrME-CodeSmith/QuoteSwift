using System;

namespace QuoteSwift
{
    public class NavigationService : INavigationService
    {
        readonly IDataService dataService;
        readonly ApplicationData appData;

        public NavigationService(IDataService service, ApplicationData data)
        {
            dataService = service;
            appData = data;
        }

        public Pass CreateNewQuote(Pass pass)
        {
            var vm = new CreateQuoteViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmCreateQuote(vm, pass))
            {
                form.ShowDialog();
            }
            return pass;
        }

        public Pass ViewAllQuotes(Pass pass)
        {
            var vm = new QuotesViewModel(dataService);
            vm.UpdateData(pass.PassQuoteMap, pass.PassBusinessList, pass.PassPumpList, pass.PassPartList);
            vm.LoadData();
            using (var form = new FrmViewQuotes(vm, this, appData))
            {
                form.ShowDialog();
            }
            pass = new Pass(vm.QuoteMap, vm.BusinessList, vm.PumpList, vm.PartMap);
            return pass;
        }

        public Pass ViewAllPumps(Pass pass)
        {
            var vm = new ViewPumpViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewPump(vm, this, appData))
            {
                form.ShowDialog();
            }
            return pass;
        }

        public void CreateNewPump(ApplicationData data)
        {
            var vm = new AddPumpViewModel(dataService);
            vm.UpdateData(data.PumpList, data.PartList);
            vm.LoadData();
            using (var form = new FrmAddPump(vm, this, data))
            {
                form.ShowDialog();
            }
            data.PumpList = vm.PumpList;
            data.PartList = vm.PartMap;
            data.SaveAll();
        }

        public Pass ViewAllParts(Pass pass)
        {
            var vm = new ViewPartsViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewParts(vm, this, pass))
            {
                form.ShowDialog();
            }
            return pass;
        }

        public Pass AddNewPart(Pass pass)
        {
            var vm = new AddPartViewModel(dataService);
            vm.UpdatePass(pass.PassPartList, pass.PassPumpList, pass.PartToChange, pass.ChangeSpecificObject);
            vm.LoadData();
            using (var form = new FrmAddPart(vm, this))
            {
                form.SetPass(pass);
                form.ShowDialog();
            }
            return pass;
        }

        public Pass AddCustomer(Pass pass)
        {
            var vm = new AddCustomerViewModel(dataService);
            vm.UpdateData(pass.PassBusinessList, pass.CustomerToChange, pass.ChangeSpecificObject);
            vm.LoadData();
            using (var form = new FrmAddCustomer(vm, this))
            {
                form.ShowDialog();
            }
            pass.PassBusinessList = vm.BusinessList;
            pass.CustomerToChange = vm.CustomerToChange;
            pass.ChangeSpecificObject = vm.ChangeSpecificObject;
            return pass;
        }

        public Pass ViewCustomers(Pass pass)
        {
            var vm = new ViewCustomersViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewCustomers(vm, this, pass))
            {
                form.ShowDialog();
            }
            return pass;
        }

        public Pass AddBusiness(Pass pass)
        {
            var vm = new AddBusinessViewModel(dataService);
            vm.UpdateData(pass.PassBusinessList, pass.BusinessToChange, pass.ChangeSpecificObject);
            vm.LoadData();
            using (var form = new FrmAddBusiness(vm, this))
            {
                form.SetPass(pass);
                form.ShowDialog();
            }
            pass.PassBusinessList = vm.BusinessList;
            pass.BusinessToChange = vm.BusinessToChange;
            pass.ChangeSpecificObject = vm.ChangeSpecificObject;
            return pass;
        }

        public Pass ViewBusinesses(Pass pass)
        {
            var vm = new ViewBusinessesViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewAllBusinesses(vm, this, pass))
            {
                form.ShowDialog();
            }
            return pass;
        }

        public Pass ViewBusinessesAddresses(Pass pass)
        {
            var vm = new ViewBusinessAddressesViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewBusinessAddresses(vm, this, appData, pass.BusinessToChange, pass.CustomerToChange))
            {
                form.ShowDialog();
            }
            return pass;
        }

        public Pass ViewBusinessesPOBoxAddresses(Pass pass)
        {
            var vm = new ViewPOBoxAddressesViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewPOBoxAddresses(vm, this, appData, pass.BusinessToChange, pass.CustomerToChange))
            {
                form.ShowDialog();
            }
            return pass;
        }

        public Pass ViewBusinessesEmailAddresses(Pass pass)
        {
            var vm = new ManageEmailsViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmManageAllEmails(vm, this, appData, pass.BusinessToChange, pass.CustomerToChange))
            {
                form.ShowDialog();
            }
            return pass;
        }

        public Pass ViewBusinessesPhoneNumbers(Pass pass)
        {
            var vm = new ManagePhoneNumbersViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmManagingPhoneNumbers(vm, this, appData, pass.BusinessToChange, pass.CustomerToChange))
            {
                form.ShowDialog();
            }
            return pass;
        }

        public Pass EditBusinessAddress(Pass pass)
        {
            using (var form = new FrmEditBusinessAddress(appData, pass.BusinessToChange, pass.CustomerToChange, pass.AddressToChange))
            {
                form.ShowDialog();
            }
            return pass;
        }

        public Pass EditBusinessEmailAddress(Pass pass)
        {
            using (var form = new FrmEditEmailAddress(appData, pass.BusinessToChange, pass.CustomerToChange, pass.EmailToChange))
            {
                form.ShowDialog();
            }
            return pass;
        }

        public Pass EditPhoneNumber(Pass pass)
        {
            using (var form = new FrmEditPhoneNumber(appData, pass.BusinessToChange, pass.CustomerToChange, pass.PhoneNumberToChange))
            {
                form.ShowDialog();
            }
            return pass;
        }
    }
}
