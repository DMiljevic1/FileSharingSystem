using AutoMapper;
using FileSharingSystem.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.Service
{
	public class UserService
	{
		private readonly UserRepository _userRepository;
		private readonly IMapper _mapper;
		public UserService(UserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}
	}
}
