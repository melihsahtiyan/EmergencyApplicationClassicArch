using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        IDataResult<List<Contact>> GetAll();
        IDataResult<List<Contact>> GetById(int contactId);
        IDataResult<List<Contact>> GetContactsByUserId(int userId);
        IResult Add(ContactForCreateDto contact);
        IResult Update(ContactForCreateDto contact);
        IResult Delete(ContactForCreateDto contact);
    }
}
