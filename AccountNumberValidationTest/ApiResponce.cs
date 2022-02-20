using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountNumberValidationTest
{
    public class ApiResponce
    {
        public bool isValid { get; set; }
        public Riskcheckmessage[] riskCheckMessages { get; set; }
        public int statusCode {get; set;}
    }
    public class Riskcheckmessage
    {
        public string type { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public string customerFacingMessage { get; set; }
        public string actionCode { get; set; }
        public string fieldReference { get; set; }
    }
}
