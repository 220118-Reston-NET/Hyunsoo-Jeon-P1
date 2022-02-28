using Models;

namespace BL
{
    public interface IUserBL
    {
        User Register(User p_register);
        
        Boolean Login(User p_user);
        List<User> GetAllUsers();
        }
}