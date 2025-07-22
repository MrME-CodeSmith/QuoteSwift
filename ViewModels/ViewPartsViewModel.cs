using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuoteSwift
{
    public class ViewPartsViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        readonly INavigationService navigation;
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


        public ViewPartsViewModel(IDataService service, INavigationService navigation = null)
        {
            dataService = service;
            this.navigation = navigation;
            mandatoryParts = new BindingList<Part>();
            nonMandatoryParts = new BindingList<Part>();
            allParts = new BindingList<Part>();
            LoadDataCommand = CreateLoadCommand(LoadDataAsync);
            AddPartCommand = new RelayCommand(_ => AddPart());
            UpdatePartCommand = new RelayCommand(_ => UpdatePart(), _ => SelectedPart != null);
            RemovePartCommand = new RelayCommand(_ => RemoveSelectedPart(), _ => SelectedPart != null);
            SaveChangesCommand = new RelayCommand(_ => SaveChanges());
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

        public void LoadData()
        {
            LoadDataAsync().GetAwaiter().GetResult();
        }

        public async Task LoadDataAsync()
        {
            PartList = await dataService.LoadPartListAsync();
            RefreshLists();
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

        void AddPart()
        {
            navigation?.AddNewPart();
            LoadData();
        }

        void UpdatePart()
        {
            if (SelectedPart != null)
            {
                navigation?.AddNewPart(SelectedPart, false);
                LoadData();
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
