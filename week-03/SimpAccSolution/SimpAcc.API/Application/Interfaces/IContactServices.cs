using SimpAcc.API.Application.DTOs;
using SimpAcc.API.Domain.Models;

namespace SimpAcc.API.Application.Interfaces
{
    public interface IContactServices
    {
        Task<ViewContactDTO?> GetByIdAsync(int contactId);
        Task<IEnumerable<ViewContactDTO?>> GetAsync();
        Task<ViewContactDTO?> CreateAsync(CreateContactDTO contact);
        Task<bool> UpdateAsync(int contactId, UpdateContactDTO contact);
        Task<bool> DeleteAsync(int contactId);
    }
}
