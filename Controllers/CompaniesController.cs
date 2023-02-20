using Clocker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Clocker.Controllers
{
    public class CompaniesController : ParentController
    {
        public CompaniesController(ClockerDbContext clockerDbContext) : base(clockerDbContext)
        {
        }

        public IActionResult Index()
        {
            var companies = _context.Companies.ToList();
            return View(companies);
        }

        public IActionResult Details(int id)
        {
            var data = _context.Companies.Where(a=>a.Id == id).FirstOrDefault();
            if(data !=null)
            {
                return Success("Data loaded", data);
            }
            else
            {
                return Error("Record not found");
            }

        }

        public IActionResult Save(int id,string name,int noe,string email,string phone, IFormFile logo)
        {
            if(id == 0)
            {
                var comp = _context.Companies.FirstOrDefault(a=>a.Id==id);
                if(comp!=null) { 
                }

            }
            else
            {
                var company = new Company();
                company.Name = name;
                company.NOE = noe;
                company.Phone = phone;
                company.Email = email;
                company.Logo = "";
                _context.Add(company);
            }
            _context.SaveChanges();

            return Success("Record has been saved"); 
        }

    }
}
