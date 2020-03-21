using MyApp.Models;
using System.Reactive.Concurrency;

namespace MyApp.ViewModel
{
    public abstract class ScreenHostViewModelBase : ScreenHostableViewModel, IModelHostableScreen
    {
        public ModelState Model { get; }

        public abstract IScheduler Scheduler { get; }

        public ScreenHostViewModelBase(ModelState model)
        {
            Model = model;
        }
    }
}
