using System;
using System.Reactive.Disposables;

namespace MyApp.Models
{
    public abstract class ModelBase : IDisposable
    {
        public ModelState Model { get; }

        protected CompositeDisposable Disposables { get; }

        public void Dispose()
        {
            Disposables.Dispose();
        }

        public ModelBase(ModelState model)
        {
            Model = model;
            Disposables = new CompositeDisposable();
            HandleActivation(Disposables);
        }

        protected virtual void HandleActivation(CompositeDisposable d)
        {
        }
    }
}
