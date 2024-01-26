using Guest_book.Models;
using Microsoft.EntityFrameworkCore;

namespace Guest_book.Repository
{
    public class GuestBookRepository: IRepository
    {
        private readonly GuestBookContext _context;

        public GuestBookRepository (GuestBookContext context)
        {
            _context = context;
        }

        public async Task<List<Messages>> GetMessagesList()
        {
            return await _context.Messages.ToListAsync();
        }

        public IQueryable <User> GetUserByLogin(UserModel l) {
            return _context.Users.Where(a => a.Login == l.Login);
        }

        public List<User> GetUsersList(){
            return  _context.Users.ToList();
        }

        public async Task AddMessage(Messages m){
            await _context.Messages.AddAsync(m);
        }

        public async Task CreateUser(User u) {
            await _context.Users.AddAsync(u);
        }


        public async Task Save() {
            await _context.SaveChangesAsync();
        }

        public int GetUsersCount()
        {
            return  _context.Users.Count();
        }

        public int GetMessagesCount()
        {
            return  _context.Messages.Count();
        }
    }
}
