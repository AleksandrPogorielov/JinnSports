using JinnSports.DAL.Repositories;
using JinnSports.Parser.App.HtmlParsers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JinnSportsService
{
    public partial class JSONService : ServiceBase
    {
        Thread htmlParserThread;


        public JSONService()
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
