using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Application.SiteCollections.Commands.UpdateSiteCollection
{
    public class UpdateSiteCollectionCommandValidator : AbstractValidator<UpdateSiteCollectionCommand>
    {
        public UpdateSiteCollectionCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Url)
                .NotEmpty()
                .Must(x => Uri.TryCreate(x, UriKind.Absolute, out _));
        }
    }
}
