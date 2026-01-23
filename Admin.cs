namespace AbsoluteCinema
{
    class Admin : User
    {
        public override Role Role => Role.Admin;
        public Admin(string Name, int Id) : base(Name, Id)
        {
        }
    }
}
