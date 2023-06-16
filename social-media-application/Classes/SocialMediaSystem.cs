using System.Linq;
namespace social_media_application.Classes
{
    static class SocialMediaSystem
    {
        private static int _Id = 1;
        private static List<User> _users = new List<User>();
        private static List<Posts> _posts = new List<Posts>();
        private static List<Reactions> _reactions = new List<Reactions>();
        public static void SetUser(string username, int age)
        {
            User user = new User(username, age);
            _users.Add(user);
        }
        public static void CreatePost(string body, User user)
        {
            Posts post = new Posts(body, user, _Id);
            _posts.Add(post);
            _Id++;
        }
        public static void SetReaction(string condition, User user, int Id)
        {
            User existingUser = _users.FirstOrDefault(u => u == user);
            Posts existingPost = _posts.FirstOrDefault(p => p.Id == Id);
            Reactions existingReaction = _reactions.FirstOrDefault(r => r.User == user && r.Post.Id == Id);
            if (existingUser != null)
            {
                if (existingPost != null)
                {
                    if (existingReaction != null)
                    {
                        if (existingReaction.Reaction != condition)
                        {
                            existingReaction.SetReaction(condition);
                            Console.WriteLine($"{user.UserName} set a reaction changed to \"{condition}\" on post with ID: {existingPost.Id}");
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, {user.UserName}. the reaction \"{condition}\" already exists on post with ID: {existingPost.Id}");
                        }
                    }
                    else
                    {
                        Reactions reaction = new Reactions(condition, user, existingPost);
                        _reactions.Add(reaction);
                        Console.WriteLine($"{user.UserName} set a new reaction '{condition}' on post with ID: {existingPost.Id}");
                    }
                }
                else
                {
                    throw new Exception($"No such Post ID as User Name of {user.UserName} and ID {Id}.");
                }
            }
            else
            {
                throw new Exception($"The User {user.UserName} does not exist.");
            }
        }
        public static User? GetUser(string userName)
        {
            User foundUser = _users.First(s => s.UserName == userName);
            return foundUser;
        }
        public static void GetAllPostsByUser(User user)
        {
            User newUser = _users.FirstOrDefault(u => u.UserName == user.UserName);
            if (newUser != null)
            {
                List<Posts> userPosts = _posts.Where(p => p.User == newUser).ToList();
                Console.Write($"{newUser.UserName} has posts of total: {userPosts.Count}. The posts ID are: ");
                foreach (Posts post in userPosts)
                {
                    Console.Write($"{post.Id}");
                    Console.WriteLine();
                }
            }
        }
        public static Posts? GetPostIdFromUser(int postId, User user)
        {
            User newUser = _users.FirstOrDefault(u => u.UserName == user.UserName);
            if (newUser != null)
            {
                Posts post = _posts.FirstOrDefault(p => p.Id == postId && p.User == newUser);
                return post;
            }
            throw new Exception($"Can not find the Post with this ID {postId}");
        }
        public static void PrintAllReactions()
        {
            Console.WriteLine("All Reactions:");
            foreach (var reaction in _reactions)
            {
                Console.WriteLine($"User: {reaction.User.UserName}, Post ID: {reaction.Post.Id}, Reaction: {reaction.Reaction}");
            }
        }
    }
}
