using TheAwesomeService.Models;
using System.Threading.Tasks;

namespace TheAwesomeService.Data
{
    public interface IRepository
    {
        Task<Customer> GetCustomer(int customerId);
    }
}
