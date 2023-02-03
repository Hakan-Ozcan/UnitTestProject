using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExample.NewFolder
{
    public interface IMathematicss
    {
        int Divide(int number1, int number2);
    }
    public class Mathematics : IMathematicss
    {
        public int Divide(int number1, int number2)
         => number1 / number2;
    }
    public class MathematicsTest1
    {
        [Fact]
        public void DivideTest()
        {
            Mathematics mathematics = new Mathematics();
            var mathematicsMock = new Mock<IMathematicss>();
            mathematicsMock.Setup(m => m.Divide(1, 0))
                .Throws<DivideByZeroException>();

            var exception = Assert.Throws<DivideByZeroException>(() => mathematics.Divide(1, 0));
        }
    }
}
