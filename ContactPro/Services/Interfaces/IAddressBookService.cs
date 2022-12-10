using ContactPro.Models;
using System.Collections;

namespace ContactPro.Services.Interfaces;

public interface IAddressBookService
{
    Task AddContactToCategoryAsync(int categoryId, int contactId);

    Task<bool> IsContactInCategory(int categoryId, int contactId);
    //return list of categories
    Task<IEnumerable<Category>> GetUserCategoriesAsync(string userId);

    Task<ICollection<int>> GetContactCategoryIdAsync(int contactId);

    //return colleciton of cateogories
    Task<ICollection<Category>> GetContactCategoriesAsync(int contactId);

    Task RemoveContactFromCategoryAsync(int categoryId, int contactId);

    IEnumerable<Category> SearchForContacts(string searchString, string userId);


}
