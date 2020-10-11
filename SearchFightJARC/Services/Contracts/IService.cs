using System.Threading.Tasks;

namespace Services
{
    public interface IService
    {
        Task<long> GetResults(string word);
    }
}
