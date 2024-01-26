using Guest_book.Models;

namespace Guest_book.Repository
{
    public interface IRepository
    {
        Task<List<Messages>> GetMessagesList();
        IQueryable<User> GetUserByLogin(UserModel l);
        List<User> GetUsersList();
        int GetUsersCount();
        int GetMessagesCount();
        Task AddMessage(Messages m);
        Task CreateUser(User u);
        Task Save();

    }
}
