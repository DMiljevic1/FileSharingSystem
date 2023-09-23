using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.Model.Models
{
	public class Group
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool CreatePermission { get; set; }
		public bool UploadPermission { get; set; }
		public bool DeletePermission { get; set; }

		public IList<UserGroupRelation> UserGroupRelations { get; set; }

		public ICollection<Folder> Folders { get; set; }
	}
}
