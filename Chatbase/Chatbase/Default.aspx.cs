using ChatbaseApi;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Chatbase
{
    public partial class Default : System.Web.UI.Page
    {
        private static API Chatbase
        {
            get
            {
                return HttpContext.Current.Session["__Chatbase"] as API;
            }
            set
            {
                HttpContext.Current.Session["__Chatbase"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Initialize();
            }
        }

        private void Initialize()
        {
            if (Chatbase == null)
            {
                var apiKey = ConfigurationManager.AppSettings["ApiKey"];
                var chatId = ConfigurationManager.AppSettings["ChatId"];
                Chatbase = new API(apiKey, chatId);
            }
        }

        [WebMethod()]
        public static string SendMessage(string message)
        {
            var api = Chatbase;
            var response = Task.Run(() => api.SendMessage(message, $"SS_{DateTime.Today:yyyyMMdd}")).Result;
            return new JavaScriptSerializer().Serialize(response.Message);
        }
    }
}