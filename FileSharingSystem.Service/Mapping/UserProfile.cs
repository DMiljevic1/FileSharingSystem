﻿using AutoMapper;
using FileSharingSystem.Common.DtoModels;
using FileSharingSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.Service.Mapping
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserDTO>().ReverseMap();
		}
	}
}
