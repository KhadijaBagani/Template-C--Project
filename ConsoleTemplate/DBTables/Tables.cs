
namespace DBTables.Overflow {
    /// <summary>
    /// Comentario de Stack Overflow
    /// </summary>
    public class Comment
    {
        public int id{  
			get; //Getter público (puede ser leida)
			private set; //Setter privado (no puede ser modificada)
		}
        public DateTime creationDate;
        public int postId;
        public int? score; //nullable
        public string text=""; //needs value
        public int userId;

		private Database? _db; //Privado para que no se modifique desde fuera
public void AlterId(int newId){
	this.id = newId;
}

        public Comment(int id, DateTime creationDate, int postId, string text, int userId, int? score = null){
            this.text = text;
            this.score = score;
            this.id = id;
            this.creationDate = creationDate;
            this.postId = postId;
            this.userId = postId;

			
		}
	/// <summary>
	/// Añade el objeto a su "tabla" correspondiente en la base de datos
	/// </summary>
	/// <param name="db">base de datos a la que añadir el objeto</param>
	public void InsertIn(Database db){
		if(this._db != null)
			throw new Exception("DbObject is already assigned");
		//Insertar objeto en diccionario
		if (!db.comments.ContainsKey(this.id))
		{
			db.comments.Add(this.id, this);
		}
			else
		{
			throw new InvalidOperationException($"Ya existe un comentario con Id '{this.id}'.");
		}
		this._db = db;
	}

}

	public class Badges {
		public int id;
		// public string name;
		public int userId;
		// public DateTime date;
	}

	// public class LinkTypes {
	// 	public int id;
	// 	public string type;
	// }
	// public class PostLinks {
	// 	public int id;
	// 	public DateTime creationDate;
	// 	public int postId;
	// 	public int relatedPostId;
	// 	public int linkTypeId;
	// }
	public class Posts {
		public int id;
		public int acceptedAnswearId; //nullable
		// public string Body;
		// public DateTime ClosedDate; //nullable
		// public int CommentCount; //nullable
		// public DateTime CommunityOwnedDate; //nullable
		// public DateTime CreationDate; 
		// public int FavoriteCount; //nullable
		// public DateTime LastActivityDate; 
		// public DateTime LastEditDate; //nullable
		// public  string LastEditorDisplayName; //nullable
		// public int LastEditorUserId; //nullable
		// public int OwnerUserId; //nullable
		// public int ParentId; //nullable
		// public int PostTypeId;
		// public int Score;
		// public string Tags; //nullable
		// public string Title; //nullable
		// public int ViewCount; 
	}
	// public class PostTypes {
	// 	public int id;
	// 	public string type;
	// }
	public class Users {
		public int id; 
		public string? aboutMe;  //nullable
		public int age;   //nullable
		public DateTime creationDate; 
		public string? displayName;
		public int downVotes;
		public string? emailHash;  //nullable
		public DateTime lastAccessDate;  //nullable
		public string? location;  //nullable
		public int reputation;
		public int upVotes;
		public int views;
		public string? websiteUrl;  //nullable
		public int accountId;  //nullable
	}
// public class Votes {
// 	public int id;
// 	public int
// 	public int
// 	public int
// 	public int
// 	public DateTime
// }
}

