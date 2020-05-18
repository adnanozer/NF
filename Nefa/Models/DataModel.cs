using System.ComponentModel.DataAnnotations;

namespace Nefa.Models
{
    public class DataModel
    {

        public int id { get; set; }
        [Display(Name = "Cari Kod")]
        public string cariKod { get; set; }
        [Display(Name = "Cari İsim")]
        public string cariIsim { get; set; }
        [Display(Name = "Adres")]
        public string adres { get; set; }
        [Display(Name = "İlçe Kod")]
        public int? ilceKod { get; set; }
        [Display(Name = "İlçe / İl")]
        public string ilceAdi { get; set; }
        [Display(Name = "İl Kod")]
        public int? ilKod { get; set; }
        [Display(Name = "İl")]
        public string ilAdi { get; set; }
        [Display(Name = "Ülke Kodu / Ülke")]
        public string ulkeKodu { get; set; }
        [Display(Name = "Ülke")]
        public string ulkeAdi { get; set; }
        [Display(Name = "Telefon")]
        public int? telefonNumara { get; set; }
        [Display(Name = "Fax")]
        public int? faxNumara { get; set; }
        [Display(Name = "Vergi Dairesi / No")]
        public string vergiDairesi { get; set; }
        public int? vergiDairesiNo { get; set; }
        [Display(Name = "Kimlik Numarası")]
        public long? tcKimlikNumarası { get; set; }
        public int? postakodu { get; set; }
        [Display(Name = "Tip")]
        public Enums.Tip tip { get; set; }
        [Display(Name = "Email")]
        public string emailAdres { get; set; }
        [Display(Name = "webAdres")]
        public string webAdres { get; set; }
    }
}
