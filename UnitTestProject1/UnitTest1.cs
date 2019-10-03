using ConsoleApp1;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Analytics.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTrackEvent()
        {
            // Shims can be used only in a ShimsContext:  
            using (ShimsContext.Create())
            {
                Mock<MockShimAnalytics> mock = new Mock<MockShimAnalytics>();
                mock.Object.InitFake();
                mock.Setup(v => v.TrackEvent(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()));

                MyApp.Check();

                mock.Verify(v => v.TrackEvent(It.IsAny<string>(), It.IsAny<IDictionary<string, string>>()), Times.Once());
            }
        }

    }

    public class MockShimAnalytics
    {
        public void InitFake()
        {
            ShimAnalytics.TrackEventStringIDictionaryOfStringString = (string eventName, IDictionary<string, string> properties) => { TrackEvent(eventName, properties); };
        }

        public virtual void TrackEvent(string eventName, IDictionary<string, string> properties)
        {
            // Yahou
        }
    }
}
