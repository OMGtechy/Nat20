using Nat20.ShellModule.ViewModels;
using System.Windows;

namespace Nat20.ShellModule
{
    public partial class Shell : Window
    {
        public Shell(IShellViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
