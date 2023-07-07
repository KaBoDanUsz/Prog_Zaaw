using System.ComponentModel.DataAnnotations;

namespace SchroniskoPsy.Models
{
    public class Schronisko
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Ulica { get; set; }
        public string Miejscowosc { get; set; }
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Numer telefonu musi składać się z dokładnie 9 cyfr.")]
        public int NumerTel { get; set; }
    }
}
