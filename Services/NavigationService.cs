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

        public void CreateNewQuote(ApplicationData data, Quote quoteToChange = null, bool changeSpecificObject = false)
        {
            var vm = new CreateQuoteViewModel(dataService);
            using (var form = new FrmCreateQuote(vm, data, quoteToChange, changeSpecificObject))
            {
                form.ShowDialog();
            }
            data.SaveAll();
        }

        public void ViewAllQuotes(ApplicationData data)
        {
            var vm = new QuotesViewModel(dataService);
            vm.UpdateData(data.QuoteMap, data.BusinessList, data.PumpList, data.PartList);
            using (var form = new FrmViewQuotes(vm, this, data))
            {
                form.ShowDialog();
            }
            data.QuoteMap = vm.QuoteMap;
            data.BusinessList = vm.BusinessList;
            data.PumpList = vm.PumpList;
            data.PartList = vm.PartMap;
            data.SaveAll();
        }

        public void ViewAllPumps(ApplicationData data)
        {
            var vm = new ViewPumpViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewPump(vm, this, data))
            {
                form.ShowDialog();
            }
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

        public void ViewAllParts(ApplicationData data)
        {
            var vm = new ViewPartsViewModel(dataService);
            vm.UpdateData(data.PartList);
            using (var form = new FrmViewParts(vm, this, data))
            {
                form.ShowDialog();
            }
        }

        public void AddNewPart(ApplicationData data, Part partToChange = null, bool changeSpecificObject = false)
        {
            var vm = new AddPartViewModel(dataService);
            vm.UpdatePass(data.PartList, data.PumpList, partToChange, changeSpecificObject);
            using (var form = new FrmAddPart(vm, this, data))
            {
                form.ShowDialog();
            }
            data.PartList = vm.PartMap;
            data.PumpList = vm.PumpList;
            data.SaveAll();
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

        public void AddCustomer(ApplicationData data)
        {
            var pass = AddCustomer(new Pass(data.QuoteMap, data.BusinessList, data.PumpList, data.PartList));
            data.BusinessList = pass.PassBusinessList;
            data.SaveAll();
        }

        public void ViewCustomers(ApplicationData data)
        {
            var pass = ViewCustomers(new Pass(data.QuoteMap, data.BusinessList, data.PumpList, data.PartList));
            data.BusinessList = pass.PassBusinessList;
        }

        public void AddBusiness(ApplicationData data)
        {
            var pass = AddBusiness(new Pass(data.QuoteMap, data.BusinessList, data.PumpList, data.PartList));
            data.BusinessList = pass.PassBusinessList;
            data.SaveAll();
        }

        public void ViewBusinesses(ApplicationData data)
        {
            var pass = ViewBusinesses(new Pass(data.QuoteMap, data.BusinessList, data.PumpList, data.PartList));
            data.BusinessList = pass.PassBusinessList;
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
