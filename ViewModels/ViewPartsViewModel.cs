using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace QuoteSwift
{
    public class ViewPartsViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        Dictionary<string, Part> partList;
        readonly BindingList<Part> mandatoryParts;
        readonly BindingList<Part> nonMandatoryParts;
        readonly BindingList<Part> allParts;


        public ViewPartsViewModel(IDataService service)
        {
            dataService = service;
            mandatoryParts = new BindingList<Part>();
            nonMandatoryParts = new BindingList<Part>();
            allParts = new BindingList<Part>();
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

        public void LoadData()
        {
            PartList = dataService.LoadPartList();
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
