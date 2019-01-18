using Nat20.EventsModule;
using Prism.Commands;
using Prism.Events;
using System.Windows.Input;

namespace Nat20.ShellModule.ViewModels
{
    public class ShellViewModel : IShellViewModel
    {
        public string Title => "Nat20";

        public ICommand LoadCommand { get; }
        public ICommand SaveCommand { get; }

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            LoadCommand = new DelegateCommand(() =>
            {
                eventAggregator.GetEvent<LoadEvent>().Publish(new LoadEventArgs("TODO"));
            });

            SaveCommand = new DelegateCommand(() =>
            {
                eventAggregator.GetEvent<SaveEvent>().Publish(new SaveEventArgs("TODO"));
            });
        }
    }
}
