using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ContactPro.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }

        [Display(Name = "Category Name")]
        public string? Name { get; set; }

        //virtuals
        public virtual AppUser? AppUser { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
    }

    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.AppUserId).NotNull();
            RuleFor(x => x.Name).NotNull();
        }
    }
}
