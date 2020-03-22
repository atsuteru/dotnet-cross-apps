using MyApp.Models;
using ReactiveUI;

namespace MyApp.ViewModel
{
    public interface IModelAccessableScreen: IScreen
    {
        IModelHost Model { get; }
    }
}
