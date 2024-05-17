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

    public void EmailMustBeUnique(string email)
    {
        AppUser? user = _userRepository.GetByFilter(x => x.Email == email);
        if (user != null)
            throw new BusinessException($"Email is already exist! ({email})");

    }
}
