namespace RBAC.Security.Authorisation
{
    public interface IRoleProvider
    {
        RoleCollection GetRolesForUser(string username);
    }
}
