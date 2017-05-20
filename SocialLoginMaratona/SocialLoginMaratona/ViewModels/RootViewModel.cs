using SocialLoginMaratona.Helpers;

namespace SocialLoginMaratona.ViewModels
{
    public class RootViewModel : BaseViewModel
    {
        public string Title => "Principal";
        public string UserId => Settings.UserId;
        public string Token => Settings.AuthToken;
    }
}
