using FileSharingSystem.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.Model.Models
{
	public class UserGroupRelation
	{
		public int UserId { get; set; }
		public virtual User? User { get; set; }
		public int GroupId { get; set; }
		public virtual Group? Group { get; set; }
		public int RoleId { get; set; }
		public virtual Role? Role { get; set; }
        public RequestStatus RequestStatus { get; set; }
    }
}
