using FluentValidation;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;

namespace OnlineEdu.WebUI.Validators
{
	public class UpdateBlogCategoryValidator : AbstractValidator<UpdateBlogCategoryDto>
	{
        public UpdateBlogCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be provided.")
                .MaximumLength(30).WithMessage("Name must not exceed 30 characters");
        }
    }
}
