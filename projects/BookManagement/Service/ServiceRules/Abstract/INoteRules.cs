using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceRules.Abstract;

public interface INoteRules
{
    void BookIsExists(Guid bookId);
    void AppUserIsExists(Guid userId);
    void NoteIsExists(Guid noteId);
    void ContentCanNotBeNullOrWhiteSpace(string content);
}
