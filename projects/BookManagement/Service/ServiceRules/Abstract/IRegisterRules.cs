using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Abstract;

public interface IRegisterRules
{
    void EmailMustBeUnique(string email);
    void PasswordCanNotBeNullOrWhiteSpace(string password);
    void EmailCanNotBeNullOrWhiteSpace(string email);
    void FirstNameCanNotBeNullOrWhiteSpace(string firstName);
    void LastNameCanNotBeNullOrWhiteSpace(string lastName);
    void PasswordLengthMustBeAtLeast8Character(string password);
    void UsernameCanNotBeNullOrWhireSpace(string username);
    
}
