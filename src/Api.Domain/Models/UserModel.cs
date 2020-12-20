using System;

namespace Api.Domain.Models
{
    public class UserModel
    {
        private Guid _id;
        public Guid id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private DateTime _creatAt;
        public DateTime CreatAt
        {
            get { return _creatAt; }
            set { _creatAt = value == null ? DateTime.UtcNow : value; }
        }

        private DateTime _updateAt;
        public DateTime UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }

    }
}
