using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;
using ValidPeople.Application.Validators;
using ValidPeople.Domain.Enumerations;
using ValidPeople.Web.Shared;
using ValidPeople.Web.Shared.People;
using Xunit;

namespace ValidPeople.UnitTests.Validators
{
    public class ParentValidatorTest
    {
        private readonly ParentValidator validator;

        public ParentValidatorTest()
        {
            var nameValidator = ValidatorHelper.GetMock<NameViewModel>();

            validator = new ParentValidator(nameValidator);
        }

        [Fact]
        public void ValidateName_ShouldBeValid() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Name, new NameViewModel());

        [Fact]
        public void ValidateName_ShouldReturnValidationErrorFor_WhenNameIsNull() =>
            validator.ShouldHaveValidationErrorFor(x => x.Name, null as NameViewModel)
                .WithErrorMessage("Parent name should not be empty.");

        [Fact]
        public void ValidateName_ShouldReturnValidationErrorFor_WhenNameLongerThen100Characters() =>
            validator.ShouldHaveValidationErrorFor(x => x.Name, new NameViewModel
            {
                FirstName = "50 lenght first name                              ",
                LastName = "50 lenght last name                               "
            }).WithErrorMessage("Name is too long.");

        [Fact]
        public void ValidateRelation_ShouldReturnValidationError_WhenRelationIsNull() =>
            validator.ShouldHaveValidationErrorFor(x => x.Relation, null as EnumerationViewModel)
                .WithErrorMessage("Select one of the provided relations.");

        [Fact]
        public void ValidateRelation_ShouldReturnValidationError_WhenRelationDoesNotExists() =>
            validator.ShouldHaveValidationErrorFor(x => x.Relation, new EnumerationViewModel { Id = 999 })
                .WithErrorMessage("Select one of the provided relations.");

        [Fact]
        public void ValidateRelation_ShouldBeValid() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Relation, new EnumerationViewModel { Id = RelationEnumeration.Father.Id });
    }
}
