using jmp;
using System.Threading.Tasks.Sources;
namespace TestProject
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var jmp = new jmp.JmpSaveAndLoad();
            jmp.save_message_and_path("", "");
        }
    }
}
