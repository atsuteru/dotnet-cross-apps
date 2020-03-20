using System.Threading.Tasks;

namespace MyApp.Services.BusinessCard
{
    public interface IBusinessCardService
    {
        Task<byte[]> GeneratePDF(GenerateParameter parameter);
    }
}
