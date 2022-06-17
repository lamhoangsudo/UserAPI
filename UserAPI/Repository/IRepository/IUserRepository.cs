using UserAPI.Data_View_Model;
using UserAPI.Repository.Models;

namespace UserAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        List<UserVM> GetAll();
        UserVM GetById(string id);
        List<UserVM> GetByFirstName(string name);
        List<UserVM> GetByLastName(string name);
        List<UserVM> GetByEmail(string email);
        List<UserVM> GetByStatus(bool status);
        List<UserVM> GetByPhone(string phone);
        bool CreateUser(int roleId, string email);
        bool UpdateUser(string id, string phone, string address, string firstName, string lastName);
        bool DeleteUser(string id);


    }
}
