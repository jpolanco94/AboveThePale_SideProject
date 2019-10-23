using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AboveThePale2.Models;
using Microsoft.AspNetCore.Identity;


namespace AboveThePale2.Infrastructure
{
    public class CustomPasswordValidator : PasswordValidator<AppUser>
    {
        
        public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager,
            AppUser user, string password)
        {
            IdentityResult result = await base.ValidateAsync(manager,
                user, password);

            List<IdentityError> errors = result.Succeeded ?
                new List<IdentityError>() : result.Errors.ToList();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsUserName",
                    Description = "Password cannot contain username"
                });
            }
            if (password.Contains("123456"))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsSequence",
                    Description = "Password cannot contain numeric sequence"
                });
            }
            if (password.Contains("!@#$%^"))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsSpecialCharacterSequence",
                    Description = "Password cannot contain a special character sequence"
                });
            }

            return errors.Count == 0 ? IdentityResult.Success
                : IdentityResult.Failed(errors.ToArray());
        }
    }
}
