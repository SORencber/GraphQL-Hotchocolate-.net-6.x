using System.ComponentModel.DataAnnotations;

namespace ProjeciApi.Models
{
    public class Company
    {
      
            [Key]
            public int CompanyID { get; set; }
            public string? CompanyName { get; set; }
            public string? CompanyAdress {get; set; }
            public string? CompanyCity { get; set; }

                 public ICollection<Personel> Personels { get; set; }




    }
}
