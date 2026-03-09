using Microsoft.EntityFrameworkCore;
using TeamAuthMvc.Data;
using TeamAuthMvc.Models;

namespace TeamAuthMvc.Repositories
{
    // This class IMPLEMENTS the IUserRepository contract.
    // It contains actual database logic using EF Core.
    public class UserRepository : IUserRepository
    {
        // DbContext is injected via Dependency Injection.
        // This allows loose coupling and better testability.
        private readonly ApplicationDbContext _context;

        // Constructor injection of DbContext.
        // When this class is created, .NET automatically provides ApplicationDbContext.
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieves a user by email.
        // FirstOrDefaultAsync returns null if no match is found.
        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            return await _context.Users
                                 .FirstOrDefaultAsync(u => u.Email == email);
        }

        // Checks if any user already exists with given email.
        // AnyAsync is efficient because it stops at first match.
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users
                                 .AnyAsync(u => u.Email == email);
        }

        // Adds a new user to database.
        // AddAsync adds to tracking.
        // SaveChangesAsync commits changes to database.
        public async Task AddAsync(ApplicationUser user)
        {
            await _context.Users.AddAsync(user);

            // Persist changes to database
            await _context.SaveChangesAsync();
        }
    }
}