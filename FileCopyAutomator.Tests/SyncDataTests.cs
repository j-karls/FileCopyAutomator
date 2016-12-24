using FileCopyAutomater;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopyAutomator.Tests
{
    [TestFixture]
    public class SyncDataTests
    {
        private SyncData _sync;
        private string _invalidPath = string.Empty;
        private string _sourcePathFile = "";
        private string _sourcePathDirectory = "";
        private string _targetPathFile = "";
        private string _targetPathDirectory = "";

        [OneTimeSetUp]
        public void InitialSetup()
        {
        }

        [TearDown]
        public void TearDownEachTime()
        {
            _sync = null; 
        }

        [Test]
        public void Sync_CanOverwrite_Overwrites()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }

        [Test]
        public void Sync_CanNotOverwrite_DoesNotOverwrite()
        {

        }
    }
}
