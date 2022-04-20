using ProjeciApi.Models;
using ProjeciApi.DatabaseContext;
using ProjeciApi.Repositories;
using HotChocolate.Subscriptions;

namespace ProjeciApi.DatabaseContext
{

    public class Mutation
    {

        public async Task<Company> CreateCompany([Service] CompanyRepository companyRepository,
            [Service] ITopicEventSender eventSender, string companyName)
        {
            var newCompany = new Company
            {
                CompanyName = companyName
            };
            var createdCompany = await companyRepository.CreateCompany(newCompany);
            await eventSender.SendAsync("CompanyCreated", createdCompany);
            return createdCompany;
        }
        public async Task<Personel> CreatePerson([Service] PersonRepository personRepository, string name, string telefon, int companyID)
        {
            Personel newPerson = new Personel
            {
                Name = name,
                Telefon = telefon,

                CompanyID = companyID
            };
            var createdPerson = await personRepository.CreatePerson(newPerson);
            return createdPerson;
        }



    }
}
