using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Abstract;

public interface IAuthorRules
{
    void AuthorFirstNameMustBeUnique(string firstName);
    void AuthorIsExists(Guid id);
    void AuthorFirstAndLastNameCanNotBeNullOrWhiteSpace(string firstName, string lastName);
    void AuthorFirstAndLastNameMustBeAtLeast3Characters(string firstName, string lastName);
    void AuthorCountryCanNotBeNullOrWhiteSpace(string country);
}
