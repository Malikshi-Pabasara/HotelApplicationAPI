using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelApplication.Data;
using HotelApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApplication.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly HotelContext _context;
        private readonly IMapper _mapper;
        public ContactRepository(HotelContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ContactModel>> GetAllContactsAsync()
        {
            var records = await _context.Contacts.ToListAsync();
            return _mapper.Map<List<ContactModel>>(records); //Auto Map the record
        }

        public async Task<ContactModel> GetContactByIdAsync(int contactId)
        {
            var park = await _context.Contacts.FindAsync(contactId);
            return _mapper.Map<ContactModel>(park);
        }

        public async Task<int> AddContactAsync(ContactModel contactModel)
        {
            var contact = new Contacts()
            {
                Name = contactModel.Name,
                DoB = contactModel.DoB,
                Email = contactModel.Email,
                PhoneNo = contactModel.PhoneNo,
                IDNo = contactModel.IDNo,
                IsActive = contactModel.IsActive
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return contact.ContactId;
        }
        public async Task UpdateContactAsync(int contactId, ContactModel contactModel)
        {
            var contact = new Contacts()
            {
                ContactId = contactId,
                Name = contactModel.Name,
                DoB = contactModel.DoB,
                Email = contactModel.Email,
                PhoneNo = contactModel.PhoneNo,
                IDNo = contactModel.IDNo,
                IsActive = contactModel.IsActive
            };

            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(int contactId)
        {
            var contact = new Contacts()
            {
                ContactId = contactId
            };

            _context.Contacts.Remove(contact);

            await _context.SaveChangesAsync();
        }
    }
}

