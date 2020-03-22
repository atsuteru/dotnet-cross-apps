using MyApp.Models;
using ReactiveUI;

namespace MyApp.ViewModel
{
    public interface IModelHostableScreen: IScreen
    {
        IModelHost Model { get; }
    }

}
