using WebAppAula02.Data;
using WebAppAula02.Models;
using WebAppAula02.Repository.Interfaces;

namespace WebAppAula02.Repository
{
    public class LoginRepository : Repository<LoginViewModel>, ILoginRepository
    {
        public LoginRepository(DataContext context) : base(context) 
        {

        }
    }
}
