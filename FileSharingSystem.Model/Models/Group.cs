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
        public string InvitationToken { get; set; }
		public virtual GroupPermission GroupPermission { get; set; }

		public IList<UserGroupRelation> UserGroupRelations { get; set; }

		public ICollection<Folder> Folders { get; set; }
	}
}
