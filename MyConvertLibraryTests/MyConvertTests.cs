using MyConvertLibrary;

namespace MyConvertLibraryTests
{
    [TestClass]
    public class MyConvertTests
    {
        [TestMethod]
        public void StringToDouble_100000Random()
        {
            double exp;
            string prm;
            double act;

            Random rnd = new Random();
            for (int i = 0; i < 100000; i++)
            {
                prm = rnd.NextDouble().ToString("F13");
                exp = Convert.ToDouble(prm);
                act = MyConvert.StringToDouble(prm);

                Assert.AreEqual(exp, act);
            }
        }

    }
}