namespace Nat20.CharacterAttributeModule.ViewModels
{
    public interface ICharacterAttributeViewModel
    {
        string StrengthLabel { get; }
        int StrengthValue { get; set; }
        string DexterityLabel { get; }
        int DexterityValue { get; set; }
        string ConstitutionLabel { get; }
        int ConstitutionValue { get; set; }
        string IntelligenceLabel { get; }
        int IntelligenceValue { get; set; }
        string WisdomLabel { get; }
        int WisdomValue { get; set; }
    }
}