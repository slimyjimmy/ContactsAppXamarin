using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XamarinFlutter.Models;

namespace XamarinFlutter.Data
{
    public class ContactsDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ContactsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Contact>().Wait();
        }

        public Task<List<Contact>> GetContactsAsync()
        {
            return _database.Table<Contact>().ToListAsync();
        }

        public Task<Contact> GetContactAsync(int id)
        {
            return _database.Table<Contact>().Where(contact => contact.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveContactAsync(Contact contact)
        {
            if (contact.Id != 0) {
                return _database.UpdateAsync(contact);
            }
            else
            {
                return _database.InsertAsync(contact);
            }
        }

        public Task<int> DeleteContact(Contact contact)
        {
            return _database.DeleteAsync(contact);
        }

        public async Task DeleteContacts()
        {
            var allContacts =  await GetContactsAsync();
            foreach (var contact in allContacts)
            {
                await DeleteContact(contact);
            }
        }
    }

}
