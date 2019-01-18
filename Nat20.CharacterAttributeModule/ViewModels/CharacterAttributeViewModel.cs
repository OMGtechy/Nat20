using Nat20.EventsModule;
using Prism.Events;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.ComponentModel;

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

        private string strengthAttributeName = "Strength";
        private string dexterityAttributeName = "Dexterity";
        private string constitutionAttributeName = "Constitution";
        private string intelligenceAttributeName = "Intelligence";
        private string wisdomAttributeName = "Wisdom";

        private string characterAttributesRootNodeName = "CharacterAttributes";
        private string characterAttributesFileName = "CharacterAttributes.xml";

        public event PropertyChangedEventHandler PropertyChanged;

        public CharacterAttributeViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<SaveEvent>().Subscribe(args =>
            {
                var saveData = new XElement
                (
                    characterAttributesRootNodeName,
                    new[]
                    {
                        new KeyValuePair<string, int>(strengthAttributeName, StrengthValue),
                        new KeyValuePair<string, int>(dexterityAttributeName, DexterityValue),
                        new KeyValuePair<string, int>(constitutionAttributeName, ConstitutionValue),
                        new KeyValuePair<string, int>(intelligenceAttributeName, IntelligenceValue),
                        new KeyValuePair<string, int>(wisdomAttributeName, WisdomValue)
                    }.Select(attribute => new XAttribute(attribute.Key, attribute.Value)).ToArray()
                );

                args.Callback(saveData);
            });

            eventAggregator.GetEvent<LoadEvent>().Subscribe(args =>
            {
                // TODO: check for missing data?
                // TODO: error checking for int parsing

                var characterAttributesNode = args.RootNode.Element(characterAttributesRootNodeName);

                StrengthValue =     int.Parse(characterAttributesNode.Attribute(strengthAttributeName).Value);
                DexterityValue =    int.Parse(characterAttributesNode.Attribute(dexterityAttributeName).Value);
                ConstitutionValue = int.Parse(characterAttributesNode.Attribute(constitutionAttributeName).Value);
                IntelligenceValue = int.Parse(characterAttributesNode.Attribute(intelligenceAttributeName).Value);
                WisdomValue =       int.Parse(characterAttributesNode.Attribute(wisdomAttributeName).Value);
            });
        }
    }
}