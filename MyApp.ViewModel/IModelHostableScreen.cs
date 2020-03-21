using MyApp.Models;
using ReactiveUI;
using System.Reactive.Concurrency;

namespace MyApp.ViewModel
{
    public interface IModelHostableScreen: IScreen
    {
        ModelState Model { get; }
    }

}
