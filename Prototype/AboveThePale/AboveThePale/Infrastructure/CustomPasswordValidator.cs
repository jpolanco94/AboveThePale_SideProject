using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AboveThePale.Models;

namespace AboveThePale.Infrastructure
{
    public class CustomPasswordValidator : PasswordValidator<AppUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager,
            AppUser user, string password)
        {
            IdentityResult result = await base.ValidateAsync(manager, user, password);
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContaintsUserName",
                    Description = "Password Connot containt username"
                });
            }
            if (password.Contains("12345"))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsSequence",
                    Description = "Password cannot containt a numeric sequence"
                });
            }
            if (password.Contains("!@#$%"))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsSpecialCharacterSequence",
                    Description = "Password cannot containt a special character sequence"
                });

            }

            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}
