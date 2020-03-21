using MyApp.Models.BusinessCard;
using System;
using System.Reactive.Disposables;

namespace MyApp.Models.Application
{
    public class ApplicationStarter : ModelBase
    {
        public ApplicationStarter(ModelState model) : base(model)
        {
        }

        protected override void HandleActivation(CompositeDisposable d)
        {
            Model.Bus.Listen<InitializeRequest>()
                .Subscribe(Initialize)
                .DisposeWith(Disposables);
        }

        protected virtual void Initialize(InitializeRequest request)
        {
            Model.ChangeCurrent(new BusinessCardGenerator(Model));
            Model.Bus.SendMessage(new InitializeResponse());
        }
    }
}
