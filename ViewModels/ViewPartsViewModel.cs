using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuoteSwift
{
    public class ViewPartsViewModel : ViewModelBase, ILoadableViewModel
    {
        readonly IDataService dataService;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly IApplicationService applicationService;
        readonly ApplicationData appData;
        Dictionary<string, Part> partList;
        readonly BindingList<Part> mandatoryParts;
        readonly BindingList<Part> nonMandatoryParts;
        readonly BindingList<Part> allParts;
        Part selectedPart;
        public ICommand LoadDataCommand { get; }
        public ICommand AddPartCommand { get; }
        public ICommand UpdatePartCommand { get; }
        public ICommand RemovePartCommand { get; }
        public ICommand SaveChangesCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand ExitCommand { get; }

        public Action CloseAction { get; set; }


        public ViewPartsViewModel(IDataService service, ApplicationData appData, INavigationService navigation = null, IMessageService messageService = null, IApplicationService applicationService = null)
        {
            dataService = service;
            this.appData = appData;
            this.navigation = navigation;
            this.messageService = messageService;
            this.applicationService = applicationService;
            mandatoryParts = new BindingList<Part>();
            nonMandatoryParts = new BindingList<Part>();
            allParts = new BindingList<Part>();
            LoadDataCommand = CreateLoadCommand(LoadDataAsync);
            AddPartCommand = new AsyncRelayCommand(_ => AddPartAsync());
            UpdatePartCommand = new AsyncRelayCommand(_ => UpdatePartAsync(), _ => Task.FromResult(SelectedPart != null));
            RemovePartCommand = new RelayCommand(_ => RemoveSelectedPart(), _ => SelectedPart != null);
            SaveChangesCommand = new RelayCommand(_ => SaveChanges());

            CancelCommand = CreateCancelCommand(
                () => CloseAction?.Invoke(),
                messageService,
                "Are you sure you want to cancel the current action?\nCancellation can cause any changes to this current window to be lost.");

            ExitCommand = CreateExitCommand(() =>
            {
                navigation?.SaveAllData();
                applicationService?.Exit();
            }, messageService);
        }

        public IDataService DataService => dataService;

        public Dictionary<string, Part> PartList
        {
            get => partList;
            private set
            {
                partList = value;
                OnPropertyChanged(nameof(PartList));
            }
        }

        public BindingList<Part> MandatoryParts => mandatoryParts;

        public BindingList<Part> NonMandatoryParts => nonMandatoryParts;

        public BindingList<Part> AllParts => allParts;

        public Part SelectedPart
        {
            get => selectedPart;
            set
            {
                if (SetProperty(ref selectedPart, value))
                {
                    ((RelayCommand)UpdatePartCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)RemovePartCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public async Task LoadDataAsync()
        {
            PartList = appData.PartList;
            RefreshLists();
            await Task.CompletedTask;
        }

        public void UpdateData(Dictionary<string, Part> parts)
        {
            PartList = parts;
            RefreshLists();
        }

        public void RemovePart(Part part)
        {
            if (part == null)
                return;

            string key = StringUtil.NormalizeKey(part.OriginalItemPartNumber);
            PartList?.Remove(key);
            if (part.MandatoryPart)
                mandatoryParts.Remove(part);
            else
                nonMandatoryParts.Remove(part);
            allParts.Remove(part);
        }

        async Task AddPartAsync()
        {
            if (navigation != null) await navigation.AddNewPart();
            await LoadDataAsync();
        }

        async Task UpdatePartAsync()
        {
            if (SelectedPart != null)
            {
                if (navigation != null) await navigation.AddNewPart(SelectedPart, false);
                await LoadDataAsync();
            }
        }

        void RemoveSelectedPart()
        {
            RemovePart(SelectedPart);
        }

        public void SaveChanges()
        {
            if (PartList != null)
                dataService.SaveParts(PartList);
        }

        void RefreshLists()
        {
            mandatoryParts.Clear();
            nonMandatoryParts.Clear();
            allParts.Clear();

            if (PartList != null)
            {
                foreach (var p in PartList.Values)
                {
                    allParts.Add(p);
                    if (p.MandatoryPart)
                        mandatoryParts.Add(p);
                    else
                        nonMandatoryParts.Add(p);
                }
            }

            mandatoryParts.ResetBindings();
            nonMandatoryParts.ResetBindings();
            allParts.ResetBindings();
        }

    }
}
