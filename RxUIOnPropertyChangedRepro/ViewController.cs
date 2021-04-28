using System;

using ReactiveUI;

namespace RxUIOnPropertyChangedRepro
{
    public partial class ViewController : ReactiveViewController, IViewFor<ViewModel>
    {
        ViewModel? _viewModel;

        public ViewModel? ViewModel
        {
            get => _viewModel;
            set => this.RaiseAndSetIfChanged(ref _viewModel, value);
        }

        object? IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ViewModel?)value;
        }

        protected ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewModel = new ViewModel();
            ViewModel.ActivityIndicatorStatusChanged += HandleActivityIndicatorStatusChanged;


            this.Bind(ViewModel, viewModel => viewModel.GoLabelText, view => view.GoLabel.Text);
            this.BindCommand(ViewModel, viewModel => viewModel.InvokeExceptionButtonCommand, view => view.InvokeExceptionButton);
            this.BindCommand(ViewModel, viewModel => viewModel.DontInvokeExceptionButtonCommand, view => view.DontInvokeExceptionButton);
        }

        void HandleActivityIndicatorStatusChanged(object sender, bool shouldRun)
        {
            InvokeOnMainThread(() =>
            {
                if (shouldRun)
                    ActivityIndicator.StartAnimating();
                else
                    ActivityIndicator.StopAnimating();
            });
        }
    }
}
