using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Abstract;

public interface IBookRules
{
    void CategoryIsExists(Guid categoryId);
    void AuthorIsExists(Guid authorId);
    void BookIsExists(Guid id);
    void BookNameMustBeUnique(string name);
    void BookPriceCanNotBeNegative(decimal price);
    void BookStockCanNotBeNegative(int stock);
    void BookNameCanNotBeNullOrWhiteSpace(string name);
    void BookDescriptionCanNotBeNullOrWhiteSpace(string description);
}
