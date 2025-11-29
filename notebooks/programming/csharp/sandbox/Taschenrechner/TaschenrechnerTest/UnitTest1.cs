using Taschenrechner;

namespace TaschenrechnerTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test_EinfacheAddition()
        {
            int actualresult = Program.addiere(5, 10);
            Assert.Equal(15, actualresult );
        }

        [Theory]
        [InlineData(5,5,10)]
        [InlineData(4000,8000,12000)]
        public void Test_Additionen(int a, int b, int expected)
        {
            Assert.Equal(expected, Program.addiere(a,b));
        }
    }
}