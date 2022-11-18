using ContactPro.Enums;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactPro.Models
{
    public class Contact
    {
        public int Id { get; set; }                        //PK
        public int AppUserId { get; set; }                 //FK

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [NotMapped]
        public string? FullName { get { return $"{FirstName} {LastName}"; } }

        [Display(Name ="Birthday")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public string? Address1 { get; set; }
        public string? Address2 { get; set; }

        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        public string? City { get; set; }
        public States State { get; set; }

        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        public DateTime Created { get; set; }

        public byte[]? ImageData { get; set; }
        public string? ImageType { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        //virtuals
        public virtual AppUser? AppUser { get; set; }
        public virtual ICollection<Category> Categories{ get; set; } = new HashSet<Category>();
    }

    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.AppUserId).NotNull();

            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).Length(3,50);
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.LastName).Length(3, 50);

            RuleFor(x => x.Address1).NotNull();
            RuleFor(x => x.Address2).NotNull();

            RuleFor(x => x.BirthDate).NotNull();

            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.PhoneNumber).NotNull();
            
            RuleFor(x => x.City).NotNull();
            RuleFor(x => x.State).NotNull();
            RuleFor(x => x.ZipCode).NotNull();
        }
    }
}
