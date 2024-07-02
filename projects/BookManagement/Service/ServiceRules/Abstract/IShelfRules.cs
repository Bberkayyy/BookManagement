using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Abstract;

public interface IShelfRules
{
    void BookIsExist(Guid bookId);
    void ShelfIsExist(int shelfId);
    void ShelfCodeMustBe10Character(string shelfCode);
    void ShelfCodeMustContainUpperCaseLetter(string shelfCode);
    void FloorCanNotBeLessThanZero(int floor);
    void ShelfCodeCanNotBeNullOrWhiteSpace(string shelfCode);
    void SectionCanNotBeNullOrWhiteSpace(string section);
    void ShelfCodeMustBeUnique(string shelfCode);
}
