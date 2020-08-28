using FluentValidation.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace ValidPeople.Application.Interfaces.Validators
{
    public interface ICpfNumberValidator
    {
        Task<bool> Validate(string cpf, CancellationToken cancellationToken);
    }
}