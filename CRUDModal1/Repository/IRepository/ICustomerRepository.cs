using CRUDModal1.Models;
using CRUDModal1.Models.Dto;

namespace CRUDModal1.Repository.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync();
        Task AddNewCustomerAsync(AddCustomerDto model);
    }
}
