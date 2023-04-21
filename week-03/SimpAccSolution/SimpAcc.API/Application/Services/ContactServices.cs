using AutoMapper;
using SimpAcc.API.Application.DTOs;
using SimpAcc.API.Application.Interfaces;
using SimpAcc.API.Domain.Models;

namespace SimpAcc.API.Application.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ILogger<ContactServices> _logger;

        public ContactServices(IUnitOfWork unitofwork, IMapper mapper, ILogger<ContactServices> logger)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ViewContactDTO?> CreateAsync(CreateContactDTO contact)
        {
            try
            {
                var record = _mapper.Map<Contact>(contact);
              
                _unitofwork.CreateTransaction();
                await _unitofwork.Contact.CreateAsync(record);
                _unitofwork.Commit();

                return _mapper.Map<ViewContactDTO>(record);

            }
            catch (Exception ex)
            {
                _unitofwork.Rollback();
                _logger.LogError($@"{ex.Message}");
            }

            return null;
        }

        public async Task<bool> DeleteAsync(int contactId)
        {
            try
            {
                var record = await _unitofwork.Contact.GetByIdAsync(contactId);
                if (record == null)
                {
                    return false;
                }

                _unitofwork.CreateTransaction();
                await _unitofwork.Contact.DeleteAsync(record.Id);
                _unitofwork.Commit();

                return true;
            }
            catch (Exception ex)
            {
                _unitofwork.Rollback();
                _logger.LogError($@"{ex.Message}");
            }

            return false;
        }

        public async Task<IEnumerable<ViewContactDTO?>> GetAsync()
        {
            var result = await _unitofwork.Contact.GetAsync().ConfigureAwait(false);

            return _mapper.Map<IEnumerable<ViewContactDTO>>(result).ToList();
        }

        public async Task<ViewContactDTO?> GetByIdAsync(int contactId)
        {
            var record = await _unitofwork.Contact.GetByIdAsync(contactId).ConfigureAwait(false);

            return _mapper.Map<ViewContactDTO>(record);
        }

        public async Task<bool> UpdateAsync(int contactId, UpdateContactDTO contact)
        {
            try
            {
                var record = await _unitofwork.Contact.GetByIdAsync(contactId).ConfigureAwait(false);
                if (record == null)
                    return false;

                _mapper.Map(contact, record);

                _unitofwork.CreateTransaction();
                await _unitofwork.Contact.UpdateAsync(record).ConfigureAwait(false);
                _unitofwork.Commit();

                return true;
            }
            catch (Exception ex)
            {
                _unitofwork.Rollback();
                _logger.LogError($@"{ex.Message}");
                return false;
            }
        }
    }
}
