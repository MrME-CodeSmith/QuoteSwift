using System.ComponentModel;
using System.Collections.Generic;

namespace QuoteSwift
{
    public class ViewPumpViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        BindingList<Pump> pumps;
        HashSet<string> repairableItemNames;


        public ViewPumpViewModel(IDataService service)
        {
            dataService = service;
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

        public void LoadData()
        {
            Pumps = dataService.LoadPumpList();
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

    }
}
