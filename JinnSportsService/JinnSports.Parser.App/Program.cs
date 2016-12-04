using System;
using System.Collections.Generic;
using System.Linq;
using JinnSports.DAL.Repositories;
using JinnSports.Entities;
using System.Data.SqlClient;
using JinnSports.Parser.App.JsonParserService;
using JinnSports.Parser.App.ProxyService.ProxyParser;
using JinnSports.Parser.App.ProxyService.ProxyConnection;
using System.Net;

namespace JinnSports.Parser.App
{
    class Program
    {
        static void Main(string[] args)
        {
             /*ProxyParser pp = new ProxyParser();
             pp.UpdateData(true, "http://foxtools.ru/Proxy");*/
            //pp.UpdateData();*/
            ProxyConnection pc = new ProxyConnection();
            //string proxy = pc.GetProxy();
            while (true)
            {
                //здесь соединение поиск прокси, так как они все мать их кривые
                //то это происходит очень долго поэтому в новом проекте этот мейн
                //будет выглядеть по-другому и с отобранными арсами 
                string proxy = pc.GetProxy();
                if (pc.CanPing(proxy) == true)
                {
                    try
                    {
                        WebProxy webProxy = new WebProxy(proxy, true);
                        WebRequest request = WebRequest.Create("https://2ip.ru");
                        request.Proxy = webProxy;
                        WebResponse response = request.GetResponse();
                        //здесь нужно запускать нужный парсер там где реквест понятно урл нужного сайта
                    }
                    catch (Exception e)
                    {
                        pc.SetStatus(proxy, false);
                    }
                }
                else
                {
                    pc.SetStatus(proxy, false);
                }
            }
            /*pc.SetStatus(proxy, true);
            //string a = ConfigSection.XmlPath();
            string path = ConfigSettings.Xml();*/
        }
    }
}
