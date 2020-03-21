using MyApp.Models.BusinessCard;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace MyApp.Models.Application
{
    public class ApplicationStarter : ModelBase
    {
        public ApplicationStarter(ModelState model) : base(model)
        {
        }
        public IObservable<InitializeResponse> Initialize(InitializeRequest request)
        {
            return Observable
                .FromAsync(() => InitializeAsync(request));
        }

        protected virtual Task<InitializeResponse> InitializeAsync(InitializeRequest request)
        {
            Model.ChangeCurrent(new BusinessCardGenerator(Model));
            return Task.FromResult(new InitializeResponse());
        }
    }
}
