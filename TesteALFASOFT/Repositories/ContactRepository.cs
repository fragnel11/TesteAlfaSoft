using Microsoft.EntityFrameworkCore;
using TesteALFASOFT.Context;
using TesteALFASOFT.Models;

namespace TesteALFASOFT.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        public ContactRepository(AppDbContext context)=>_context = context;
        public async Task CreateAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            if(contact.IsValid())
              _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var contact =await _context.Contacts.FirstOrDefaultAsync(x => x.ID == id);
            if (contact is not null)
            {
               _context.Contacts.Remove(contact);
               _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        =>await _context.Contacts.ToListAsync();

        public async Task<Contact> GetConatactByIdAsync(int id)
        =>await _context.Contacts.FirstOrDefaultAsync(x => x.ID == id);

        public async Task UpdateAsync(Contact contact)
        {
            var _contact =await _context.Contacts.FirstOrDefaultAsync(x => x.ID == contact.ID);
            if (_contact != null)
            {
                if (contact.IsValid())
                {
                    _contact.Name = contact.Name;
                    _contact.ContactNumber = contact.ContactNumber;
                    _contact.EmailAddress = contact.EmailAddress;
                    _context.SaveChanges();
                }
                
            }
        }
    }
}
