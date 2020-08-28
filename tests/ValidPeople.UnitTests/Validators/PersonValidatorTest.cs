using FluentValidation.TestHelper;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ValidPeople.Application.Interfaces.Validators;
using ValidPeople.Application.Validators;
using ValidPeople.Domain.Enumerations;
using ValidPeople.Web.Shared;
using ValidPeople.Web.Shared.People;
using Xunit;

namespace ValidPeople.UnitTests.Validators
{
    public class PersonValidatorTest
    {
        private readonly Mock<IEducationalLevelRegressionValidator> educationalLevelRegressionValidator;
        private readonly PersonValidator validator;

        public PersonValidatorTest()
        {
            var nameValidator = ValidatorHelper.GetMock<NameViewModel>();
            var parentValidator = ValidatorHelper.GetMock<ParentViewModel>();
            var cpfValidator = ValidatorHelper.GetMock<CpfViewModel>();
            educationalLevelRegressionValidator = new Mock<IEducationalLevelRegressionValidator>();

            validator = new PersonValidator(nameValidator, parentValidator, cpfValidator, educationalLevelRegressionValidator.Object);
        }

        [Fact]
        public void ValidateName_ShouldBeValid() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Name, new NameViewModel());

        [Fact]
        public void ValidateName_ShouldReturnValidationErrorFor_WhenNameIsNull() =>
            validator.ShouldHaveValidationErrorFor(x => x.Name, null as NameViewModel)
                .WithErrorMessage("Name should not be empty.");

        [Fact]
        public void ValidateName_ShouldReturnValidationErrorFor_WhenNameLongerThen100Characters() =>
            validator.ShouldHaveValidationErrorFor(x => x.Name, new NameViewModel
            { 
                FirstName = "50 lenght first name                              ",
                LastName = "50 lenght last name                               "
            }).WithErrorMessage("Name is too long.");

