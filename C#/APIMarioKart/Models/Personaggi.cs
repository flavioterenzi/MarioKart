using System.ComponentModel.DataAnnotations.Schema;



namespace APIMarioKart.Models
{
    [Table("Personaggi")]
    public class Personaggi
    {
        public int personaggiId { get; set; }

        public string codice { get; set; }  = null!;
        public string nome { get; set; } = null!;
        public string categoria { get; set; } = null!;

        public int costo { get; set; }
        public string? img { get; set; }

        public int? squadraRif {  get; set; }

        public virtual Squadra? SquadraRifNavigation { get; set; }


       


    }
    

}


