using FluentValidation;

namespace InventoryManagementSystem.Application.CategoryItems.Commands.UpdateCategoryItem
{
    public class UpdateCategoryItemCommandValidator : AbstractValidator<UpdateCategoryItemCommand>
    {
        public UpdateCategoryItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
