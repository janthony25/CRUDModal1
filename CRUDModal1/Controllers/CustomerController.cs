using CRUDModal1.Models;
using CRUDModal1.Models.Dto;
using CRUDModal1.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CRUDModal1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET: Json to Populate Customer Table
        public async Task<IActionResult> GetCustomers()
        {
            var customer = await _customerRepository.GetCustomersAsync();
            return Json(customer);
        }

        // POST: Add Customer AJAX

        [HttpPost]
        public async Task<IActionResult> Insert(AddCustomerDto model)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.AddNewCustomerAsync(model);
                return Json("Customer Added successfully");
            }
            else
            {
                return Json("Model validation failed");
            }
        }
    }
}
