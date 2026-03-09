using TeamAuthMvc.Models;

namespace TeamAuthMvc.Repositories
{
    // This is a CONTRACT (Blueprint).
    // It defines what database operations are allowed for ApplicationUser.
    // It does NOT contain implementation logic.
    public interface IUserRepository
    {
        // Fetch a user based on Email.
        // Used during Login to check if user exists.
        Task<ApplicationUser?> GetByEmailAsync(string email);

        // Add a new user to database.
        // Used during Registration.
        Task AddAsync(ApplicationUser user);

        // Check if an email already exists.
        // Used to prevent duplicate registrations.
        Task<bool> EmailExistsAsync(string email);
    }
}