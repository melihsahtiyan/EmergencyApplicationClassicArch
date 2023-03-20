using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll());
        }

        public IDataResult<List<Contact>> GetById(int contactId)
        {
            var result = _contactDal.GetAll(c => c.ContactId == contactId);
            return new SuccessDataResult<List<Contact>>(result, Messages.ContactListed);
        }

        public IDataResult<List<Contact>> GetContactsByUserId(int userId)
        {
            var result = _contactDal.GetAll(c => c.UserId == userId);
            return new SuccessDataResult<List<Contact>>(result, Messages.ContactListed);
        }

        public IResult Add(Contact contact)
        {
            var check = CheckIfContactExists(contact.ContactId, contact.UserId);
            if (check)
            {
                return new ErrorResult(Messages.ContactExists);
            }
            _contactDal.Add(contact);
            
            return new SuccessResult(Messages.ContactAdded);
        }

        public IResult Update(Contact contact)
        {
            var check = CheckIfContactExists(contact.ContactId, contact.UserId);
            if (check)
            {
                _contactDal.Update(contact);
                return new SuccessResult(Messages.ContactAdded);
            }
            return new ErrorResult(Messages.ContactNotExists);
        }

        public IResult Delete(Contact contact)
        {
            var check = CheckIfContactExists(contact.ContactId, contact.UserId);
            if (check)
            {
                _contactDal.Delete(contact);
                return new SuccessResult(Messages.ContactDeleted);
            }
            return new ErrorResult(Messages.ContactNotExists);
        }

        private bool CheckIfContactExists(int contactId, int userId)
        {
            var result = _contactDal.GetAll(c => c.ContactId == contactId && c.UserId == userId);
            if (result.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
