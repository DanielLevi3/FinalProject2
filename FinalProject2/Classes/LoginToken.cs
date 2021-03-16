namespace FinalProject2
{
    public class LoginToken<T> where T :IUser
    {
        public T User { get; set; } 
    }
}