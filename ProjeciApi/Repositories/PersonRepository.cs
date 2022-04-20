using ProjeciApi.Interfaces;
using ProjeciApi.DatabaseContext;
using ProjeciApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjeciApi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonelDataContext _appDbContext;

        public PersonRepository(PersonelDataContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
       
        public Personel GetPersonById(int id)
        {
            var person = _appDbContext.Personels.Where(e => e.Id == id).FirstOrDefault();
            person.CompanyInformation = _appDbContext.Companies.Where(i => i.CompanyID == person.CompanyID).ToList();

             if (person != null) return person;
            return null;
        }

        public List<Personel> GetPersonsWithCompany()
        {

            var result = _appDbContext.Personels.ToList();
            foreach (var item in result)
            {
                item.CompanyInformation = _appDbContext.Companies.Where(i => i.CompanyID == item.CompanyID).ToList();

            }
            return result;
        }

        public List<Personel> SearchPerson(string sortingColumn = "", string sortingOrder = "", string searchKey = "")
        {
            searchKey = searchKey.Replace("\"", "");
            sortingOrder = sortingOrder.Replace("\"", "");
            sortingColumn = sortingColumn.Replace("\"", "");

            if (sortingOrder == "") { sortingColumn = "ASC"; }
            if (sortingColumn == "") { sortingColumn = "id"; }

            var result = _appDbContext.Personels.FromSqlRaw($"select id,Name,Telefon,CompanyID from dbo.Personels Where " +
               $"( [id] like('{searchKey}%') or  [Name] like('{searchKey}%') or [Telefon] like('{searchKey}%'))  " +
               $"ORDER by   {sortingColumn}  {sortingOrder}").ToList();
            foreach (var item in result)
            {
                item.CompanyInformation = _appDbContext.Companies.Where(i => i.CompanyID == item.CompanyID).ToList();

            }


            if (result != null) return result;
            return null;
        }



        public async Task<Personel> UpdatePersonByIdAsync(int id, string Name)
        {
            var person = _appDbContext.Personels.Where(e => e.Id == id).FirstOrDefault();
            person.Name = Name;
           //person.CompanyInformation = _appDbContext.Companies.Where(i => i.CompanyID == person.CompanyID).ToList();

            await _appDbContext.SaveChangesAsync();
            if (person != null) return person;
            return null;
        }


     

        public async Task<Personel> CreatePerson(Personel person)
        {
            await _appDbContext.Personels.AddAsync(person);
            await _appDbContext.SaveChangesAsync();
            return person;
        }
    }
}
