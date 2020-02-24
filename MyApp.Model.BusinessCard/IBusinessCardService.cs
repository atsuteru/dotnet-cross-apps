using System.Threading.Tasks;

namespace MyApp.Model.BusinessCard
{
    public interface IBusinessCardService
    {
        Task<byte[]> GeneratePDF(GenerateParameter parameter);
    }
}
