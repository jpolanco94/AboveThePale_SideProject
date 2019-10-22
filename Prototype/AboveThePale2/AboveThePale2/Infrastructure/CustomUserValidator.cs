using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AboveThePale2.Models;

namespace AboveThePale2.Infrastructure
{
    public class CustomUserValidator : UserValidator<AppUser>
    {
        public override async Task<IdentityResult> ValidateAsync(
            UserManager<AppUser> manager, AppUser user)
        {

            IdentityResult result = await base.ValidateAsync(manager, user);

            List<IdentityError> errors = result.Succeeded ?
                new List<IdentityError>() : result.Errors.ToList();
            
            if(!user.Email.ToLower().EndsWith("@outlook.com")
                || !user.Email.ToLower().EndsWith("@example.com")
                || !user.Email.ToLower().EndsWith("@yahoo.com")
                || !user.Email.ToLower().EndsWith("@gmail"))
            {
                errors.Add(new IdentityError
                {
                    Code = "EmailDomainError",
                    Description = "Emails must use one of the following domains\n" +
                    "yahoo.com\noutlook.com\ngmail.com\nexample.com"
                });
            }
            return errors.Count == 0 ? IdentityResult.Success
                : IdentityResult.Failed(errors.ToArray());
        }
    }
}
