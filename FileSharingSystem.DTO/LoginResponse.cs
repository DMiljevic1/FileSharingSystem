﻿using FileSharingSystem.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.DTO
{
	public class LoginResponse : IResponse
	{
        public bool Success { get; set; }
        public string Message { get; set; }
        public String? Token { get; set; }
    }
}
