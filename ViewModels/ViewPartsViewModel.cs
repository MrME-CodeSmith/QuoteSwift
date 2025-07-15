using System.ComponentModel;
using System.Collections.Generic;

namespace QuoteSwift
{
    public class ViewPartsViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        Dictionary<string, Part> partList;


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

        public void LoadData()
        {
            PartList = dataService.LoadPartList();
        }

        public void UpdateData(Dictionary<string, Part> parts)
        {
            PartList = parts;
        }

    }
}
