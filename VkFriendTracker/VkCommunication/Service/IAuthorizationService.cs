﻿using VkNet.Model;
using VkNet.Utils;

namespace VkCommunication.Service
{
    public interface IAuthorizationService
    {
        VkCollection<User> GetUserData(long profileId);
    }
}