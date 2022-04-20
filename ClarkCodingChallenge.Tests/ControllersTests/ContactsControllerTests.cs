using ClarkCodingChallenge.BusinessLogic;
using ClarkCodingChallenge.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClarkCodingChallenge.Tests.ControllerTest
{
    [TestClass]
    public class ContactsControllerTests
    {
        private ContactsService contactsService;

        [TestMethod]
        public void TestMethod1()
        {
            var controller = new ContactsController(contactsService);

            var response = controller.GetContacts();

            Assert.IsNotNull(response);
        }
    }
}
