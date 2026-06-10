using MoviesFullstackTerca.API.Models;
using MoviesFullstackTerca.API.Request.Users;

namespace MoviesFullstackTerca.API.Interfaces.Repository
{
    public interface IRepositoryUser
    {
        bool Create(UserCreateRequest user);
        User? GetById(int id);
        bool Update(int id, UserUpdateRequest user);
        bool Delete(int id);
        IEnumerable<User> GetAll();
    }
}
