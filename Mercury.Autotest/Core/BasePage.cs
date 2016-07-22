using RelevantCodes.ExtentReports;
namespace Mercury.Autotest
{
    public class BasePage<M>
        where M : BasePageElementMap, new()
    {
        private static BasePage<M> instance;
        protected readonly string url;
        public ExtentTest extentTest;

        public BasePage()
        {
            this.extentTest = ExtentReportManager.ExtentTest; 
        }

        public static BasePage<M> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BasePage<M>();
                }

                return instance;
            }
        }

        protected M Map
        {
            get
            {
                return new M();
            }
        }
    }

    public class BasePage<M, P> : BasePage<M>
        where M : BasePageElementMap, new()
        where P : BasePageProcessing<M>, new()
    {
        public BasePage()
        {
        }

        public P Process()
        {
            return new P();
        }
    }
}