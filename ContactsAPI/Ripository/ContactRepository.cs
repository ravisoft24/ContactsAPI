using AutoMapper;
using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Ripository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactsContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(ContactsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ContactModel>> GetAlllContactsAsync() 
        {
            //var records = await _context.Contacts.Select(x=> new ContactModel()
            //{ 
            //    Id = x.Id,
            //    Title = x.Title,
            //    Name = x.Name
                
            //}).ToListAsync();

            //return records;

            var records = await _context.Contacts.ToListAsync();
            return _mapper.Map<List<ContactModel>>(records);
        }

        public async Task<ContactModel> GetContactByIdAsync(int contactId)
        {
            //var records = await _context.Contacts.Where(x => x.Id == contactId).Select(x => new ContactModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Name = x.Name

            //}).FirstOrDefaultAsync();

            //return records;

            var contact = await _context.Contacts.FindAsync(contactId);
            return _mapper.Map<ContactModel>(contact);

        }


        public async Task<int> AddContactAsync(ContactModel contactModel)
        {
            //var contact = new Contacts()
            //{
            //    Title = contactModel.Title,
            //    Name = contactModel.Name
            //};

            //_context.Contacts.Add(contact);
            //await _context.SaveChangesAsync();

            //return contact.Id;

            var mapper = _mapper.Map<Contacts>(contactModel);
            _context.Contacts.Add(mapper);
            await _context.SaveChangesAsync();
            return mapper.Id;


        }



        public async Task<string> UpdateContactAsync(int contactId, ContactModel contactModel)
        {
            //var contact = await _context.Contacts.FindAsync(contactId);
            //if (contact == null)
            //{ 
            //    contact.Title = contactModel.Title;
            //    contact.Name = "AAAA";//contactModel.Name;

            //    await _context.SaveChangesAsync();

            //}

            var contact = new Contacts()
            {
                Id = contactId,
                Title = contactModel.Title,
                FirstName = contactModel.FirstName
            };

            _context.Contacts.Update(contact);
             await _context.SaveChangesAsync();
             return "Id "+contact.Id + " updated";

            //var contact = await _context.Contacts.FindAsync(contactId);
            //_context.Contacts.Update(contact);
            //await _context.SaveChangesAsync();

        }

        public async Task UpdateContactPatchAsync(int contactId, JsonPatchDocument contactModel)
        {
            var contact = _context.Contacts.Find(contactId);
            if (contact != null)
            {
                contactModel.ApplyTo(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteContactAsync(int contactId)
        {
            var contact = new Contacts() { Id = contactId };
        
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

        }

    }
}
