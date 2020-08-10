using FluentValidation;

namespace EasyBar.Domain.Entity.Authentication
{
    public class CredentialEntity : AbstractValidator<CredentialEntity>
    {
        public string User { get; set; }
        public string Password { get; set; }

        public CredentialEntity(string user, string password)
        {
            User = user;
            Password = password;

            RuleFor(credential => credential.User)
                .NotNull()
                .NotEmpty()
                .WithMessage("Usuário ou Senha inválidos");

            RuleFor(credential => credential.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Usuário ou Senha inválidos");
        }        
    }
}
