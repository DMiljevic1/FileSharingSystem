using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.Model.Models
{
	public class GroupPermission
	{
		public int Id { get; set; }
		public bool CreatePermission { get; set; }
		public bool UploadPermission { get; set; }
		public bool DeletePermission { get; set; }
		public int GroupId { get; set; }
		public virtual Group? Group { get; set; }
	}
}
