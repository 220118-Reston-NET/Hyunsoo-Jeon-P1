using DL;
using Models;

namespace BL
{
    public class UserBL : IUserBL
    {
        private IRepository _repo;
        public UserBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public List<User> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }

        public bool Login(User p_user)
        {
            if(_repo.GetAllUsers().All(p => p.UserName != p_user.UserName))
            {
                return false;
            }
            else{
                if(_repo.GetAllUsers().Find(p => p.UserName == p_user.UserName).Password == p_user.Password)                
                {
                    return true;
                }
            }
            return false;
        }

        public User Register(User p_register)
        {
            return _repo.Register(p_register);
        }
    }
}