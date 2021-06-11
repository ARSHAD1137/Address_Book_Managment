using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ContactUpdate()
        {
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            ContactModel updateModel = new ContactModel()
            {
                Contact_Id = 1,
                Contact_Address = "Hill Tower",
                Contact_City = "Pune",
                Contact_State = "Maharashtra",
                Contact_ZipCode = 414144
            };

            int Update = addressBookRepo.UpdateEmployeeSalary(updateModel);

            Assert.AreEqual(updateModel.Contact_Address, Update);
        }
    }
}
