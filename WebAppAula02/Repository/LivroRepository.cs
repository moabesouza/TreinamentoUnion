using WebAppAula02.Data;
using WebAppAula02.Models;
using WebAppAula02.Repository.Interfaces;

namespace WebAppAula02.Repository
{
    public class LivroRepository : Repository<LivroViewModel>, ILivroRepository
    {
        public LivroRepository(DataContext context) : base(context)
        {

        }
    }
}
