using HotChocolate.Subscriptions;
using ProjeciApi.Models;
using ProjeciApi.Repositories;
namespace ProjeciApi.DatabaseContext
{
    public class Query
    {
       
      //  public IQueryable<Personel> GetPersons([Service] PersonelDataContext context) => context.Personels;

       // public IQueryable<Company> GetCompany([Service] PersonelDataContext context) => context.Companies;


       // public List<Personel> AllPersonOnly([Service] PersonRepository personRepository) => personRepository.GetPersonels();
        public List<Personel> Persons([Service] PersonRepository personRepository) => personRepository.GetPersonsWithCompany();

      
        
        public async Task<Personel> GetPersonById([Service] PersonRepository personRepository,
            [Service] ITopicEventSender eventSender, int id)
        {
            Personel gottenPerson = personRepository.GetPersonById(id);
            await eventSender.SendAsync("ReturnedPerson", gottenPerson);
            return gottenPerson;
        }


        public async Task<List<Personel>> Search([Service] PersonRepository personRepository,
          [Service] ITopicEventSender eventSender, string sortingColumn, string sortingOrder, string searchKey)
        {
            List<Personel> gottenPerson = personRepository.SearchPerson(sortingColumn,  sortingOrder, searchKey );
            await eventSender.SendAsync("ReturnedPerson", gottenPerson);
            return gottenPerson;
        }






        public async Task<Personel> UpdatePersonById([Service] PersonRepository personRepository,
            [Service] ITopicEventSender eventSender, int id, string name)
        {
            Personel gottenPerson = await personRepository.UpdatePersonByIdAsync(id, name);
            await eventSender.SendAsync("ReturnedEmployee", gottenPerson);
            return gottenPerson;
        }
        public List<Company> AllCompanyOnly([Service] CompanyRepository companyRepository) => companyRepository.GetAllCompanyOnly();
        public List<Company> AllCompanyWithPersons([Service] CompanyRepository companyRepository) => companyRepository.GetAllCompanywithPerson();
    }




}

