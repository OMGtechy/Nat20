using Prism.Events;
using System.Xml.Linq;

namespace Nat20.EventsModule
{
    public class LoadEvent : PubSubEvent<LoadEventArgs>
    {

    }

    public class LoadEventArgs
    {
        public LoadEventArgs(XElement rootNode)
        {
            RootNode = rootNode;
        }

        public XElement RootNode { get; }
    }
}
