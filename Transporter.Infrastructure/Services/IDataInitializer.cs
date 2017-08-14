using System.Threading.Tasks;

namespace Transporter.Infrastructure.Services
{
    public interface IDataInitializer : IService
    {
        Task SeedAsync();
    }
}