namespace APIMarioKart.DTO
{
    public class DTOSquadra
    {

        public string? cod { get; set; } 
        public string? nom { get; set; } 
        public string? nomUt { get; set; } 
        public int credi { get; set; }


        public List<DTOPersonaggi> Perso { get; set; } = new List<DTOPersonaggi>();
    }
}
