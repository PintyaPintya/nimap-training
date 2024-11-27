//https://members.codewithmosh.com/courses/object-oriented-programming-in-csharp-1/lectures/3497740
    public class Post
    {
        private string _title;
        private string _description;
        private DateTime _created;
        private int _votes;

        public Post(string title, string description)
        {
            _title = title;
            _description = description;
            _created = DateTime.Now;
            _votes = 0;
        }

        public void Upvote()
        {
            _votes++;
        }
        public void Downvote()
        {
            _votes--;
        }

        public int GetVote()
        {
            return _votes;
        }
    }
