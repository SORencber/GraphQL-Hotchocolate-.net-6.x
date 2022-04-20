
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ProjeciApi.Models;
using ProjeciApi.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ProjeciApi.Controllers
{ 
    /*
    public class CompanyController : Controller
    {

        
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public CompanyController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet("api2/{id}")]
        public JsonResult Get(int id)
        {
            // Entity Framework 
            PersonelDataContext _context = new PersonelDataContext();    
            
            if (id.Equals(null) || id.Equals(0))
            {
               // var result1 = _context.Companies.ToList();
                return new JsonResult("You must enter any number ");
            }
           var result = _context.Companies.Where(i=>i.CompanyID==id).ToList();
            // Entity Framework 

            return new JsonResult(result);

          
          
        }

        [HttpGet("api2/")]

        public JsonResult Get(string sortingColumn = "", string sortingOrder = "", string searchKey = "")
        {

            searchKey = searchKey.Replace("\"", "");
            sortingOrder = sortingOrder.Replace("\"", "");
            sortingColumn = sortingColumn.Replace("\"", "");

           

            if (sortingOrder == "") { sortingColumn = "ASC"; }
            if (sortingColumn == "") { sortingColumn = "id"; }



            // Entity Framework 
            PersonelDataContext _context = new PersonelDataContext();

            var result = _context.Companies.FromSqlRaw($"select * from dbo.Companies Where " +
                 $"( [CompanyID] like('{searchKey}%') or  [CompanyName] like('{searchKey}%') or [CompanyAdress] like('{searchKey}%') or [CompanyCity] like('{searchKey}%'))  " +
                 $"ORDER by   {sortingColumn}  {sortingOrder}").ToList();
            // Entity Framework 
            return new JsonResult(result);

          
           
          
        }


        [HttpPost("api2")]
        public JsonResult Post( string addCompanyName, string addCompanyAdress, string addCompanyCity)
        {

            Company company = new Company();
            company.CompanyName = addCompanyName;
            company.CompanyAdress = addCompanyAdress;
            company.CompanyCity = addCompanyCity;

            // Entity Framework 
            PersonelDataContext _context = new PersonelDataContext();
            _context.Companies.Add(company);
            var result= _context.SaveChanges();
            // Entity Framework 

            if (result != 1)
                throw new Exception("error");
            return new JsonResult(company);


          
          
        }


        [HttpPut("api2")]
        public JsonResult Put(int companyID, string addCompanyName, string addCompanyAdress, string addCompanyCity)
        {
            Company company = new Company();
            company.CompanyID = companyID;
            company.CompanyName = addCompanyName;
            company.CompanyAdress = addCompanyAdress;
            company.CompanyCity = addCompanyCity;

            // Entity Framework 
            PersonelDataContext _context = new PersonelDataContext();
            var updateCompany =_context.Companies.Where(i=>i.CompanyID==company.CompanyID).First();
            updateCompany.CompanyName = company.CompanyName;
            updateCompany.CompanyAdress = company.CompanyAdress;
            updateCompany.CompanyCity = company.CompanyCity;
            var result =_context.SaveChanges();
            // Entity Framework 
            if (result != 1)
                return new JsonResult("error");
            return new JsonResult(updateCompany);

        
        }

        [HttpDelete("api2")]
        public JsonResult Delete(int id)
        {
            Company deletingCompany = new Company();
            // Entity Framework 
            PersonelDataContext _context = new PersonelDataContext();
            try
            {
                deletingCompany = _context.Companies.Where(i => i.CompanyID == id).First();
                if (deletingCompany != null)
                {
                    _context.Companies.Remove(deletingCompany);
                    _context.SaveChanges();
                    return Json(deletingCompany);
                }
                else
                {
                    return Json("There is no Data");
                }
            }catch (Exception ex)
            {
                return Json(ex);
            }
            // Entity Framework 


           

        }




    }
    */
}

