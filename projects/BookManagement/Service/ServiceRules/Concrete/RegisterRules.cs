using Core.CrossCuttingConcerns;
using DataAccess.Repositories.Abstract;
using Models.Entities;
using Service.ServiceRules.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Concrete;

public class RegisterRules : IRegisterRules
{
    private readonly IAppUserRepository _userRepository;

    public RegisterRules(IAppUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void EmailCanNotBeNullOrWhiteSpace(string email)
    {
        throw new NotImplementedException();
    }

    public void EmailMustBeUnique(string email)
    {
        AppUser? user = _userRepository.GetByFilter(x => x.Email == email);
        if (user != null)
            throw new BusinessException($"Email is already exist! ({email})");

    }

    public void FirstNameCanNotBeNullOrWhiteSpace(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new BusinessException("Please enter a first name.");
    }

    public void LastNameCanNotBeNullOrWhiteSpace(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            throw new BusinessException("Please enter a last name.");
    }

    public void PasswordCanNotBeNullOrWhiteSpace(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new BusinessException("Please enter a password.");
    }

    public void PasswordLengthMustBeAtLeast8Character(string password)
    {
        if (password.Length < 8)
            throw new BusinessException($"Password must be at least 8 characters! (currently : {password.Length})");
    }

    public void UsernameCanNotBeNullOrWhireSpace(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new BusinessException("Please enter a user name.");
    }
}
