using FluentValidation;

namespace InventoryManagementSystem.Application.CategoryItems.Commands.CreateCategoryItem
{
    public class CreateCategoryItemCommandValidator : AbstractValidator<CreateCategoryItemCommand>
    {
        public CreateCategoryItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
