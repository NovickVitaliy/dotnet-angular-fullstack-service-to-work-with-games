using GameProject.Application.Models.Account;

namespace GameProject.Application.Contracts.Account;

public interface IAccountService
{
    Task ChangeAccountData(ChangeAccountDataRequest changeAccountDataRequest);
    Task ChangeAccountPassword(ChangeAccountPasswordRequest changeAccountPasswordRequest);
}