using System;

namespace MyApp.Models
{
    public interface IModel
    {
        IModelHost Host { get; }
    }
}
