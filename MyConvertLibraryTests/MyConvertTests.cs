using MyConvertLibrary;

namespace MyConvertLibraryTests
{
    [TestClass]
    public class MyConvertTests
    {
        [TestMethod]
        public void StringToDouble_1000Random()
        {
            double exp;
            string prm;
            double act;

            Random rnd = new Random();
            for (int i = 0; i < 100000; i++)
            {
                exp = rnd.NextDouble();
                prm = exp.ToString("F13");
                var exp1 = Convert.ToDouble(prm);
                act = MyConvert.StringToDouble(prm);

                Assert.AreEqual(exp1, act);
            }
        }

    }
}