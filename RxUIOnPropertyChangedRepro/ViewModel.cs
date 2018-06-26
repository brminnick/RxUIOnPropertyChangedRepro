using System;
using System.Threading.Tasks;
using System.Windows.Input;

using ReactiveUI;

namespace RxUIOnPropertyChangedRepro
{
    public class ViewModel : ReactiveObject
    {
        string _goLabelText;
        ICommand _invokeExceptionButtonCommand, _dontInvokeExceptionButtonCommand;

        public event EventHandler<bool> ActivityIndicatorStatusChanged;

        public ICommand InvokeExceptionButtonCommand => _invokeExceptionButtonCommand ??
            (_invokeExceptionButtonCommand = ReactiveCommand.CreateFromTask(async () => await ExecuteButtonCommand(true).ConfigureAwait(false)));

        public ICommand DontInvokeExceptionButtonCommand => _dontInvokeExceptionButtonCommand ??
            (_dontInvokeExceptionButtonCommand = ReactiveCommand.CreateFromTask(async () => await ExecuteButtonCommand(false).ConfigureAwait(false)));

        public string GoLabelText
        {
            get => _goLabelText;
            set => this.RaiseAndSetIfChanged(ref _goLabelText, value);
        }

        async Task ExecuteButtonCommand(bool shouldInvokeException)
        {
            OnActivityIndicatorStatusChanged(true);

            GoLabelText = "Background Task Running";

            if(shouldInvokeException)
                await Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false);
            else
                await Task.Delay(TimeSpan.FromSeconds(2));
            
            GoLabelText = null;

            OnActivityIndicatorStatusChanged(false);
        }

        void OnActivityIndicatorStatusChanged(bool status) => ActivityIndicatorStatusChanged?.Invoke(this, status);
    }
}
