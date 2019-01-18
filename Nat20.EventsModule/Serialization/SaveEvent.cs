using Prism.Events;
using System;
using System.Xml.Linq;

namespace Nat20.EventsModule
{
    public class SaveEvent : PubSubEvent<SaveEventArgs>
    {

    }

    public class SaveEventArgs
    {
        public SaveEventArgs(Action<XElement> callback)
        {
            Callback = callback;
        }

        public Action<XElement> Callback { get; }
    }
}
