using System.Threading.Tasks;

namespace DataLib
{
    public interface IApiCallerGeneric
    {
        Task<U> CRACallerGenericAsync<T, U>(T data, string url)
            where T : class, new()
            where U : class, new();
    }
}