﻿using FileSharingSystem.DTO.Common;
using FileSharingSystem.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.DTO
{
	public class GetUserResponse : IResponse
	{
		public bool Success {  get; set; }
		public string Message {  get; set; }
		public int Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public Gender Gender { get; set; }
	}
}
