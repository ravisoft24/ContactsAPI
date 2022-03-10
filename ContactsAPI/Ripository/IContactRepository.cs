using ContactsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsAPI.Ripository
{
    public interface IContactRepository
    {
        Task<List<ContactModel>> GetAlllContactsAsync();
        Task<ContactModel> GetContactByIdAsync(int contactId);
        Task<int> AddContactAsync(ContactModel contactModel);
        Task<string> UpdateContactAsync(int contactId, ContactModel contactModel);
        Task UpdateContactPatchAsync(int contactId, JsonPatchDocument contactModel);
        Task DeleteContactAsync(int contactId);
    }
}
