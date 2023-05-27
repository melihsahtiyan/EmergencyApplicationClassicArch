using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos.Contact;

namespace DataAccess.Concrete
{
    public class ContactDal : EfEntityRepositoryBase<Contact, BaseDbContext>, IContactDal
    {
        public ContactDal(BaseDbContext context) : base(context)
        {
        }

        public List<ContactDetailDto> GetContactDetails()
        {
            var result = (from contact in Context.Contacts
                join user in Context.Users on contact.UserId equals user.Id
                join contactUser in Context.Users on contact.ContactId equals contactUser.Id
                select new ContactDetailDto
                {
                    Id = contact.Id,
                    UserFirstName = user.FirstName,
                    UserLastName = user.LastName,
                    ContactFirstName = contactUser.FirstName,
                    ContactLastName = contactUser.LastName,
                    ContactRelation = contact.ContactRelation
                }).ToList();

            return result;
        }

        public List<ContactDetailDto> GetContactDetailsByUserId(int userId)
        {
            var result = (from contact in Context.Contacts
                join user in Context.Users on contact.UserId equals user.Id
                join contactUser in Context.Users on contact.ContactId equals contactUser.Id
                where contact.UserId == userId
                select new ContactDetailDto
                {
                    Id = contact.Id,
                    UserFirstName = user.FirstName,
                    UserLastName = user.LastName,
                    ContactFirstName = contactUser.FirstName,
                    ContactLastName = contactUser.LastName,
                    ContactRelation = contact.ContactRelation
                }).ToList();

            return result;
        }

        public List<ContactDetailDto> GetContactDetailsByUserIdAndContactId(int userId, int contactId)
        {
            var result = (from contact in Context.Contacts
                join user in Context.Users on contact.UserId equals user.Id
                join contactUser in Context.Users on contact.ContactId equals contactUser.Id
                where contact.UserId == userId && contact.ContactId == contactId
                select new ContactDetailDto
                {
                    Id = contact.Id,
                    UserFirstName = user.FirstName,
                    UserLastName = user.LastName,
                    ContactFirstName = contactUser.FirstName,
                    ContactLastName = contactUser.LastName,
                    ContactRelation = contact.ContactRelation
                }).ToList();

            return result;
        }
    }
}
