using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarioKart.Models
{

    [Table("Squadra")]
    public class Squadra
    {
        public int squadraID {  get; set; }
        public string? codice { get; set; } 
        public string? nome { get; set;}
        public string? nomeUtente { get; set; }
        public int crediti {  get; set; }
      

        public virtual ICollection<Personaggi> PersonaggiRIf { get; set; } = new List<Personaggi>();
    }
}
