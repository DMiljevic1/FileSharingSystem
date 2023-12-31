﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.Model.Models
{
	public class Folder
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int GroupId { get; set; }
		public virtual Group? Group { get; set; }

		public ICollection<Model.Models.File> Files { get; set;}
	}
}
