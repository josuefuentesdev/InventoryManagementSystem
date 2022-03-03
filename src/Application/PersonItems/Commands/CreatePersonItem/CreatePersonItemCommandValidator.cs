using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.PersonItems.Commands.CreatePersonItem
{
    public class CreatePersonItemCommandValidator : AbstractValidator<CreatePersonItemCommand>
    {
        public CreatePersonItemCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.LastName)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
