using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators;

public class CreateRequestDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    private readonly List<string> validCategories = 
        ["Fast Food", "Traditional", "Vegetarian", "Vegan", "Italian", "Mexican", "Asian", "American", "Other"];

    public CreateRequestDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);

        RuleFor(dto => dto.Category)
            .Must(validCategories.Contains)
            .WithMessage("Invalid category. Please provide a valid category");
        //.Custom((category, context) =>
        //{
        //    if (!validCategories.Contains(category))
        //    {
        //        context.AddFailure("Category", "Invalid category. Please provide a valid category");
        //    }
        //});

        RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("Please provide a valid email address");

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Please provide a valid postal code (XX-XXX)");
    }
}
