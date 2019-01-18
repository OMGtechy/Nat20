using Nat20.EventsModule;
using Prism.Events;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace Nat20.CharacterAttributeModule.ViewModels
{
    public class CharacterAttributeViewModel : ICharacterAttributeViewModel, INotifyPropertyChanged
    {
        public string StrengthLabel => "Strength";
        private int strengthValue;
        public int StrengthValue
        {
            get { return strengthValue; }
            set
            {
                strengthValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StrengthValue)));
            }
        }

        public string DexterityLabel => "Dexterity";
        private int dexterityValue;
        public int DexterityValue
        {
            get { return dexterityValue; }
            set
            {
                dexterityValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DexterityValue)));
            }
        }
        public string ConstitutionLabel => "Constitution";
        private int constitutionValue;
        public int ConstitutionValue
        {
            get { return constitutionValue; }
            set
            {
                constitutionValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConstitutionValue)));
            }
        }

        public string IntelligenceLabel => "Intelligence";
        private int intelligenceValue;
        public int IntelligenceValue
        {
            get { return intelligenceValue; }
            set
            {
                intelligenceValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IntelligenceValue)));
            }
        }

        public string WisdomLabel => "Wisdom";
        private int wisdomValue;
        public int WisdomValue
        {
            get { return wisdomValue; }
            set
            {
                wisdomValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WisdomValue)));
            }
        }

        private static string StrengthAttributeName => "Strength";
        private static string DexterityAttributeName => "Dexterity";
        private static string ConstitutionAttributeName => "Constitution";
        private static string IntelligenceAttributeName => "Intelligence";
        private static string WisdomAttributeName => "Wisdom";

        private static string CharacterAttributesRootNodeName => "CharacterAttributes";

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Creates an instance of CharacterAttributeViewModel.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator. May be null when under test.</param>
        public CharacterAttributeViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator?.GetEvent<SaveEvent>().Subscribe(args =>
            {
                var saveData = new XElement
                (
                    CharacterAttributesRootNodeName,
                    new[]
                    {
                        new KeyValuePair<string, int>(StrengthAttributeName, StrengthValue),
                        new KeyValuePair<string, int>(DexterityAttributeName, DexterityValue),
                        new KeyValuePair<string, int>(ConstitutionAttributeName, ConstitutionValue),
                        new KeyValuePair<string, int>(IntelligenceAttributeName, IntelligenceValue),
                        new KeyValuePair<string, int>(WisdomAttributeName, WisdomValue)
                    }.Select(attribute => new XAttribute(attribute.Key, attribute.Value)).ToArray()
                );

                args.Callback(saveData);
            });

            eventAggregator?.GetEvent<LoadEvent>().Subscribe(args =>
            {
                // TODO: what if the node is missing?
                // TODO: what if false is returned?
                Load(this, args.RootNode.Element(CharacterAttributesRootNodeName));
            });
        }

        /// <summary>
        /// Loads save data into a CharacterAttributeViewModel.
        /// This is exposed as a method so that it can be tested more easily.
        /// </summary>
        /// <param name="target">Which CharacterAttributeViewModel to write the data to.</param>
        /// <param name="characterAttributesNode">The save data to load.</param>
        /// <returns>True if loading succeeded, false otherwise.</returns>
        public static bool Load(CharacterAttributeViewModel target, XElement characterAttributesNode)
        {
            // TODO: check for missing data?
            // TODO: error checking for int parsing

            target.StrengthValue = int.Parse(characterAttributesNode.Attribute(StrengthAttributeName).Value);
            target.DexterityValue = int.Parse(characterAttributesNode.Attribute(DexterityAttributeName).Value);
            target.ConstitutionValue = int.Parse(characterAttributesNode.Attribute(ConstitutionAttributeName).Value);
            target.IntelligenceValue = int.Parse(characterAttributesNode.Attribute(IntelligenceAttributeName).Value);
            target.WisdomValue = int.Parse(characterAttributesNode.Attribute(WisdomAttributeName).Value);

            return true;
        }
    }
}