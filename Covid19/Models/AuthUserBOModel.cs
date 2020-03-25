using Covid19.Core.PasswordHasher;
using Covid19.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class AuthUserBOModel
    {
        Covid19Context context;
        public AuthUserBOModel(Covid19Context pcontext)
        {
            context = pcontext;
        }

        public bool IsAuthorizedUser(string username, string password)
        {
            var user = context.AUTH_USER.Where(u => u.USERNAME == username).FirstOrDefault();

            if(user != null)
            {
                if (PasswordHasher.IsPasswordMatch(password, user.PASSWORD))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
