using WebAppAula02.Data;
using WebAppAula02.Models;
using WebAppAula02.Repository.Interfaces;

namespace WebAppAula02.Repository
{
    public class UsuarioRepository : Repository<UsuarioViewModel>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext context) : base(context) 
        {


        }
    }
}
