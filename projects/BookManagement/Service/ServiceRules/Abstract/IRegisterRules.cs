using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Abstract;

public interface IRegisterRules
{
    void EmailMustBeUnique(string email);
}
