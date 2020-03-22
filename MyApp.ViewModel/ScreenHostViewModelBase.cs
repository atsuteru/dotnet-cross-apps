using MyApp.Models;

namespace MyApp.ViewModel
{
    public abstract class ScreenHostViewModelBase : ScreenHostableViewModel, IModelAccessableScreen
    {
        public IModelHost Model { get; }

        public ScreenHostViewModelBase(IModelHost model)
        {
            Model = model;
        }
    }
}
