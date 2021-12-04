using AutoMapper;
using RubiconeX_Serv.BusinessLogic.Core.Interfaces;
using RubiconeX_Serv.BusinessLogic.Core.Models;
using RubiconeX_Serv.DataAccsess.Core.Interfaces.Context;
using RubiconeX_Serv.DataAccsess.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RubiconeX_Serv.BusinessLogic.Services
{
    public class UserService : IUseerServece
    {
        private readonly IMapper _mapper;
        private readonly IRubiconeX_ServContext _context;

        public UserService(IMapper mapper, IRubiconeX_ServContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<UserInformationBlo> Auth(int phoneNumberPreFix, int phoneNumber, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoesExist(int phoneNumberPreFix, int phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> Get(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> Registration(int phoneNumberPreFix, int phoneNumber, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserInformationBlo> Update(int phoneNumberPreFix, int phoneNumber, string password, UserUpdateBlo userUpdateBlo)
        {
            throw new NotImplementedException();
        }

        private async Task<UserInformationBlo> ConvertToUserInformationBlo(UserRto userRto)
        {

            if(userRto == null)
                throw new ArgumentNullException(nameof(userRto));

          UserInformationBlo userInformationBlo = _mapper.Map<UserInformationBlo>(userRto);

          return userInformationBlo;
        }
    }
}
