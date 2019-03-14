using ConsoleUIGenerics.Models;

//using ConsoleUIGenerics.WithoutGenerics;
using ConsoleUIGenerics.WithGenerics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

namespace ConsoleUIGenerics
{
    public class Program
    {
        private static void Main(string[] args)
        {
            List<SCM_AIFFailedPartDispositionLines> disposeLines = new List<SCM_AIFFailedPartDispositionLines>()
           {
               new SCM_AIFFailedPartDispositionLines
               {
                   ShipTo = "rrett",
                   AllocatedTo = "432",
                   Condition = "432",
                   Disposition = "hgh",
                   DispositionType = "ghfh",
                   Handling = "hgfh",
                   ITADPickupDate = "bvn",
                   Location = "l",
                   ManifestId = "ytu",
                   NotificationId = "uyu",
                   OutboundCarrier = "uyu",
                   OutboundTrackingNumber = "uyu",
                   RequestId = "uyu"
               },
                new SCM_AIFFailedPartDispositionLines
                {
                   ShipTo ="ytry",
                   AllocatedTo = "ytr",
                   Condition = "yrty",
                   Disposition = "ytr",
                   DispositionType = "ytr",
                   Handling = "ytr",
                   ITADPickupDate = "tyt",
                   Location = "ytr",
                   ManifestId = "t",
                   NotificationId = "ytr",
                   OutboundCarrier = "yt",
                   OutboundTrackingNumber = "ytr",
                   RequestId = ""
                }
           };

            SCM_AXAssetLifeCycleServiceClient dispose = new SCM_AXAssetLifeCycleServiceClient();
            var results = dispose.dispositionFailedPart(disposeLines.ToArray());

            Program program = new Program();
            string[] actualStringArray = new string[] { "Today", "is", "the", "wonderful", "day", "of", "my", "life" };
            string result = program.CombineString(actualStringArray);

            WebClient client = new WebClient();
            var download = client.DownloadString("https://www.google.com/");
            Console.ReadLine();
            List<Person> person = new List<Person>();
            List<Logs> logs = new List<Logs>();

            string peoplePath = @"D:\Temp\Peoples.csv";
            //string logPath = @"D:\Temp\Logs.csv";
            PopulateData dataList = new PopulateData();
            PopulateData.PopulateList(person, logs);
            OriginalFileProcessor.SaveData(person, peoplePath);
            var res = OriginalFileProcessor.LoadData<Person>(peoplePath);

            // var res = OriginalFileProcessor.LoadPeople(peoplePath);
            foreach (var item in res)
            {
                Console.WriteLine($"{item.FirstName} , {item.LastName},{item.Age}");
            }
            //Collection<List<string>> str = "";
            //OriginalFileProcessor.SaveLog(logs, logPath);
            Console.ReadLine();
        }

        public string CombineString(string[] strArray)
        {
            string str = default(string);
            foreach (var item in strArray)
            {
                str += item + " ";
            }
            return str.Trim();
        }

        /*
        public class DatabasesAndContext : System.Web.UI.UserControl
        {
            protected System.Web.UI.WebControls.Label lblCurrentDBName;
            protected System.Web.UI.WebControls.Label lblHomeItem;
            protected System.Web.UI.WebControls.Label lblHomeItemVersion;
            protected System.Web.UI.WebControls.Label lblHomeItemTitle;
            protected System.Web.UI.WebControls.Label lblHomeItemText;
            protected System.Web.UI.WebControls.Label lblupdateitemresult;
            protected System.Web.UI.WebControls.Label lblMasterDBName;

            private void Page_Load(object sender, System.EventArgs e)
            {
                // Selects a specific database
                Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase("master");
                lblMasterDBName.Text = "masterdatabase name: " + master.Name;

                // Select context database.
                Sitecore.Data.Database current = Sitecore.Context.Database;
                lblCurrentDBName.Text = "current context database name: " + current.Name;

                // Get latest version of an item in current language
                string itemPath = "/sitecore/content/home";
                Sitecore.Data.Items.Item item = Sitecore.Context.Database.Items[itemPath];
                lblHomeItem.Text = "name of the '" + itemPath + "' node: " + item.Name;

                // Extract item with right item (by guid), language and version.
                Sitecore.Data.ID itemID = Sitecore.Data.ID.Parse("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}");
                Sitecore.Globalization.Language language = Sitecore.Globalization.Language.Predefined.Danish;
                Sitecore.Data.Version version = Sitecore.Data.Version.Parse(1);
                Sitecore.Data.Items.Item homeitemlanguage = Sitecore.Context.Database.Items[itemID, language, version];
                lblHomeItemVersion.Text = "Home item in version 1 (in English): " + homeitemlanguage.Name;

                // Extract field values
                Sitecore.Data.Items.Item homeitem = Sitecore.Context.Database.Items["/sitecore/content/home"];
                lblHomeItemTitle.Text = "Title:" + homeitem["title"];
                lblHomeItemText.Text = "Text:" + homeitem["text"];


                // Attempts to write to the web database from the current context. If you are
                // on a web site, this will fail as user is on the extranet domain and 
                // anonymous!
                try
                {
                    Sitecore.Data.Items.Item itemtoupdate =
                      Sitecore.Context.Database.Items["/sitecore/content/home"];
                    using (new Sitecore.Data.Items.EditContext(item))
                    {
                        itemtoupdate["title"] = "My new title";
                        itemtoupdate["text"] = "My <b>new</b> text";
                    }
                }
                catch (Exception ex)
                {
                    lblupdateitemresult.Text = ex.Message;
                }


                // Attempts to write to the master database from the current context. If you are
                // on a web site, this will fail as user is on the "wrong domain" (extranet) and 
                // even is anonymous!
                try
                {
                    Database masterdb = Factory.GetDatabase("master");
                    Item itemtoupdate2 =
                      masterdb.Items["/sitecore/content/home"];
                    using (new EditContext(item))
                    {
                        itemtoupdate2["title"] = "My new title";
                        itemtoupdate2["text"] = "My <b>new</b> text";
                    }
                }
                catch (Exception ex)
                {
                    lblupdateitemresult.Text = ex.Message;
                }

            }

            #region Web Form Designer generated code
            override protected void OnInit(EventArgs e)
            {
                //
                // CODEGEN: This call is required by the ASP.NET Web Form Designer.
                //
                InitializeComponent();
                base.OnInit(e);
            }

            /// <summary>
            ///        Required method for Designer support - do not modify
            ///        the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.Load += new System.EventHandler(this.Page_Load);

            }
            #endregion
        }*/
    }
}