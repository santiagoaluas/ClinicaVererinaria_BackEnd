using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Helps.JWT
{
    public class JwtSettings
    {
        public string secret { get; set; }
        public int expiration { get; set; }
    }
}
