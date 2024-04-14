using APIMarioKart.DTO;
using APIMarioKart.Models;
using APIMarioKart.Repositories;

namespace APIMarioKart.Services
{
    public class PersonaggiServices : IService<Personaggi>
    {


        private readonly PersonaggiRepo _repository;

        public PersonaggiServices(PersonaggiRepo repository)
        {
            _repository = repository;
        }


        public IEnumerable<Personaggi> PrendiliTutti()
        {
            return _repository.GetAll();
        }

        public List<DTOPersonaggi> RestituisciPersonaggi()
        {
            List<DTOPersonaggi> elenco = this.PrendiliTutti().Select(p => new DTOPersonaggi()
            {
                nom = p.nome,
                categ = p.categoria,
                codi = p.codice,
                cost = p.costo,
                squadRif = p.squadraRif,
                im=p.img

            }).ToList();

            return elenco;
        }

        public bool InserisciPersonaggi(DTOPersonaggi oPro)
        {
            Personaggi pro = new Personaggi()
            {
                nome = oPro.nom,
                codice = Guid.NewGuid().ToString().ToUpper(),
                categoria= oPro.categ,
                costo = oPro.cost,        
                img=oPro.im
          
            };

            return _repository.Create(pro);
        }

       

        public bool ModificaPersonaggio(DTOPersonaggi p)
        {
            if (p.codi != null)
            {
                Personaggi? per = _repository.GetByCodice(p.codi);
                if (per != null)

                per.nome = p.nom;
                per.costo = p.cost;
                per.categoria=p.categ;
                per.img = p.im;
                //per.squadraRif=p.squadRif;

                    return _repository.Update(per);
            }
            return false;
        }

    }
}
