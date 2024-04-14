using APIMarioKart.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMarioKart.Repositories
{
    public class SquadraRepo : IRepo<Squadra>
    {


        private readonly MarioKartContext _context;

        public SquadraRepo(MarioKartContext context)
        {
            _context = context;
        }
        public bool Create(Squadra entity)
        {
            try
            {
                _context.Squadra.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }



        public bool Delete(int id)
        {
            try
            {
                Squadra? temp = Get(id);
                if (temp != null)
                {
                    _context.Squadra.Remove(temp);
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public Squadra? Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Squadra> GetAll()
        {
            return _context.Squadra.ToList();
        }

        public bool Update(Squadra entity)
        {
            try
            {
                _context.Squadra.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public Squadra? GetByCodice(string Codice)
        {
            try
            {
                return _context.Squadra.FirstOrDefault(p => p.codice == Codice);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
