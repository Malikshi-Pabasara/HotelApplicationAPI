using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApplication.Models;

namespace HotelApplication.Repository
{
    public interface IContactRepository
    {
        Task<List<ContactModel>> GetAllContactsAsync();
        Task<ContactModel> GetContactByIdAsync(int contactId);
        Task<int> AddContactAsync(ContactModel contactModel);
        Task UpdateContactAsync(int contactId, ContactModel contactModel);
        Task DeleteContactAsync(int contactId);

    }
}
