using RubiconeX_Serv.BusinessLogic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RubiconeX_Serv.BusinessLogic.Core.Interfaces
{
    public  interface IUseerServece
    {
        Task<UserInformationBlo> Auth(int phoneNumberPreFix, int phoneNumber, string password);
        Task<UserInformationBlo> Registration(int phoneNumberPreFix, int phoneNumber, string password);
        Task<UserInformationBlo> Get(int UserId);
        Task<UserInformationBlo> Update(int phoneNumberPreFix, int phoneNumber, string password, UserUpdateBlo userUpdateBlo);
        Task<bool> DoesExist(int phoneNumberPreFix, int phoneNumber);
    }
}
