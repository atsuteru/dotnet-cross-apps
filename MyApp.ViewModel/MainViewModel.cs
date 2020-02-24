using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyApp.ViewModel
{
    public class MainViewModel: ReactiveObject
    {

        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public string Organization { get; set; }

        public ICommand SubmitCommand { private set; get; }

        public MainViewModel()
        {
            SubmitCommand = ReactiveCommand.CreateFromTask(ProcessSubmit);
        }

        private async Task ProcessSubmit()
        {
            await Task.Delay(1500);
        }
    }
}
