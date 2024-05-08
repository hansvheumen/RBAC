using System.Collections;

namespace RBAC.Security.Authorisation
{
    public class RoleCollection : ICollection<Role>
    {
        private readonly HashSet<Role> _roles;

        public RoleCollection()
        {
            _roles = [];
        }

        public RoleCollection(IEnumerable<Role> roles)
        {
            _roles = new HashSet<Role>(roles);
        }

        public int Count => _roles.Count;

        public bool IsReadOnly => false;

        public void Add(Role item)
        {
            _roles.Add(item);
        }

        public void Clear()
        {
            _roles.Clear();
        }

        public bool Contains(Role item)
        {
            return _roles.Contains(item);
        }

        public void CopyTo(Role[] array, int arrayIndex)
        {
            _roles.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Role> GetEnumerator()
        {
            return _roles.GetEnumerator();
        }

        public bool Remove(Role item)
        {
            return _roles.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _roles.GetEnumerator();
        }
    }
}
