
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using CoreTravel.Data;
using CoreTravel.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MySqlConnector;
using System.Security.Cryptography;

namespace CoreTravel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerInfoController(ApplicationDbContext dbContext){
            _dbContext = dbContext;
        }

        [HttpPost("/customer/createinfo")]
        public  IActionResult Store(CustomerInfo request){

            CustomerInfo customerInfo = new CustomerInfo
            {
                Customer_Id = request.Customer_Id,
                Location = request.Location,
                Language = request.Language,
                Currency = request.Currency,
            };

            _dbContext.CustomerInfos.Add(customerInfo);
            _dbContext.SaveChanges();

            return new JsonResult(customerInfo);
        }
    }
}

