using Microsoft.AspNetCore.Mvc;
using System.Data;
using ProjeciApi.Models;
using ProjeciApi.DatabaseContext;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/*
namespace ProjeciApi.Controllers
{


    //[Route("api/[controller]")]
    //[ApiController]
    public class PersonelController : Controller
    {


        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public PersonelController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        [HttpGet("api/{id}")]
        public JsonResult Get(int id )
        {

            // Entity Framework 
            PersonelDataContext _context = new PersonelDataContext();
            if (id.Equals(null) || id.Equals(0))
            {
                var result1 = _context.Personels.ToList();
                foreach (var item in result1)
                {
                    item.CompanyInformation = _context.Companies.Where(i => i.CompanyID == item.CompanyID).ToList();

                }
                return new JsonResult(result1);
            }
            var result = _context.Personels.Where(i => i.Id == id).FirstOrDefault();
            result.CompanyInformation =_context.Companies.Where(i => i.CompanyID == result.CompanyID).ToList();
            // Entity Framework 
            
            return new JsonResult(result);

         
        }

        [HttpGet("api/")]
        public JsonResult Get(string sortingColumn="", string sortingOrder="",string searchKey="")
        {
            
            searchKey = searchKey.Replace("\"", "");
            sortingOrder = sortingOrder.Replace("\"", "");
            sortingColumn = sortingColumn.Replace("\"", "");

            if (sortingOrder == "") { sortingColumn = "ASC"; }
            if (sortingColumn == "") { sortingColumn = "id"; }

            // Entity Framework 
            PersonelDataContext _context = new PersonelDataContext();

            var result = _context.Personels.FromSqlRaw($"select id,Name,Telefon,CompanyID from dbo.Personels Where " +
                $"( [id] like('{searchKey}%') or  [Name] like('{searchKey}%') or [Telefon] like('{searchKey}%'))  " +
                $"ORDER by   {sortingColumn}  {sortingOrder}").ToList();
            foreach (var item in result)
            {
                item.CompanyInformation = _context.Companies.Where(i => i.CompanyID == item.CompanyID).ToList();

            }
            // Entity Framework 


            return new JsonResult(result);


        }
    
        [HttpPost("api")]
        public JsonResult Post(string addName, string addTelefon,int addcompanyID)
        {
            Personel personel = new Personel();
            //personel.Id = adduserID;
            personel.Name = addName;
            personel.Telefon = addTelefon;
            personel.CompanyID = addcompanyID;


            // Entity Framework 
            PersonelDataContext _context = new PersonelDataContext();
            _context.Personels.Add(personel);
            var result = _context.SaveChanges();
            // Entity Framework 


            if (result != 1)
                throw new Exception("error");
            personel.CompanyInformation = _context.Companies.Where(i => i.CompanyID == personel.CompanyID).ToList();

            return new JsonResult(personel);

        
                
            }

        [HttpPut("api")]
        public JsonResult Put(string changename, string changeTelefon,int userID, int changeCompanyID )
        {
            Personel personel = new Personel();
            personel.Id = userID;
            personel.Name = changename;
            personel.Telefon = changeTelefon;
            personel.CompanyID = changeCompanyID;

            // Entity Framework 
            PersonelDataContext _context = new PersonelDataContext();
            var updatePerson = _context.Personels.Where(i => i.Id == personel.Id).First();
            updatePerson.Name = personel.Name;
            updatePerson.Telefon = personel.Telefon;
            updatePerson.CompanyID = personel.CompanyID;
            var result = _context.SaveChanges();
            // Entity Framework 

            if (result != 1)
                return new JsonResult("error");

            updatePerson.CompanyInformation = _context.Companies.Where(i => i.CompanyID == updatePerson.CompanyID).ToList();

            return new JsonResult(updatePerson);


          
          

          
        }

        [HttpDelete("api")]
        public JsonResult Delete(int id)
        {

            // Entity Framework 
            Personel deletingPerson = new Personel();
            PersonelDataContext _context = new PersonelDataContext();

            try
            {
                deletingPerson = _context.Personels.Where(i => i.Id == id).First();
                if (deletingPerson != null)
                {
                    _context.Personels.Remove(deletingPerson);
                    _context.SaveChanges();
                    deletingPerson.CompanyInformation = _context.Companies.Where(i => i.CompanyID == deletingPerson.CompanyID).ToList();

                    return Json(deletingPerson);
                }
                else
                {
                    return Json("There is no Data");
                }
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
            // Entity Framework 




          
        }




    }
}
*/