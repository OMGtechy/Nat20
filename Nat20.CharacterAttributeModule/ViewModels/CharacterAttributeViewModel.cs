namespace Nat20.CharacterAttributeModule.ViewModels
{
    public class CharacterAttributeViewModel : ICharacterAttributeViewModel
    {
        public string StrengthLabel => "Strength";
        public int StrengthValue => 42;

        public string DexterityLabel => "Dexterity";
        public int DexterityValue => 180;

        public string ConstitutionLabel => "Constitution";
        public int ConstitutionValue => 99;

        public string IntelligenceLabel => "Intelligence";
        public int IntelligenceValue => 1;

        public string WisdomLabel => "Wisdom";
        public int WisdomValue => 360;
    }
}