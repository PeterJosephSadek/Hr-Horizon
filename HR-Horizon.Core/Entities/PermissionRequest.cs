using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.Core.Entities
{
    public class PermissionRequest : BaseEntity
    {
        public DateOnly RequestedDate { get; set; }
        public string? Comment { get; set; }
        public TimeOnly TimeFrom { get; set; }
        public TimeOnly TimeTo { get; set; }
        public string? RespondBy { get; set; }
        public DateTime? RespondDate { get; set; }


        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        [ForeignKey("RequestStatus")]
        public int? RequestStatusId { get; set; }
        public RequestStatus? RequestStatus { get; set; }
    }
}
