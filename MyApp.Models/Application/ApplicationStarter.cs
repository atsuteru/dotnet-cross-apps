using MyApp.Models.BusinessCard;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace MyApp.Models.Application
{
    public class ApplicationStarter : ModelBase
    {
        public ApplicationStarter(IModelHost host) : base(host)
        {
        }
        public IObservable<InitializeResponse> Initialize(InitializeRequest request)
        {
            return Observable
                .FromAsync(() => InitializeAsync(request));
        }

        protected virtual Task<InitializeResponse> InitializeAsync(InitializeRequest request)
        {
            Host.Router.Navigate(new BusinessCardGenerator(Host));
            return Task.FromResult(new InitializeResponse());
        }
    }
}
