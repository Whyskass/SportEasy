namespace SportEasy.Model.User
{
    public class User
    {
        #region Properties

        public int Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }

        #endregion 
    }
}