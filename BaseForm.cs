using System;
using System.Windows.Forms;

namespace QuoteSwift
{
    public abstract class BaseForm : Form
    {
        protected readonly IMessageService messageService;
        protected readonly INavigationService navigation;

        protected BaseForm(IMessageService messageService = null, INavigationService navigation = null)
        {
            this.messageService = messageService;
            this.navigation = navigation;
        }

        protected virtual void OnClose()
        {
            navigation?.SaveAllData();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            OnClose();
            base.OnFormClosing(e);
        }

        /// <summary>
        /// Binds the form's wait cursor to the IsBusy property of the supplied
        /// view model.
        /// </summary>
        protected void BindIsBusy(ViewModelBase viewModel)
        {
            if (viewModel == null)
                return;

            viewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(ViewModelBase.IsBusy))
                {
                    BeginInvoke(new Action(() => UseWaitCursor = viewModel.IsBusy));
                }
            };
        }
    }

    public abstract class BaseForm<TViewModel> : BaseForm
    {
        protected BaseForm(TViewModel viewModel, IMessageService messageService = null, INavigationService navigation = null)
            : base(messageService, navigation)
        {
            ViewModel = viewModel;
        }

        public TViewModel ViewModel { get; }
    }
}
