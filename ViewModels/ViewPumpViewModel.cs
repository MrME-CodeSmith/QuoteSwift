using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace QuoteSwift
{
    public class ViewPumpViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        BindingList<Pump> pumps;
        readonly ISerializationService serializationService;
        HashSet<string> repairableItemNames;


        public ViewPumpViewModel(IDataService service, ISerializationService serializer)
        {
            dataService = service;
            serializationService = serializer;
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

        public void UpdateData(BindingList<Pump> pumpList)
        {
            Pumps = pumpList;
            if (Pumps != null)
                RepairableItemNames = new HashSet<string>(Pumps.Select(p => StringUtil.NormalizeKey(p.PumpName)));
            else
                RepairableItemNames = new HashSet<string>();
        }

        public void RemovePump(Pump pump)
        {
            if (pump == null || Pumps == null)
                return;

            Pumps.Remove(pump);
            RepairableItemNames?.Remove(StringUtil.NormalizeKey(pump.PumpName));
        }

        public void ExportInventory(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            serializationService.ExportInventory(Pumps, filePath);
        }

        public void SaveChanges()
        {
            if (Pumps != null)
                dataService.SavePumps(Pumps);
        }

    }
}
