using WebAppAula02.Data;
using WebAppAula02.Models;
using WebAppAula02.Repository.Interfaces;

namespace WebAppAula02.Repository
{
    public class EstudanteRepository : Repository<EstudanteViewModel>, IEstudanteRepository
    {
        public EstudanteRepository(DataContext context) : base(context)
        {

        }
    }
}
