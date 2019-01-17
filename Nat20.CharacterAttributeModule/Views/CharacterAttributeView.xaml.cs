using Nat20.CharacterAttributeModule.ViewModels;
using System.Windows.Controls;

namespace Nat20.CharacterAttributeModule.Views
{
    public partial class CharacterAttributeView : UserControl, ICharacterAttributeView
    {
        public CharacterAttributeView(ICharacterAttributeViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
