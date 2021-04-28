using System;
using System.Threading.Tasks;
using System.Windows.Input;

using ReactiveUI;

namespace RxUIOnPropertyChangedRepro
{
    public class ViewModel : ReactiveObject
    {
        string _goLabelText = string.Empty;

        public ViewModel()
        {
            InvokeExceptionButtonCommand = ReactiveCommand.CreateFromTask(() => ExecuteButtonCommand(true));
            DontInvokeExceptionButtonCommand = ReactiveCommand.CreateFromTask(() => ExecuteButtonCommand(false));
        }

        public event EventHandler<bool>? ActivityIndicatorStatusChanged;

        public ICommand InvokeExceptionButtonCommand { get; }
        public ICommand DontInvokeExceptionButtonCommand { get; }

        public string GoLabelText
        {
            get => _goLabelText;
            set => this.RaiseAndSetIfChanged(ref _goLabelText, value);
        }

        async Task ExecuteButtonCommand(bool shouldInvokeException)
        {
            OnActivityIndicatorStatusChanged(true);

            GoLabelText = "Background Task Running";

            if (shouldInvokeException)
                await Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false);
            else
                await Task.Delay(TimeSpan.FromSeconds(2));

            GoLabelText = string.Empty;

            OnActivityIndicatorStatusChanged(false);
        }

        void OnActivityIndicatorStatusChanged(bool status) => ActivityIndicatorStatusChanged?.Invoke(this, status);
    }
}
