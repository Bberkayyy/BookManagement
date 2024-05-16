using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Abstract;

public interface ICategoryRules
{
    void CategoryNameMustBeUnique(string categoryName);
    void CategoryIsExists(Guid id);
    void CategoryNameCanNotBeNullOrWhiteSpace(string categoryName);
    void CategoryNameMustBeAtLeast3Characters(string categoryName);
}
