using MyApp.Models;

namespace MyApp.ViewModel
{
    public abstract class ScreenHostViewModelBase : ScreenHostableViewModel, IModelHostableScreen
    {
        public ModelState Model { get; }

        public ScreenHostViewModelBase(ModelState model)
        {
            Model = model;
        }
    }
}
