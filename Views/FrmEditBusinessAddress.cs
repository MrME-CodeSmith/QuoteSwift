using System;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmEditBusinessAddress : BaseForm
    {
        readonly IMessageService messageService;
        readonly INavigationService navigation;
        readonly EditBusinessAddressViewModel viewModel;
        public EditBusinessAddressViewModel ViewModel => viewModel;

        public FrmEditBusinessAddress(EditBusinessAddressViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null)
            : base(messageService, navigation)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.messageService = messageService;
            this.navigation = navigation;
            viewModel.CloseAction = Close;
            BindIsBusy(viewModel);
            SetupBindings();
        }

        void SetupBindings()
        {
            txtBusinessAddresssDescription.DataBindings.Add("Text", viewModel, nameof(EditBusinessAddressViewModel.AddressDescription), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtStreetnumber.DataBindings.Add("Text", viewModel, nameof(EditBusinessAddressViewModel.StreetNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            txtStreetName.DataBindings.Add("Text", viewModel, nameof(EditBusinessAddressViewModel.StreetName), false, DataSourceUpdateMode.OnPropertyChanged);
            txtSuburb.DataBindings.Add("Text", viewModel, nameof(EditBusinessAddressViewModel.Suburb), false, DataSourceUpdateMode.OnPropertyChanged);
            txtCity.DataBindings.Add("Text", viewModel, nameof(EditBusinessAddressViewModel.City), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtAreaCode.DataBindings.Add("Text", viewModel, nameof(EditBusinessAddressViewModel.AreaCode), false, DataSourceUpdateMode.OnPropertyChanged);

            CommandBindings.Bind(BtnUpdateAddress, viewModel.SaveCommand);
            CommandBindings.Bind(BtnCancel, viewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);
        }

        private void FrmEditBusinessAddress_Load(object sender, EventArgs e)
        {
            if (viewModel.Address != null)
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
