using GameProject.Application.Models.Account;

namespace GameProject.Application.Contracts.Account;

public interface IAccountService
{
    Task EditAccountData(EditAccountDataRequest editAccountDataRequest);
}