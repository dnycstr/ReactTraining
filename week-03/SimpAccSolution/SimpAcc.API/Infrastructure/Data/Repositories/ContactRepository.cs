﻿using Dapper;
using Microsoft.EntityFrameworkCore;
using SimpAcc.API.Application.Interfaces;
using SimpAcc.API.Domain.Models;
using SimpAcc.API.Infrastructure.UnitOfWorks;
using static Dapper.SqlMapper;

namespace SimpAcc.API.Infrastructure.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseSession _dbSession;

        public ContactRepository(DatabaseSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<Contact> CreateAsync(Contact contact)
        {
            var query = $@"INSERT INTO Contact (Firstname, Lastname, BirthDate, Email, Phone)                            
                            VALUES (@Firstname, @Lastname, @BirthDate, @Email, @Phone);
                            SELECT LAST_INSERT_ID();
                            ";

            var queryParams = new
            {
                Firstname = contact.Firstname,
                Lastname = contact.Lastname,
                BirthDate = contact.BirthDate,
                Email = contact.Email,
                Phone = contact.Phone
            };

            contact.Id = await _dbSession.Connection.ExecuteScalarAsync<int>(query, queryParams, _dbSession.Transaction);

            return contact;
        }

        public async Task<bool> DeleteAsync(int contactid)
        {
            var query = $@"DELETE FROM Contact WHERE ID=@ID;";

            var queryParams = new
            {
                ID = contactid
            };

            await _dbSession.Connection.ExecuteAsync(query, queryParams, _dbSession.Transaction);            

            return true;
        }

        public async Task<IEnumerable<Contact>> GetAsync()
        {
            IEnumerable<Contact> result;

            var query = $@"SELECT * FROM Contact";
          
            // Call Search, Filter, Order Logic Here

            result = await _dbSession.Connection.QueryAsync<Contact>(query);
       
            return result;
        }

        public async Task<Contact?> GetByIdAsync(int contactid)
        {
            var query = $@"SELECT * FROM Contact WHERE ID=@ID;";
            var queryParams = new
            {
                ID = contactid
            };

            var result = await _dbSession.Connection.QueryFirstOrDefaultAsync<Contact>(query, queryParams);

            return result;
        }

        public async Task<bool> UpdateAsync(Contact contact)
        {
            var query = $@"UPDATE Contact
                            SET Firstname = @Firstname,
                                Lastname = @Lastname,
                                BirthDate = @BirthDate,
                                Email = @Email,
                                Phone = @Phone
                            WHERE ID=@ID;";

            var queryParams = new
            {
                Firstname = contact.Firstname,
                Lastname = contact.Lastname,
                BirthDate = contact.BirthDate,
                Email = contact.Email,
                Phone = contact.Phone,
                ID = contact.Id
            };

            await _dbSession.Connection.ExecuteAsync(query, queryParams, _dbSession.Transaction);

            return true;
        }
    }
}
