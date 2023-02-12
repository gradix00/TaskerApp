namespace ewads_mvvm.Model.Helpers
{
    public enum Status
    {
        admin,
        user,
        banned
    }
    public enum Gender
    {
        Unidentified,
        Woman,
        Man
    }
    public struct UserData
    {
        public int ID { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public int Points { get; set; }
        public Status Status { get; set; }
        public Gender Gender { get; set; }
        public bool RequirePasswordReset { get; set; }
        public bool IsActive { get; set; }
    }
}
