using RelevantCodes.ExtentReports;
namespace Mercury.Autotest
{
    public class BasePageProcessing<M>
        where M : BasePageElementMap, new()
    {
        public ExtentTest extentTest;

        public BasePageProcessing()
        {
            this.extentTest = ExtentReportManager.ExtentTest;
        }

        protected M Map
        {
            get
            {
                return new M();
            }
        }
    }
}