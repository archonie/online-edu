using FluentValidation;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;

namespace OnlineEdu.WebUI.Validators
{
	public class BlogCategoryValidator : AbstractValidator<CreateBlogCategoryDto>
	{
        public BlogCategoryValidator()
        {
            RuleFor(x=> x.Name)
                .NotEmpty().WithMessage("Name must be provided.")
                .MaximumLength(30).WithMessage("Name cannot exceed 30 characters.");
        }
    }
}
