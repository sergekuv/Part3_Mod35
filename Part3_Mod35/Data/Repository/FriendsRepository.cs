using Part3_Mod35.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part3_Mod35.Data.Repository
{
    public class FriendsRepository : Repository<Friend>
    {
        public FriendsRepository(ApplicationDbContext db) : base(db)
        {
        }
        public async Task AddFriend (User target, User Friend)
        {
            var friends = Set.AsEnumerable().FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == Friend.Id);

            if (friends == null)
            {
                var item = new Friend()
                {
                    UserId = target.Id,
                    User = target,
                    CurrentFriend = Friend,
                    CurrentFriendId = Friend.Id,
                };
                Create(item);
                //await CreateAsync(item);
            }
        }

        public async Task AddFriendAsync(User target, User Friend)
        {
            var friends = Set.AsEnumerable().FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == Friend.Id);

            if (friends == null)
            {
                var item = new Friend()
                {
                    UserId = target.Id,
                    User = target,
                    CurrentFriend = Friend,
                    CurrentFriendId = Friend.Id,
                };
                //Create(item);
                await CreateAsync(item);
            }
        }



        public List<User> GetFriendsByUser(User target)
        {
            IEnumerable<User> friends = null;
            //Не стоит добавить пользователя в друзья его самого? Всегда ведь приятно поговорить с умным человеком))
            //var fr = Set.FirstOrDefault(f => f.UserId == target.Id);
            //if (fr == null)
            //{
            //    AddFriend(target, target);
            //}
            //friends = Set.Include(x => x.CurrentFriend).AsEnumerable().Where(x => x.User.Id == target.Id).Select(x => x.CurrentFriend);
            friends = Set.Include(x => x.CurrentFriend).AsEnumerable().Where(x => x.UserId == target.Id).Select(x => x.CurrentFriend);

            return friends.ToList();
        }

        public async Task<List<User>> GetFriendsByUserAsync(User target)
        {
            IEnumerable<User> friends = null;
            friends = Set.Include(x => x.CurrentFriend).AsEnumerable().Where(x => x.UserId == target.Id).Select(x => x.CurrentFriend);

            return friends.ToList();
        }


        public void DeleteFriend(User target, User Friend)
        {
            var friends = Set.AsEnumerable().FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == Friend.Id);
            if (friends != null)
            {
                Delete(friends);
            }
        }

        public async Task DeleteFriendAsync(User target, User Friend)
        {
            var friends = Set.AsEnumerable().FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == Friend.Id);
            if (friends != null)
            {
                await DeleteAsync(friends);
            }
        }

    }
}
