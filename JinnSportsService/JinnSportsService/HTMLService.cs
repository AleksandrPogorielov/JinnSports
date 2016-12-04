using JinnSports.DAL.Repositories;
using JinnSports.Parser.App.HtmlParsers;
using System.ServiceProcess;
using System.Threading;

namespace JinnSportsService
{
    public partial class HTMLService : ServiceBase
    {
        Thread htmlParserThread;


        public HTMLService()
        {
            InitializeComponent();
            HTMLParser24score parser = new HTMLParser24score(new EFUnitOfWork());
            htmlParserThread = new Thread(new ThreadStart(parser.Parse));
        }

        protected override void OnStart(string[] args)
        {
            htmlParserThread.Start();
        }

        protected override void OnStop()
        {
            htmlParserThread.Abort();
        }
    }
}
