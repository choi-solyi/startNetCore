using NetCore.Data.DataModels;
using NetCore.Data.ViewModels;
using NetCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services.Svcs
{
    public class UserService : IUser
    {
        #region private methods

        private IEnumerable<User> GetUserInfos()
        {
            return new List<User>()
            {
                new User()
                {
                    UserID = "solyii",
                    UserName = "최솔이",
                    UserEmail = "choi-solyi@naver.com",
                    Password = "123456"

                }
            };
        }
        private bool CheckTheUserInfo(string userId, string password)
        {
            return GetUserInfos().Where(u => u.UserID.Equals(userId) && u.Password.Equals(password)).Any();
        }


        #endregion
        bool IUser.MatchTheUserInfo(LoginInfo login)
        {
            return CheckTheUserInfo(login.UserID, login.Password);
        }
    }
}
