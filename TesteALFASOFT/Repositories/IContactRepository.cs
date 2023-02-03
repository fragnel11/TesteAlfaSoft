using TesteALFASOFT.Models;

namespace TesteALFASOFT.Repositories
{
    public interface IContactRepository
    {
        Task CreateAsync(Contact contact);
        Task UpdateAsync(Contact contact);
        Task Delete(int id);
        Task<Contact> GetConatactByIdAsync(int id);
        Task<IEnumerable<Contact>> GetAllContactsAsync();
    }
}
