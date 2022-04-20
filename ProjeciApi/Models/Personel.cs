using System;
namespace ProjeciApi.Models
{
    public class Personel
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Telefon { get; set; }

        public int CompanyID { get; set; }

        public List<Company> CompanyInformation { get; set; }

        //// this line is added for for GraphQL 
       
    }
}