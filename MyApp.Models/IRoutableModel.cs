using System;

namespace MyApp.Models
{
    public interface IRoutableModel
    {
        IModelHost Host { get; }
    }
}
