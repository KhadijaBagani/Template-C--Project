
namespace DBTables.Overflow {
    /// <summary>
    /// Comentario de Stack Overflow
    /// </summary>
    public class Comment
    {
        public int id;
        public DateTime creationDate;
        public int postId;
        public int? score; //nullable
        public string text=""; //needs value
        public int userId;

        public Comment(int id, DateTime creationDate, int postId, string text, int userId, int? score = null){
            this.text = text;
            this.score = score;
            this.id = id;
            this.creationDate = creationDate;
            this.postId = postId;
            this.userId = postId;
        }

    }
}
