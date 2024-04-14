using APIMarioKart.Models;

namespace APIMarioKart.Repositories
{
    public class PersonaggiRepo : IRepo<Personaggi>
    {


        private readonly MarioKartContext _context;

        public PersonaggiRepo(MarioKartContext context)
        {
            _context = context;
        }




        public bool Create(Personaggi entity)
        {
            try
            {
                _context.Personaggi.Add(entity);
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
                Personaggi? temp = Get(id);
                if (temp != null)
                {
                    _context.Personaggi.Remove(temp);
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

        public Personaggi? Get(int id)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<Personaggi> GetAll()
        {
            return _context.Personaggi.ToList();
        }


        public bool Update(Personaggi entity)
        {
            try
            {
                _context.Personaggi.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }














        public Personaggi? GetByCodice(string Codice)
        {
            try
            {
                return _context.Personaggi.FirstOrDefault(p => p.codice == Codice);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
