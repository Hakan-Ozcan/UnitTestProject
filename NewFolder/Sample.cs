using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExample.NewFolder
{
    public interface ISample
    {
        int Check();
        void Handler();
    }
    public class Sample : ISample
    {
        public int Check()
        {
            return 5;
        }
        public void Handler()
        {

        }
    }
    public class SampleService
    {
        ISample _sample;
        public SampleService(ISample sample)
        {
            _sample = sample;
        }
        public int Check()
        {
            _sample.Handler();
            return _sample.Check();
        }
        public void Handler() => _sample.Handler();
    }
    public class SampleTest
    {
        Mock<ISample> _mockSample;
        SampleService _sampleService;
        public SampleTest()
        {
            _mockSample = new Mock<ISample>();
            _sampleService = new SampleService(_mockSample.Object);
        }
        [Fact]
        public void Sample_Test()
        {
            _mockSample.Setup(s => s.Check()).Returns(5);
            _sampleService.Check();
            _mockSample.Verify(s => s.Handler(), Times.Once());
        }
    }
}
