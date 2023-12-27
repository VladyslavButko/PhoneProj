using System.Web;

namespace PhoneMysql.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }


        public User(){ }


        public class Builder
        {
            public string Email;
            public int RoleId;
            public string Password;

            public int Id = 0;
            public string Name = "";
            public string Surname = "";

            public Builder(string email, int roleId, string password)
            {
                this.Email = email;
                this.RoleId = roleId;
                this.Password = password;
            }

            //НЕОБОВ'ЯЗКОВІ
            public Builder setId(int val)
            {
                Id = val;
                return this;
            }

            public Builder setName(string val)
            {
                Name = val;
                return this;
            }

            public Builder setSurname(string val)
            {
                Surname = val;
                return this;
            }

            public User Build()
            {
                // Перевірка перед побудовою
                if (string.IsNullOrEmpty(Email) || RoleId == 0 || string.IsNullOrEmpty(Password))
                {
                    throw new InvalidOperationException("Email, RoleId, and Password are required.");
                }
                return new User(this);
            }
        }
        private User(Builder builder)
        {
            Id = builder.Id;
            Name = builder.Name;
            Surname = builder.Surname;
            Email = builder.Email;
            Password = builder.Password;
            RoleId = builder.RoleId;
        }
    }
}