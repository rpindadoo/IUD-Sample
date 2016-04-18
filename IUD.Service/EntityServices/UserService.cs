using IUD.DataAccess.Entities;
using IUD.DataAccess.Repository;
using IUD.Service.Core;

namespace IUD.Service.EntityServices
{
    public interface IUserService : IService<User>
    {
    }


    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IRepository<User> repository)
            : base(repository)
        {
        }
    }
}