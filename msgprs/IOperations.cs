using System.Threading.Tasks;

namespace msgprs
{
    internal interface IOperations
    {
        Task RunOptionsAsync(Options opts);
    }
}