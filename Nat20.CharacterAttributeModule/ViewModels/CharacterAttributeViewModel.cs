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

        private string StrengthAttributeName => "Strength";
        private string DexterityAttributeName => "Dexterity";
        private string ConstitutionAttributeName => "Constitution";
        private string IntelligenceAttributeName => "Intelligence";
        private string WisdomAttributeName => "Wisdom";

        private string CharacterAttributesRootNodeName => "CharacterAttributes";

        public event PropertyChangedEventHandler PropertyChanged;

        public CharacterAttributeViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<SaveEvent>().Subscribe(args =>
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

            eventAggregator.GetEvent<LoadEvent>().Subscribe(args =>
            {
                // TODO: check for missing data?
                // TODO: error checking for int parsing

                var characterAttributesNode = args.RootNode.Element(CharacterAttributesRootNodeName);

                StrengthValue = int.Parse(characterAttributesNode.Attribute(StrengthAttributeName).Value);
                DexterityValue = int.Parse(characterAttributesNode.Attribute(DexterityAttributeName).Value);
                ConstitutionValue = int.Parse(characterAttributesNode.Attribute(ConstitutionAttributeName).Value);
                IntelligenceValue = int.Parse(characterAttributesNode.Attribute(IntelligenceAttributeName).Value);
                WisdomValue = int.Parse(characterAttributesNode.Attribute(WisdomAttributeName).Value);
            });
        }
    }
}