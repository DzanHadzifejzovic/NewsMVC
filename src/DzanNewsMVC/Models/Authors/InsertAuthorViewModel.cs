using System.ComponentModel.DataAnnotations;

namespace DzanNewsMVC.Models.Authors
{
    public class InsertAuthorViewModel
    {
        [Required(ErrorMessage ="Unesite ime autora")]
        [Display(Name ="Ime")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Unesite prezime autora")]
        [Display(Name = "Prezime")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Unesite datum rodjenja autora")]
        [Display(Name = "Datum rodjenja")]
        public DateTime BirthDate { get; set; }
    }
}
