namespace AbsoluteCinema
{
    public class Admin : User
    {
        //ДЕЛІТНУТИ
        public override Role Role => Role.Admin;
        public Admin(string Name, int Id) : base(Name, Id)
        {
        }
    }
}
