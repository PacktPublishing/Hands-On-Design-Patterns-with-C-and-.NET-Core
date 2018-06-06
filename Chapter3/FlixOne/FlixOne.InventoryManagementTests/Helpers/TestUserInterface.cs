using System;
using System.Collections.Generic;
using FlixOne.InventoryManagement.UserInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlixOne.InventoryManagementTests.Helpers
{
    class TestUserInterface : IUserInterface
    {
        private readonly List<Tuple<string, string>> _expectedReadRequests;
        private readonly List<string> _expectedWriteMessageRequests;
        private readonly List<string> _expectedWriteWarningRequests;

        private int _expectedReadRequestsIndex;
        private int _expectedWriteMessageRequestsIndex;
        private int _expectedWriteWarningRequestsIndex;

        public TestUserInterface(List<Tuple<string, string>> expectedReadRequests, List<string> expectedWriteRequests, List<string> expectedWarningRequests)
        {
            _expectedReadRequests = expectedReadRequests;
            _expectedWriteMessageRequests = expectedWriteRequests;
            _expectedWriteWarningRequests = expectedWarningRequests;
        }

        /// <summary>
        ///  Given a message, verify it matches what is expected and return a result
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <remarks>Message values received are expected in a particular order</remarks>
        public string ReadValue(string message)
        {
            Assert.IsTrue(_expectedReadRequestsIndex < _expectedReadRequests.Count,
                "Received too many command read requests.");
            
            Assert.AreEqual(_expectedReadRequests[_expectedReadRequestsIndex].Item1, message, "Received unexpected command read message");

            return _expectedReadRequests[_expectedReadRequestsIndex++].Item2;
        }

        public void WriteMessage(string message)
        {
            Assert.IsTrue(_expectedWriteMessageRequestsIndex < _expectedWriteMessageRequests.Count,
                "Received too many command write message requests.");

            Assert.AreEqual(_expectedWriteMessageRequests[_expectedWriteMessageRequestsIndex++], message, "Received unexpected command write message");            
        }

        public void WriteWarning(string message)
        {
            Assert.IsTrue(_expectedWriteWarningRequestsIndex < _expectedWriteWarningRequests.Count,
                "Received too many command write warning requests.");

            Assert.AreEqual(_expectedWriteWarningRequests[_expectedWriteWarningRequestsIndex++], message, "Received unexpected command write warning message");
        }

        public void Validate()
        {
            Assert.IsTrue(_expectedReadRequestsIndex == _expectedReadRequests.Count, "Not all read requests were performed.");
            Assert.IsTrue(_expectedWriteMessageRequestsIndex == _expectedWriteMessageRequests.Count, "Not all write requests were performed.");
            Assert.IsTrue(_expectedWriteWarningRequestsIndex == _expectedWriteWarningRequests.Count, "Not all warning requests were performed.");
        }
    }
}
