using WebAppAula02.Data;
using WebAppAula02.Models;
using WebAppAula02.Repository.Interfaces;

namespace WebAppAula02.Repository
{
    public class AutorRepository : Repository<AutorViewModel>, IAutorRepository
    {
        public AutorRepository(DataContext context) : base(context)
        {

        }
    }
}
