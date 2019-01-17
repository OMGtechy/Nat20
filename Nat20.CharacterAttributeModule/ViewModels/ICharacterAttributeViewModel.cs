namespace Nat20.CharacterAttributeModule.ViewModels
{
    public interface ICharacterAttributeViewModel
    {
        string StrengthLabel { get; }
        int StrengthValue { get; }
        string DexterityLabel { get; }
        int DexterityValue { get; }
        string ConstitutionLabel { get; }
        int ConstitutionValue { get; }
        string IntelligenceLabel { get; }
        int IntelligenceValue { get; }
        string WisdomLabel { get; }
        int WisdomValue { get; }
    }
}