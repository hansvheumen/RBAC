using RBAC.Security.Context;

namespace RBAC.Security.Authentication
{
    /// <summary>
    /// Defines the contract for an authenticator.
    /// </summary>
    public interface IAuthenticator
    {
        /// <summary>
        /// Executes the authentication process.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The authenticated user.</returns>
        Principal? Execute(string username, string password);
    }
}
