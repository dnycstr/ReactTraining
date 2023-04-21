using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpAcc.API.Domain.Models;

namespace SimpAcc.API.Application.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact?> GetByIdAsync(int contactid);
        Task<IEnumerable<Contact>> GetAsync();
        Task<Contact> CreateAsync(Contact contact);
        Task<bool> UpdateAsync(Contact contact);
        Task<bool> DeleteAsync(int contactid);
    }
}
