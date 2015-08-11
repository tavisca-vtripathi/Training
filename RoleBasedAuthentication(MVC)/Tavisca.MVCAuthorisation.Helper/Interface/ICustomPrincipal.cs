using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.MVCAuthorisation.Helper.Interface
{
    public interface ICustomPrincipal : System.Security.Principal.IPrincipal
    {
        string EmpId { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string Title { get; set; }
        
    }
}
