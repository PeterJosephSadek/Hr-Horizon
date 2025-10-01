using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.Core.Entities
{
    public class RequestStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string BootstrapColor { get; set; } = null!;
    }
}
