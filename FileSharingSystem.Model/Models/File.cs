using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.Model.Models
{
	public class File
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int FolderId { get; set; }
		public Folder? Folder { get; set; }
		public long Size { get; set; }
		public byte[] Attachment { get; set; }
		public string Extension { get; set; }
	}
}
