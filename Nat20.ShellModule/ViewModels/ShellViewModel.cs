using Nat20.EventsModule;
using Prism.Commands;
using Prism.Events;
using System.Windows.Input;
using System.Xml.Linq;

namespace Nat20.ShellModule.ViewModels
{
    public class ShellViewModel : IShellViewModel
    {
        public string Title => "Nat20";

        public ICommand LoadCommand { get; }
        public ICommand SaveCommand { get; }

        private string RootSaveFileNodeName => "Nat20Save";

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            LoadCommand = new DelegateCommand(() =>
            {
                var saveDocument = XDocument.Load("TODO/save.xml");
                eventAggregator.GetEvent<LoadEvent>().Publish(new LoadEventArgs(saveDocument.Root));
            });

            SaveCommand = new DelegateCommand(() =>
            {
                var saveLock = new object();
                var saveRootNode = new XElement(RootSaveFileNodeName);

                eventAggregator.GetEvent<SaveEvent>().Publish(new SaveEventArgs(saveData =>
                {
                    // I'm not aware of any reason why this might be accessed concurrently,
                    // but it feels like the kind of thing someone might add later,
                    // hence the lock

                    lock (saveLock)
                    {
                        saveRootNode.Add(saveData);
                    }
                }));

                // TODO: test behaviour with readonly files / missing folders

                var saveDocument = new XDocument(saveRootNode);
                saveDocument.Save("TODO/save.xml");
            });
        }
    }
}
