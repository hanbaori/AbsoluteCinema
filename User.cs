namespace AbsoluteCinema
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Role Role => Role.User;

        public User(string Name, int Id)
        {
            this.Name = Name;
            this.Id = Id;
        }
    }
}
