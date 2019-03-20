using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkCommunication.Service
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly VkApi _apiProxy;
        private authorize communicationSettings;

        public AuthorizationService()
        {
            var accessToken = communicationSettings.accessToken;
            if (string.IsNullOrEmpty(accessToken))
            {
                _apiProxy.Authorize(new ApiAuthParams()
                {
                    ApplicationId = communicationSettings.appId,
                    Login = communicationSettings.login,
                    Password = communicationSettings.password,
                    Settings = Settings.All
                });
            }
            else
            {
                _apiProxy.Authorize(new ApiAuthParams
                {
                    AccessToken = accessToken,ApplicationId = communicationSettings.appId
                });
            }
        }

        public VkCollection<User> GetUserFriends(long profileId) => _apiProxy.Friends.Get(new FriendsGetParams()
        {
            UserId = profileId,
            Fields = ProfileFields.Sex
        });
    }
}