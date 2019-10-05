using System.Threading.Tasks;

namespace conversions
{
    public interface IRun
    {
        string Name { get; }
        Task RunAsync<T>(T input);
    }
}