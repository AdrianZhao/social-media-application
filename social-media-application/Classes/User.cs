using System.Text.RegularExpressions;

namespace social_media_application.Classes
{
    class User
    {
        private string _userName;
        public string UserName { get { return _userName; } }
        private int _age;
        public int Age { get { return _age; } }
        private List<Posts> _posts = new List<Posts>();
        private List<Reactions> _reactions = new List<Reactions>();
        public List<Reactions> Reactions { get { return _reactions; } }
        public void SetUser(string userName, int age)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User Name cannot be empty.");
            }
            else if (userName.Length < 3 || userName.Length > 20)
            {
                throw new ArgumentException("User Name must be between 3 and 20 characters.");
            }
            // https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=net-6.0
            else if (!Regex.IsMatch(userName, @"^[a-zA-Z0-9]+$"))
            {
                throw new ArgumentException("User Name can only contain letters and numbers.");
            }
            else
            {
                _userName = userName;
            }
            if (age < 0)
            {
                throw new ArgumentOutOfRangeException("Age can not be negative.");
            }
            else if (age > 100)
            {
                throw new ArgumentOutOfRangeException("You are too old to use social media.");
            }
            else
            {
                _age = age;
            }
        }
        public void AddPost(Posts post)
        {
            _posts.Add(post);
        }
        public int GetPostCount()
        {
            return _posts.Count;
        }
        public void SetReaction(Reactions reaction)
        {
            _reactions.Add(reaction);
        }
        public User(string userName, int age)
        {
            _userName = userName;
            _age = age;
        }
        public void ListPosts()
        {
            Console.WriteLine($"Posts created by {UserName}:");
            if (_posts != null)
            {
                foreach (Posts post in _posts)
                {
                    Console.WriteLine($"{post.Body} (Created on: {post.CreateDate})");
                }
            }
            else
            {
                Console.WriteLine("None.");
            }
        }
        public void ListReactions()
        {
            Console.WriteLine($"Reactions created by {UserName}:");
            if ( _reactions != null)
            {
                foreach (Reactions reaction in _reactions)
                {
                    Console.WriteLine($"{reaction.Reaction} on post \"{reaction.Post.Body}\"");
                }
            }
            else
            {
                Console.WriteLine("None.");
            }
        }
    }
}
