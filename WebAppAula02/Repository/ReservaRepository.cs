using WebAppAula02.Data;
using WebAppAula02.Models;
using WebAppAula02.Repository.Interfaces;

namespace WebAppAula02.Repository
{
    public class ReservaRepository : Repository<Reserva>, IReservaRepository
    {
        public ReservaRepository(DataContext context) : base(context)
        {

        }
    }
}
