using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.MVCAuthorisation.Helper
{
    public class CustomPrincipalSerializedModel
    {
        public string EmpId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

    }
}
