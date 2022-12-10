using ContactPro.Data;
using ContactPro.Models;
using ContactPro.Services;
using ContactPro.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactPro.Services;

public class AddressbookService : IAddressBookService
{
    private readonly ApplicationDbContext _context;

    public AddressbookService(ApplicationDbContext context)
    {
        context = _context;
    }

    public async Task AddContactToCategoryAsync(int categoryId, int contactId)
    {
        try
        {
            //if the category is not in the contact, add in the category
            if(!await IsContactInCategory(categoryId, contactId))
            {
                Contact? contact = await _context.Contacts.FindAsync(contactId);
                Category? category = await _context.Categories.FindAsync(categoryId);

                if(category != null && contact != null)
                {
                    category.Contacts.Add(contact);
                    await _context.SaveChangesAsync();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<ICollection<Category>> GetContactCategoriesAsync(int contactId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<int>> GetContactCategoryIdAsync(int contactId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> GetUserCategoriesAsync(string userId)
    {
        List<Category> categories = new List<Category>();

        try
        {
            categories = await _context.Categories.Where(c => c.AppUserId == userId)
                                                  .OrderBy(c => c.Name).ToListAsync();
        }
        catch 
        {
            throw;
        }

        return categories;
    }

    public async Task<bool> IsContactInCategory(int categoryId, int contactId)
    {
        Contact? contact = await _context.Contacts.FindAsync(contactId);

        //Look at both the Categories Table and the contact table and perform a join
        //if the categoryId and contactId are the same, then the AnyAsync() will
        //return a true for a bool result
        return await _context.Categories
                             .Include(c => c.Contacts)
                             .Where(c => c.Id == categoryId && c.Contacts.Contains(contact))
                             .AnyAsync();
    }

    public Task RemoveContactFromCategoryAsync(int categoryId, int contactId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> SearchForContacts(string searchString, string userId)
    {
        throw new NotImplementedException();
    }
}
