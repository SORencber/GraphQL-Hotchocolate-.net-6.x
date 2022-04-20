using ProjeciApi.Interfaces;
using ProjeciApi.DatabaseContext;
using ProjeciApi.Models;
using System.Data.Entity;

namespace ProjeciApi.Repositories

{
    public class CompanyRepository: ICompanyRepository
    {
        private readonly PersonelDataContext _appDbContext;

        public CompanyRepository(PersonelDataContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public List<Company> GetAllCompanyOnly()
        {
            return _appDbContext.Companies.ToList();
        }
        public List<Company> GetAllCompanywithPerson()
        {
            return _appDbContext.Companies.Include(d => d.CompanyID).ToList();
        }
        public async Task<Company> CreateCompany(Company company)
        {
            await _appDbContext.Companies.AddAsync(company);
            await _appDbContext.SaveChangesAsync();
            return company;
        }
    }
}
