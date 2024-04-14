using APIMarioKart.DTO;
using APIMarioKart.Models;
using APIMarioKart.Repositories;

namespace APIMarioKart.Services
{
    public class SquadraService
    {
        private readonly SquadraRepo _repository;
        private readonly PersonaggiRepo _perRepo;

        public SquadraService(SquadraRepo repository, PersonaggiRepo perRepo)
        {
            _repository = repository;
            _perRepo=perRepo;
        }

        public IEnumerable<Squadra> PrendiliTutti()
        {
            return _repository.GetAll();
        }

        public List<DTOSquadra> RestituisciSquadra()
        {
            List<DTOSquadra> elenco = this.PrendiliTutti().Select(p => new DTOSquadra()
            {
                nom = p.nome,
                nomUt = p.nomeUtente,
                cod = p.codice,
                credi = p.crediti,


            }).ToList();

            return elenco;
        }


        public bool InserisciSquadra(DTOSquadra oPro)
        {
            Squadra pro = new Squadra()
            {
                nome = oPro.nom,
                codice = Guid.NewGuid().ToString().ToUpper(),
                nomeUtente = oPro.nomUt,
                crediti = oPro.credi,


            };

            return _repository.Create(pro);
        }







        public bool ModificaSquadra(DTOSquadra p)
        {
            if (p.cod != null)
            {
                Squadra? per = _repository.GetByCodice(p.cod);
                if (per != null)
                {

                    per.nome = p.nom;
                    per.nomeUtente = p.nomUt;
                    per.crediti = p.credi;
                    return _repository.Update(per);
                }
                //per.squadraRif=p.squadRif;

               
            }
            return false;
        }
        private bool CheckIfPresent(Squadra s, Personaggi p)
        {

            if (s.PersonaggiRIf.FirstOrDefault(per => per.categoria == p.categoria) != null)
            {
                return false;
            }

            return true;
        }

        private bool IsDispo(Personaggi p)
        {
            if  (_perRepo.GetByCodice(p.codice).squadraRif is not null)                 /*(_perRepo.GetByCodice(p.codice).squadraRif != null)*/
            {
                return false;
            }

            return true;
        }


        public bool InserisciPersonaggionellasquadra(string perCod, string codSquad)
        {
            Squadra? temp = _repository.GetByCodice(codSquad);
            if (temp != null)
            {
                Personaggi? per = _perRepo.GetByCodice(perCod);
                if (per != null && temp.crediti >= per.costo && CheckIfPresent(temp, per) && IsDispo(per))
                {
                    temp.PersonaggiRIf.Add(per);
                    temp.crediti -= per.costo;
                    if (_repository.Update(temp))
                        return true;
                }

            }
            return false;

        }
    }
}
