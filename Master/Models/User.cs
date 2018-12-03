namespace User.Models {
    public class User {
        public long id {
            get;
            set;
        }
        public string username {
            get;
            set;
        }
        public string password {
            get;
            set;
        }
        public bool isAdmin {
            get;
            set;
        }
    }
}