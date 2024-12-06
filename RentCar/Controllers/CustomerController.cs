using Microsoft.AspNetCore.Mvc;
using RentCar.Model;
using RentCar.Services.Customer;


namespace RentCar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController: ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<CustomerModel>>>  GetAllCustomers()
    {   
        var customers = await _customerService.GetAllCustomers()!;
        return Ok(customers);  

    }
        
    [HttpGet("{id}")]
    //[Route(("{id}"))]
    public async Task<IActionResult> GetSingleCustomer (int id)
    {
        var result = await _customerService.GetSingleCustomer(id)!;
        if (result == null)
        {
            return NotFound(new { message = "Customer not found" }); 
        }
                
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> AddCustomer(CustomerModel customer)
    {
        var result = await _customerService.AddCustomer(customer)!;
        if(result is null)
            return NotFound("not found");
                
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer (int id, CustomerModel request)
    { 
        var result = await _customerService.UpdateCustomer(id,request);
        if(result is null)
            return NotFound("not found");
                
        return Ok(result);
    }
         
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer (int id)
    {
        var result =await _customerService.DeleteCustomer(id);
        if(result is null)
            return NotFound("not found");
                
        return Ok(result);
    }
}