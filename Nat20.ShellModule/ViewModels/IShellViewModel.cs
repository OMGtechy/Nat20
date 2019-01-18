using System.Windows.Input;

namespace Nat20.ShellModule.ViewModels
{
    public interface IShellViewModel
    {
        string Title { get; }
        ICommand LoadCommand { get; }
        ICommand SaveCommand { get; }
    }
}