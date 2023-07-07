using System.ComponentModel.DataAnnotations;

namespace SchroniskoPsy.Models
{
    public class Psy
    {
        public enum ListaPlci
        {
            Samiec,
            Samica
        }
        public int Id { get; set; }
        public string Imie { get; set; }
        [Range(1, 29, ErrorMessage = "Wiek musi być w przedziale 1 - 29")]
        public int Wiek { get; set; }
        public string Charakter { get; set; }
        public string Rasa { get; set; }
        [EnumDataType(typeof(ListaPlci), ErrorMessage = "Wybierz prawidłową płeć.")]
        public string Plec { get; set; }
        public int SchroniskoID { get; set; }
        public virtual Schronisko? Schronisko { get; set; }
    }
}
