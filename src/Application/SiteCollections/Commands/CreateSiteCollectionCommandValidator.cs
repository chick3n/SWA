using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Application.SiteCollections.Commands
{
    public class CreateSiteCollectionCommandValidator : AbstractValidator<CreateSiteCollectionCommand>
    {
        public CreateSiteCollectionCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Url)
                .NotEmpty()
                .Must(x => Uri.TryCreate(x, UriKind.Absolute, out _));
        }
    }
}
