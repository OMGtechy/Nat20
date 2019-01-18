using Prism.Events;

namespace Nat20.EventsModule
{
    public class LoadEvent : PubSubEvent<LoadEventArgs>
    {

    }

    public class LoadEventArgs
    {
        public LoadEventArgs(string folder)
        {
            Folder = folder;
        }

        public string Folder { get; }
    }
}
