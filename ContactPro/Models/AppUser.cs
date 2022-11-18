using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactPro.Models
{
    //Using Inheritance to extend the functionality of IdentityUser
    public class AppUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [NotMapped]
        public string? FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }

    //Using Inheritance to extend the functionality of AbstractValidator
    public class AppUserValidator : AbstractValidator<AppUser>
    {
        public AppUserValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).MinimumLength<AppUser>(4);
            RuleFor(x => x.FirstName).MaximumLength<AppUser>(50);

            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).MinimumLength<AppUser>(4);
            RuleFor(x => x.LastName).MaximumLength<AppUser>(50);
        }
    }
}

