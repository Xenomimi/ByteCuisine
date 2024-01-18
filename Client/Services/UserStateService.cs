using ByteCuisine.Shared;

namespace ByteCuisine.Client.Services
{
    public class UserStateService
    {
        public int CurrentUser { get; private set; }
        public string? CurrentUserType { get; private set; }

        public event Action OnChange;

        public void SetCurrentUser(int user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        public void SetCurrentUser(int user, string user_type)
        {
            CurrentUser = user;
            CurrentUserType = user_type;
            NotifyStateChanged();
        }

        public void Logout()
        {
            CurrentUser = 0;
            CurrentUserType = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
