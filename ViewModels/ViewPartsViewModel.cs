using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace QuoteSwift
{
    public class ViewPartsViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        Dictionary<string, Part> partList;
        BindingList<Part> mandatoryParts;
        BindingList<Part> nonMandatoryParts;


        public ViewPartsViewModel(IDataService service)
        {
            dataService = service;
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

        public BindingList<Part> MandatoryParts
        {
            get => mandatoryParts;
            private set
            {
                mandatoryParts = value;
                OnPropertyChanged(nameof(MandatoryParts));
            }
        }

        public BindingList<Part> NonMandatoryParts
        {
            get => nonMandatoryParts;
            private set
            {
                nonMandatoryParts = value;
                OnPropertyChanged(nameof(NonMandatoryParts));
            }
        }

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
                MandatoryParts?.Remove(part);
            else
                NonMandatoryParts?.Remove(part);
        }

        void RefreshLists()
        {
            if (PartList != null)
            {
                MandatoryParts = new BindingList<Part>(PartList.Values.Where(p => p.MandatoryPart).ToList());
                NonMandatoryParts = new BindingList<Part>(PartList.Values.Where(p => !p.MandatoryPart).ToList());
            }
            else
            {
                MandatoryParts = new BindingList<Part>();
                NonMandatoryParts = new BindingList<Part>();
            }
        }

    }
}
