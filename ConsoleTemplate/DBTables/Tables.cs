
namespace DBTables.Overflow {
    public class Comment
    {
        public int Id;
        public DateTime CreationDate;
        public int PostId;
        public int? Score; //nullable
        public string? Text; //needs value
        public int UserId;
        
    }
}
