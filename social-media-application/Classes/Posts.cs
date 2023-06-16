namespace social_media_application.Classes
{
    class Posts
    {
        private string _body;
        public string Body { get { return _body; } }
        private string _createDate;
        public string CreateDate { get { return _createDate; } }
        private int _Id;
        public int Id { get { return _Id; } }
        private User _user;
        public User User { get { return _user; } }
        public string GetDate()
        {
            string tempTime = DateTime.Now.ToString("d");
            return tempTime;
        }
        public void SetPost(string body)
        {
            if (string.IsNullOrEmpty(body.Trim()))
            {
                throw new ArgumentNullException("Post body cannot be empty.");
            }
            else if (body.Length < 10 || body.Length > 250)
            {
                throw new ArgumentException("Post body must be between 10 and 250 characters.");
            }
            else
            {
                _body = body;
                string tempTime = GetDate();
                _createDate = tempTime;
            }
        }
        public Posts(string body, User user, int id)
        {
            _Id = id;
            SetPost(body);
            _user = user;
        }
    }
}
