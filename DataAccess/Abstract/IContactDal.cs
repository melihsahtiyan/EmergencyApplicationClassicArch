using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entity.Concrete;
using Entity.Dtos.Contact;

namespace DataAccess.Abstract
{
    public interface IContactDal : IEntityRepository<Contact>
    {
        List<ContactDetailDto> GetContactDetails();
        List<ContactDetailDto> GetContactDetailsByUserId(int userId);
        List<ContactDetailDto> GetContactDetailsByUserIdAndContactId(int userId, int contactId);
    }
}
