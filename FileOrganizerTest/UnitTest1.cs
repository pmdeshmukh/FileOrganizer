using System;
using FileOrganizer;
using FileOrganizerHelper;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FileOrganizerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test = new Mock<IFileOrganizerHelper>().Setup(m => m.OrganizeFiles(It.IsAny<string>(), It.IsAny<string>()));
            var loggerObj = new Mock<ILog>();
            loggerObj.Setup(o => o.Info(It.IsAny<object>()));
            Program.Main(new string[] { });
        }
    }
}
