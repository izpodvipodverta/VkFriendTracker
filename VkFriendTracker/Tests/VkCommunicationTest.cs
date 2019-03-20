using Microsoft.VisualStudio.TestTools.UnitTesting;
using VkCommunication.Service;

namespace Tests
{
    [TestClass]
    public class VkCommunicationTest
    {
        [TestMethod]
        public void AuthorizationServiceGetFriends()
        {
            //Arrange
            IAuthorizationService authorizationService = new AuthorizationService();
            //Act
            var users = authorizationService.GetUserFriends(61802985);
            //Assert
            Assert.IsTrue(users.Count>0);
        }
    }
}
