using EasyBar.Domain.Entity.Repository;
using Flunt.Validations;

namespace EasyBar.Domain.Entity.Authentication
{
    public class CredentialEntity : EntityBase
    {
        public string User { get; set; }
        public string Password { get; set; }

        public CredentialEntity(string user, string password)
        {
            User = user;
            Password = password;  
        }

        public override void Validate()
        {
            AddNotifications(new Contract()
               .IsNotNullOrEmpty(User, nameof(User), "O Usuário ou Senha inválidos")
               .IsNotNullOrEmpty(Password, nameof(Password), "O Usuário ou Senha inválidos"));
        }
    }
}
