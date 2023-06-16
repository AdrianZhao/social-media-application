namespace social_media_application.Classes
{
    class Reactions
    {
        private string _reaction;
        public string Reaction { get { return _reaction; } }
        private User _user;
        public User User { get { return _user; } }
        private Posts _post;
        public Posts Post { get { return _post; } }
        public string SetReaction(string reaction)
        {
            string tempReaction = reaction.Trim().ToLower();
            if (string.IsNullOrEmpty(tempReaction))
            {
                throw new ArgumentNullException("Please enter you reaction to the post.");
            } else if (tempReaction == "good")
            {
                _reaction = tempReaction;
                return _reaction;
            } else if (tempReaction == "bad")
            {
                _reaction = tempReaction;
                return _reaction;
            }
            else
            {
                throw new ArgumentException("Please enter the correct reaction to the post, either Good or Bad.");
            }
        }
        public void SetUser(User user)
        {
            _user = user;
        }
        public void SetPost(Posts post)
        {
            _post = post;
        }
        public Reactions(string condition, User user, Posts post)
        {
            if (post.User != user)
            {
                _reaction = SetReaction(condition);
                _user = user;
                _post = post;
            }
            else
            {
                throw new Exception($"Hey, {user.UserName}, You can not reacte to your own post.");
            }
        }
    }
}
