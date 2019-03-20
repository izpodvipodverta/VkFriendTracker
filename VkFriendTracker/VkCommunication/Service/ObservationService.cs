using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Repository;
using Domain.Entities;

namespace VkCommunication.Service
{
    public class ObservationService : IObservationService
    {
        private readonly IRepository<ObservedUser> _userRepository;
        private readonly IRepository<FriendEntry> _friendEntryRepository;
        private readonly IAuthorizationService _authorizationService;

        public ObservationService(IRepository<FriendEntry> friendEntryRepository, 
            IRepository<ObservedUser> userRepository, IAuthorizationService authorizationService)
        {
            _friendEntryRepository = friendEntryRepository;
            _userRepository = userRepository;
            _authorizationService = authorizationService;
        }
    }

    public interface IObservationService
    {

    }
}
