using Microsoft.EntityFrameworkCore;
using SkeletonBackend.Domain.Identity;
using SkeletonBackend.Domain.Repositories;
using SkeletonBackend.Infrastructure.Data;

namespace SkeletonBackend.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(user, cancellationToken);
    }

    public void Update(User user)
    {
        context.Users.Update(user);
    }

    public void Remove(User user)
    {
        context.Users.Remove(user);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}