        [Fact]
        public void ValidateBirth_ShouldBeValid_WhenBirthInPast() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Birth, DateTime.Now.AddDays(-1));

        [Fact]
        public void ValidateBirth_ShouldReturnValidationError_WhenBirthInFuture() =>
            validator.ShouldHaveValidationErrorFor(x => x.Birth, DateTime.Now.AddDays(1))
                .WithErrorMessage("You weren't born yet.");

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ValidateEmail_ShouldReturnValidationError_WhenEmailIsEmpty(string email) =>
            validator.ShouldHaveValidationErrorFor(x => x.Email, new PersonViewModel
            {
                Birth = DateTime.Now,
                Email = email
            }).WithErrorMessage("Email should not be empty.")
              .WithoutErrorMessage("Email format is invalid.");

        [Fact]
        public void ValidateEmail_ShouldReturnValidationError_WhenEmailIsInvalid() =>
            validator.ShouldHaveValidationErrorFor(x => x.Email, "invalid email")
                .WithErrorMessage("Email format is invalid.");

        [Fact]
        public void ValidateEmail_ShouldBeValid() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Email, "valid@email.com");

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ValidateEmail_ShouldBeValid_WhenOlderThen60(string email) =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Email, new PersonViewModel
            {
                Birth = DateTime.Now.AddYears(-61),
                Email = email
            });

        [Fact]
        public void ValidateHobby_ShouldReturnValidationError_WhenHobbyIsNull() =>
            validator.ShouldHaveValidationErrorFor(x => x.Hobby, null as EnumerationViewModel)
                .WithErrorMessage("Select one of the provided hobbies.");

        [Fact]
        public void ValidateHobby_ShouldReturnValidationError_WhenHobbyDoesNotExists() =>
            validator.ShouldHaveValidationErrorFor(x => x.Hobby, new EnumerationViewModel { Id = 999 })
                .WithErrorMessage("Select one of the provided hobbies.");

        [Fact]
        public void ValidateHobby_ShouldReturnValidationError_WhenIsDeveloperAndHaveSportAsHobby() =>
            validator.ShouldHaveValidationErrorFor(x => x.Hobby, new PersonViewModel
            {
                Profession = "Developer",
                Hobby = new EnumerationViewModel { Id = HobbyEnumeration.Sports.Id }
            }).WithErrorMessage("I doubt it.");

        [Fact]
        public void ValidateHobby_ShouldBeValid() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Hobby, new EnumerationViewModel { Id = HobbyEnumeration.Coffee.Id });

        [Fact]
        public void ValidateParent_ShouldReturnValidationError_WhenParentsIsNull() =>
            validator.ShouldHaveValidationErrorFor(x => x.Parents, new PersonViewModel
            {
                Cloned = false,
                Parents = null
            }).WithErrorMessage("You need a parent.");

        [Fact]
        public void ValidateParent_ShouldReturnValidationError_WhenParentsIsEmpty() =>
            validator.ShouldHaveValidationErrorFor(x => x.Parents, new PersonViewModel
            {
                Cloned = false,
                Parents = new List<ParentViewModel>()
            }).WithErrorMessage("You need a parent.");

        [Fact]
        public void ValidateParent_ShouldBeValid_WhenTwoParents() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Parents, new PersonViewModel
            {
                Cloned = false,
                Parents = new List<ParentViewModel>
                {
                    new ParentViewModel(),
                    new ParentViewModel()
                }
            });

        [Fact]
        public void ValidateParent_ShouldBeValid_WhenOneParent() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Parents, new PersonViewModel
            {
                Cloned = false,
                Parents = new List<ParentViewModel> { new ParentViewModel() }
            });

        [Fact]
        public void ValidateParent_ShouldReturnValidationError_WhenTreeParents() =>
            validator.ShouldHaveValidationErrorFor(x => x.Parents, new PersonViewModel
            {
                Cloned = false,
                Parents = new List<ParentViewModel>
                {
                    new ParentViewModel(),
                    new ParentViewModel(),
                    new ParentViewModel()
                }
            }).WithErrorMessage("Too much parents.");

        [Fact]
        public void ValidateParent_ShouldReturnValidationError_WhenClonedAndHaveParent() =>
            validator.ShouldHaveValidationErrorFor(x => x.Parents, new PersonViewModel
            {
                Cloned = true,
                Parents = new List<ParentViewModel> { new ParentViewModel() }
            }).WithErrorMessage("Clones don't have parents.");

        [Fact]
        public void ValidateParent_ShouldBeValid_WhenClonedAndParentsIsNull() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Parents, new PersonViewModel
            {
                Cloned = true,
                Parents = null
            });

        [Fact]
        public void ValidateParent_ShouldBeValid_WhenClonedAndParentsIsEmpty() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Parents, new PersonViewModel
            {
                Cloned = true,
                Parents = new List<ParentViewModel>()
            });

        [Fact]
        public void ValidateEducationalLevel_ShouldReturnValidationError_WhenEducationalLevelIsNull() =>
            validator.ShouldHaveValidationErrorFor(x => x.EducationalLevel, null as EnumerationViewModel)
                .WithErrorMessage("Select one of the provided educational levels.");

        [Fact]
        public void ValidateEducationalLevel_ShouldReturnValidationError_WhenEducationalLevelDoesNotExists() =>
            validator.ShouldHaveValidationErrorFor(x => x.EducationalLevel, new EnumerationViewModel { Id = 999 })
                .WithErrorMessage("Select one of the provided educational levels.");

        [Fact]
        public void ValidateEducationalLevel_ShouldBeValid() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.EducationalLevel, new EnumerationViewModel { Id = EducationalLevelEnumeration.HigherComplete.Id });

        [Fact]
        public void ValidateRevenue_ShouldReturnValidationError_WhenIsNegative() =>
            validator.ShouldHaveValidationErrorFor(x => x.Revenue, -1)
                .WithErrorMessage("Revenue shouldn't be negative.");

        [Fact]
        public void ValidateRevenue_ShouldBeValid_WhenZero() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Revenue, 0);

        [Fact]
        public void ValidateRevenue_ShouldBeValid_WhenPositive() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Revenue, 1);

        [Fact]
        public void ValidateStatus_ShouldBeValid() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Status, null as EnumerationViewModel);

        [Fact]
        public void ValidateStatus_ShouldBeValid_EvenIfStatusDoesNotExist() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Status, new EnumerationViewModel { Id = 999 });

        [Fact]
        public void ValidateStatus_ShouldReturnValidationError_WhenNull_OnUpdate() =>
            validator.ShouldHaveValidationErrorFor(x => x.Status, null as EnumerationViewModel, "Update")
                .WithErrorMessage("Select one of the provided status.");

        [Fact]
        public void ValidateStatus_ShouldReturnValidationError_WhenStatusDoesNotExist_OnUpdate() =>
            validator.ShouldHaveValidationErrorFor(x => x.Status, new EnumerationViewModel { Id = 999 }, "Update")
                .WithErrorMessage("Select one of the provided status.");

        [Fact]
        public void ValidateStatus_ShouldBeValid_OnUpdate() =>
            validator.ShouldNotHaveValidationErrorFor(x => x.Status, new EnumerationViewModel { Id = StatusEnumeration.Active.Id }, "Update");

        [Fact]
        public async Task ValidateEducationalLevel_ShouldReturnValidationError_WhenRegressing_OnUpdate()
        {
            var person = new PersonViewModel
            { 
                EducationalLevel = EducationalLevelEnumeration.None.ToViewModel()
            };

            educationalLevelRegressionValidator.Setup(x => x.Validate(person, person.EducationalLevel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            (await validator.ShouldHaveValidationErrorForAsync(x => x.EducationalLevel, person, ruleSet: "Update"))
                .WithErrorMessage("Can't regress any level in your education.");
        }

        [Fact]
        public async Task ValidateEducationalLevel_ShouldBeValid_OnUpdate()
        {
            var person = new PersonViewModel
            {
                EducationalLevel = EducationalLevelEnumeration.None.ToViewModel()
            };

            educationalLevelRegressionValidator.Setup(x => x.Validate(person, person.EducationalLevel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            await validator.ShouldNotHaveValidationErrorForAsync(x => x.EducationalLevel, person, ruleSet: "Update");
        }
    }
}
