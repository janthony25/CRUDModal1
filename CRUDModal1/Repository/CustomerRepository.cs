using CRUDModal1.Data;
using CRUDModal1.Models;
using CRUDModal1.Models.Dto;
using CRUDModal1.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CRUDModal1.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _data;

        public CustomerRepository(DataContext data)
        {
            _data = data;
        }

        public async Task AddNewCustomerAsync(AddCustomerDto model)
        {
            var customer = new Customer
            {
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                CustomerNumber = model.CustomerNumber
            };

            _data.Customers.Add(customer);
            await _data.SaveChangesAsync();
        }

        async Task<List<Customer>> ICustomerRepository.GetCustomersAsync()
        {
            return await _data.Customers.ToListAsync();
        }
    }
}
