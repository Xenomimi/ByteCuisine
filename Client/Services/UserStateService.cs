using ByteCuisine.Shared;

namespace ByteCuisine.Client.Services
{
    public class UserStateService
    {
        public int CurrentUser { get; private set; }

        public event Action OnChange;

        public void SetCurrentUser(int user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
