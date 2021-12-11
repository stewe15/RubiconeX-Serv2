using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RubiconeX_Serv.BusinessLogic.Core.Interfaces;
using RubiconeX_Serv.BusinessLogic.Core.Models;
using RubiconeX_Serv.DataAccsess.Core.Interfaces.Context;
using RubiconeX_Serv.DataAccsess.Core.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RubiconeX_Serv.Shared.Exception;

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
        /// <summary>
        /// This method is autorisation method it requer phonenumber and etc also it is returns user in dataformat UserinformationBlo
        /// </summary>
        /// <param name="phoneNumberPreFix"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        public async Task<UserInformationBlo> Auth(int phoneNumberPreFix, int phoneNumber, string password)
        {
           UserRto user = await  _context.Users.FirstOrDefaultAsync(x => x.PhoneNumberPreFix == phoneNumberPreFix && x.PhoneNumber == phoneNumber && x.Password == password);
            if (user == null)
                throw new NotFoundExeption("incorrect pasword or login");

           return await ConvertToUserInformationBlo(user);

        }

        public async Task<bool> DoesExist(int phoneNumberPreFix, int phoneNumber)
        {
           return await _context.Users.AnyAsync(x => x.PhoneNumberPreFix == phoneNumberPreFix && x.PhoneNumber == phoneNumber);
        }
        /// <summary>
        /// This metod is trying to find User to return it to website
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns>it returns user in dataformat UserInformationBlo </returns>
        public async Task<UserInformationBlo> Get(int UserId)
        {
            UserRto user = await _context.Users.FirstOrDefaultAsync(x => x.Id == UserId);
            if(user == null)
                throw new NotFoundExeption("Пользователь не найден");

            return await ConvertToUserInformationBlo(user);
        }

        public async Task<UserInformationBlo> Registration(int phoneNumberPreFix, int phoneNumber, string password)
        {
            UserRto newUser = new UserRto() {PhoneNumberPreFix = phoneNumberPreFix, PhoneNumber = phoneNumber};
            
            _context.Users.Add(newUser);
            
            await _context.SaveChangesAsync();

            return await ConvertToUserInformationBlo(newUser);
        }

        public async Task<UserInformationBlo> Update(int phoneNumberPreFix, int phoneNumber, string password, UserUpdateBlo userUpdateBlo)
        {
         UserRto userUpdate = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumberPreFix == phoneNumberPreFix && x.PhoneNumber == phoneNumber && x.Password == password);
            if (userUpdate == null)
                throw new NotFoundExeption("Пользователь не найден");
            if (userUpdateBlo.IsBoy != null)userUpdate.IsBoy =  userUpdateBlo.IsBoy;
            if (userUpdateBlo.FirstName != null) userUpdate.FirstName = userUpdateBlo.FirstName;
            if (userUpdateBlo.LastName != null) userUpdate.LastName = userUpdateBlo.LastName;
            if (userUpdateBlo.Patronumic != null) userUpdate.Patronumic = userUpdateBlo.Patronumic;
            if (userUpdateBlo.Password != null) userUpdate.Password = userUpdateBlo.Password;
            if (userUpdateBlo.AvatarUrl != null) userUpdate.AvatarUrl = userUpdateBlo.AvatarUrl;
            if (userUpdateBlo.Patronumic != null) userUpdate.Patronumic = userUpdateBlo.Patronumic;
            if (userUpdateBlo.Introdution != null) userUpdate.Introdution = userUpdateBlo.Introdution;
            if (userUpdateBlo.Birthday != null) userUpdate.Birthday = userUpdateBlo.Birthday;
            await _context.SaveChangesAsync();
            return await ConvertToUserInformationBlo(userUpdate);

        }

        /// <summary>
        /// Конертирует из UserInformationBlo to UserRto
        /// </summary>
        /// <param name="userRto"></param>
        /// <returns>возвращает обект UserRto</returns>
        private async Task<UserInformationBlo> ConvertToUserInformationBlo(UserRto userRto)
        {

            if(userRto == null)
                throw new ArgumentNullException(nameof(userRto));

          UserInformationBlo userInformationBlo = _mapper.Map<UserInformationBlo>(userRto);

          return userInformationBlo;
        }
    }
}



