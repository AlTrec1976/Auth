using Auth.Entities.Authz;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace Auth.BLL.Logic.Authz
{
    public class HasPermissionAttribute() : AuthorizeAttribute()
    {
        public HasPermissionAttribute(PermissionEnum[] permission) : this()
        {
            base.Policy = ConvertArrayToString(ref permission);
        }

        private string ConvertArrayToString(ref PermissionEnum[] permission)
        {
            StringBuilder sb = new StringBuilder();

            foreach (PermissionEnum permissionItem in permission)
            {
                sb.Append("," + permissionItem.ToString());
            }

            sb.Remove(0, 1);
            return sb.ToString();
        }
    }
}
