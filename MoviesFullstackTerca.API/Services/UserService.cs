using Microsoft.EntityFrameworkCore;
using MoviesFullstackTerca.API.DatabaseContext;
using MoviesFullstackTerca.API.Encrypt;
using MoviesFullstackTerca.API.Interfaces.Repository;
using MoviesFullstackTerca.API.Models;
using MoviesFullstackTerca.API.Request.Users;

namespace MoviesFullstackTerca.API.Services;

public class UserService : IRepositoryUser
{
    public bool Create(UserCreateRequest request)
    {
        using var connection = new DataContext();

        var user = new User(request.Username, PasswordEncryptor.EncryptPassword(request.Password));

        try
        {
            connection.Users.Add(user);
            connection.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Delete(int id)
    {
        using var connection = new DataContext();

        try
        {
            var user = connection.Users.FirstOrDefault(x => x.Id == id);

            if (user is null)
                return false;

            connection.Users.Remove(user);
            connection.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<User> GetAll()
    {
        using var connection = new DataContext();
        return connection.Users.AsNoTracking().ToList();
    }

    public User? GetById(int id)
    {
        using var connection = new DataContext();

        try
        {
            var user = connection.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (user is null)
                return null;

            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public bool Update(int id, UserUpdateRequest request)
    {
        using var connection = new DataContext();

        try
        {
            var user = connection.Users.FirstOrDefault(x => x.Id == id);
            if (user is null)
                return false;

            user.Username = request.Username;
            user.Password = PasswordEncryptor.EncryptPassword(request.Password);

            connection.Users.Update(user);
            connection.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
