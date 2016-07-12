using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Core.Models.Validation
{
    public class Validity
    {
        public bool IsValid { get; set; }
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
}
