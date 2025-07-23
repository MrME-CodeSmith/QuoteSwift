using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;

namespace QuoteSwift
{
    public class ViewPumpViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        BindingList<Pump> pumps;
        readonly ISerializationService serializationService;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly IFileDialogService fileDialogService;
        readonly IApplicationService applicationService;
        HashSet<string> repairableItemNames;

        Pump selectedPump;

        public ICommand LoadDataCommand { get; }
        public ICommand AddPumpCommand { get; }
        public ICommand UpdatePumpCommand { get; }
        public ICommand RemovePumpCommand { get; }
        public ICommand ExportInventoryCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand CancelCommand { get; }

        public Action CloseAction { get; set; }


        public ViewPumpViewModel(IDataService service, ISerializationService serializer,
                                 INavigationService navigation = null, IMessageService messageService = null,
                                 IFileDialogService dialogService = null, IApplicationService applicationService = null)
        {
            dataService = service;
            serializationService = serializer;
            this.navigation = navigation;
            this.messageService = messageService;
            fileDialogService = dialogService;
            this.applicationService = applicationService;
            LoadDataCommand = CreateLoadCommand(LoadDataAsync);
            AddPumpCommand = new AsyncRelayCommand(_ => AddPumpAsync());
            UpdatePumpCommand = new AsyncRelayCommand(_ => UpdatePumpAsync(), _ => Task.FromResult(SelectedPump != null));
            RemovePumpCommand = new RelayCommand(_ => RemoveSelectedPump(), _ => SelectedPump != null);
            ExportInventoryCommand = new AsyncRelayCommand((_, t) => ExportInventoryActionAsync(t));
            ExitCommand = CreateExitCommand(() =>
            {
                navigation?.SaveAllData();
                applicationService?.Exit();
            }, messageService);

            CancelCommand = CreateCancelCommand(() => CloseAction?.Invoke(), messageService);
        }

        public IDataService DataService => dataService;

        public BindingList<Pump> Pumps
        {
            get => pumps;
            private set
            {
                pumps = value;
                OnPropertyChanged(nameof(Pumps));
            }
        }

        public HashSet<string> RepairableItemNames
        {
            get => repairableItemNames;
            set
            {
                repairableItemNames = value;
                OnPropertyChanged(nameof(RepairableItemNames));
            }
        }

        public Pump SelectedPump
        {
            get => selectedPump;
            set
            {
                if (SetProperty(ref selectedPump, value))
                {
                    ((AsyncRelayCommand)UpdatePumpCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)RemovePumpCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public async Task LoadDataAsync()
        {
            Pumps = await dataService.LoadPumpListAsync();
            if (Pumps != null)
            {
                var set = new HashSet<string>();
                foreach (var p in Pumps)
                    set.Add(StringUtil.NormalizeKey(p.PumpName));
                RepairableItemNames = set;
            }
            else
            {
                RepairableItemNames = new HashSet<string>();
            }
        }

        public void UpdateData(BindingList<Pump> pumpList)
        {
            Pumps = pumpList;
            if (Pumps != null)
                RepairableItemNames = new HashSet<string>(Pumps.Select(p => StringUtil.NormalizeKey(p.PumpName)));
            else
                RepairableItemNames = new HashSet<string>();
        }

        void RefreshRepairableNames()
        {
            if (Pumps != null)
                RepairableItemNames = new HashSet<string>(Pumps.Select(p => StringUtil.NormalizeKey(p.PumpName)));
            else
                RepairableItemNames = new HashSet<string>();
        }

        async Task AddPumpAsync()
        {
            if (navigation != null)
                await navigation.CreateNewPump();
            RefreshRepairableNames();
        }

        async Task UpdatePumpAsync()
        {
            if (SelectedPump != null)
            {
                if (navigation != null)
                    await navigation.CreateNewPump();
                RefreshRepairableNames();
            }
            else
            {
                messageService?.ShowError("The current selection is invalid.\nPlease choose a valid Pump from the list.", "ERROR - Invalid Selection");
            }
        }

        void RemoveSelectedPump()
        {
            if (SelectedPump != null)
            {
                if (messageService?.RequestConfirmation($"Are you sure you want to permanently delete {SelectedPump.PumpName} pump from the list of pumps?", "REQUEST - Deletion Request") == true)
                {
                    RemovePump(SelectedPump);
                    messageService?.ShowInformation($"Successfully deleted {SelectedPump.PumpName} from the pump list", "INFORMATION - Deletion Success");
                }
            }
            else
            {
                messageService?.ShowError("The current selection is invalid.\nPlease choose a valid Pump from the list.", "ERROR - Invalid Selection");
            }
        }

        async Task ExportInventoryActionAsync(System.Threading.CancellationToken token)
        {
            string filePath = fileDialogService?.ShowSaveFileDialog(
                "CSV files (*.csv)|*.csv|All Files (*.*)|*.*",
                "csv",
                "Inventory.csv");

            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    await ExportInventoryAsync(filePath, token);
                    messageService?.ShowInformation("Inventory exported successfully.", "INFORMATION - Export Successful");
                }
                catch (Exception ex)
                {
                    messageService?.ShowError("Inventory export failed.\n" + ex.Message, "ERROR - Export Failed");
                }
            }
        }

        public void RemovePump(Pump pump)
        {
            if (pump == null || Pumps == null)
                return;

            Pumps.Remove(pump);
            RepairableItemNames?.Remove(StringUtil.NormalizeKey(pump.PumpName));
        }

        public Task ExportInventoryAsync(string filePath, System.Threading.CancellationToken token)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            if (token.IsCancellationRequested)
                return Task.CompletedTask;

            serializationService.ExportInventory(Pumps, filePath);
            return Task.CompletedTask;
        }

        public void SaveChanges()
        {
            if (Pumps != null)
                dataService.SavePumps(Pumps);
        }

    }
}
