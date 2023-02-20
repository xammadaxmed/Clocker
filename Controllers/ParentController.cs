using Clocker.Helpers;
using Clocker.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clocker.Controllers
{
    public class ParentController : Controller
    {
        protected readonly ClockerDbContext _context;
        public ParentController(ClockerDbContext clockerDbContext)
        {
            _context = clockerDbContext;
        }
        public IActionResult Success(string message,object? data = null)
        {
            var response = new ApiResponse()
            {
                    Status = "SUCCESS",
                    Message = message,  
                    Data = data
            };

            return Json(response);

        }

        public IActionResult Error(string message,object? data = null)
        {
            var response = new ApiResponse()
            {
                Status = "ERROR",
                Message = message,
                Data = data
            };

            return Json(response);
        }
    }
}
