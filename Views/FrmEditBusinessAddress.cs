using System;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmEditBusinessAddress : BaseForm<EditBusinessAddressViewModel>
    {
        readonly IMessageService messageService;
        readonly INavigationService navigation;

        public FrmEditBusinessAddress(EditBusinessAddressViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.messageService = messageService;
            this.navigation = navigation;
            ViewModel.CloseAction = Close;
            BindIsBusy(ViewModel);
            SetupBindings();
        }

        void SetupBindings()
        {
            txtBusinessAddresssDescription.DataBindings.Add("Text", ViewModel, nameof(EditBusinessAddressViewModel.AddressDescription), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtStreetnumber.DataBindings.Add("Text", ViewModel, nameof(EditBusinessAddressViewModel.StreetNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            txtStreetName.DataBindings.Add("Text", ViewModel, nameof(EditBusinessAddressViewModel.StreetName), false, DataSourceUpdateMode.OnPropertyChanged);
            txtSuburb.DataBindings.Add("Text", ViewModel, nameof(EditBusinessAddressViewModel.Suburb), false, DataSourceUpdateMode.OnPropertyChanged);
            txtCity.DataBindings.Add("Text", ViewModel, nameof(EditBusinessAddressViewModel.City), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtAreaCode.DataBindings.Add("Text", ViewModel, nameof(EditBusinessAddressViewModel.AreaCode), false, DataSourceUpdateMode.OnPropertyChanged);

            CommandBindings.Bind(BtnUpdateAddress, ViewModel.SaveCommand);
            CommandBindings.Bind(BtnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
        }

        private void FrmEditBusinessAddress_Load(object sender, EventArgs e)
        {
            if (ViewModel.Address != null)
            {
                txtStreetName.Enabled = false;
            }
        }



        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        
    }
}
