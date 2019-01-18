using Prism.Events;

namespace Nat20.EventsModule
{
    public class SaveEvent : PubSubEvent<SaveEventArgs>
    {

    }

    public class SaveEventArgs
    {
        public SaveEventArgs(string folder)
        {
            Folder = folder;
        }

        public string Folder { get; }
    }
}
