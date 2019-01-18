using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nat20.CharacterAttributeModule.ViewModels;
using System.Xml.Linq;

namespace Nat20.CharacterAttributeModule.Test
{
    [TestClass]
    public class CharacterAttributeModuleTests
    {
        /// <summary>
        /// Checks whether some simple data can be loaded into a CharacterAttributeViewModel properly
        /// </summary>
        [TestMethod]
        public void TestLoad()
        {
            var viewModel = new CharacterAttributeViewModel(null);

            Assert.IsTrue(CharacterAttributeViewModel.Load(viewModel, new XElement
            (
                // note that string literals are used instead of the constants deliberately,
                // we want the tests to fail if some breaking change is made to them internally
                "CharacterAttributes",
                new XAttribute("Strength", 42),     // the best number
                new XAttribute("Dexterity", 180),   // for all your darts fans out there
                new XAttribute("Constitution", 1),  // on a scale of 1 to 10, how much I like darts
                new XAttribute("Intelligence", -1), // sampled from Donald Trump
                new XAttribute("Wisdom", 25)        // one for you to work out
            )));

            Assert.AreEqual(42, viewModel.StrengthValue);
            Assert.AreEqual(180, viewModel.DexterityValue);
            Assert.AreEqual(1, viewModel.ConstitutionValue);
            Assert.AreEqual(-1, viewModel.IntelligenceValue);
            Assert.AreEqual(25, viewModel.WisdomValue);
        }
    }
}
