using Domain.Users;
using Infrastructure.Users;

namespace Application.IntegrationTests.Stubs;

public class InMemoryUserStore : IUserStore
{
    private readonly List<User> _users = new()
    {
        TestUser.Instance()
    };

    public Task<User?> FindByIdAsync(string id)
    {
        return Task.FromResult(_users.FirstOrDefault(x => x.Id == id));
    }

    public Task<bool> UpdateAsync(User user)
    {
        _users.RemoveAll(x => x.Id == user.Id);
        _users.Add(user);

        return Task.FromResult(true);
    }

    public Task<User?> FindByEmailAsync(string email)
    {
        return Task.FromResult(_users.FirstOrDefault(x => x.Email == email));
    }
}