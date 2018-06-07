using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using hungpage2018.Models;
using System.Text.RegularExpressions;
using System.Text;


namespace hungpage2018
{

    public class ChatHub : Hub
    {


        #region Defn
        public static List<Models.OnlineUser> OnlineUsers = new List<Models.OnlineUser>();
        #endregion


        public override Task OnConnected()
        {

            var Username = Context.QueryString["Username"];
            var GroupName = Context.QueryString["GroupName"];

            var existRecord = OnlineUsers.Where(x => x.Username == Username).FirstOrDefault();
            if (existRecord == null)
            {

                Models.OnlineUser newUser = new Models.OnlineUser()
                {
                    Username = Username,
                    ConnectionID = Context.ConnectionId,
                    groupName = GroupName
                };
                OnlineUsers.Add(newUser);

                Groups.Add(newUser.ConnectionID, GroupName);

                if (GroupName == "1")
                {
                    int qtylist = 0;
                    var tousr = OnlineUsers.Where(x => x.Username == Username).FirstOrDefault();
                    foreach (Models.OnlineUser item in OnlineUsers)
                    {
                        string listname = (OnlineUsers[qtylist].Username).ToString();
                        Clients.Client(tousr.ConnectionID).ReceiveListNmae(listname, qtylist);
                        qtylist++;
                    }
                }
                else
                {

                    string result = string.Join("|", adminuser());
                    string[] results = result.Split('|');
                    if (result.Length > 1)
                    {
                        foreach (var item in results)
                        {
                            var tousr = OnlineUsers.Where(x => x.Username == item).FirstOrDefault();
                            Clients.Client(tousr.ConnectionID).ReceiveListNmae2(Username);
                        }
                    }
                }

                loginSdMessages(Username);
                return base.OnConnected();
            }
            else
            {
                existRecord.ConnectionID = Context.ConnectionId;
                existRecord.groupName = GroupName;
                loginSdMessages(Username);
                return base.OnConnected();
            }
        }

        public void broadCastMsg(string message, string groupName)
        {
            var usr = OnlineUsers.Where(x => x.ConnectionID == Context.ConnectionId).FirstOrDefault();

            Clients.All.ReceiveMessage(usr.Username + " : " + message);
        }
        
        public void adminSdMessages(string message, string Username)
        {
            string patterns = @"/private\[.*?\]";
            Regex regexs = new Regex(patterns, RegexOptions.IgnoreCase);
            MatchCollection matches = regexs.Matches(message);
            StringBuilder sbs = new StringBuilder();
            foreach (Match match in matches)
            {
                string value = match.Value;
                sbs.Append(value);
            }
            string resultname = sbs.ToString();
            resultname = resultname.Replace("/private[", "");
            resultname = resultname.Replace("]", "");


            string resultmsg = message.Replace("/private[", "");
            if (resultname.Length > 0)
            {
                resultmsg = resultmsg.Replace(resultname, "");
            }
            resultmsg = resultmsg.Replace("] ", "");

            var tousr = OnlineUsers.Where(x => x.Username == resultname).FirstOrDefault();
            if (tousr != null)
            {
                var fromusr = OnlineUsers.Where(x => x.Username == Username).FirstOrDefault();
                Clients.Client(tousr.ConnectionID).AdminSdMessage("客戶服務 : " + resultmsg);
                Clients.Client(fromusr.ConnectionID).UserSdMessage("你 : " + resultmsg, resultname);
            }
        }

        public void userSdMessages(string message, string Username)
        {
            string result = string.Join("|", adminuser());
            string[] results = result.Split('|');
            if (result.Length>1)
            {
                var fromusr = OnlineUsers.Where(x => x.Username == Username).FirstOrDefault();
                foreach (var item in results)
                {
                    var tousr = OnlineUsers.Where(x => x.Username == item.ToString()).FirstOrDefault();
                    Clients.Client(tousr.ConnectionID).UserSdMessage(fromusr.Username + " : " + message, Username);
                }
                Clients.Client(fromusr.ConnectionID).AdminSdMessage("你 : " + message, Username);
            }
            else
            {
                var fromusr = OnlineUsers.Where(x => x.Username == Username).FirstOrDefault();
                Clients.Client(fromusr.ConnectionID).AdminSdMessage("未有管理員在線", Username);
            }
        }

        public void loginSdMessages(string Username)
        {

            string result = string.Join("|", adminuser());
            if (result.Length > 1)
            {
                var fromusr = OnlineUsers.Where(x => x.Username == Username).FirstOrDefault();
                Clients.Client(fromusr.ConnectionID).AdminSdMessage("客戶服務 : 你好", Username);
            }
            else
            {
                var fromusr = OnlineUsers.Where(x => x.Username == Username).FirstOrDefault();
                Clients.Client(fromusr.ConnectionID).AdminSdMessage("未有管理員在線", Username);
            }
        }
        public static string[] adminuser()
        {
            var list= OnlineUsers.Where(x => x.groupName == "1").ToList();
            int i = 0;
            foreach (var item in list)
            {
                 i++;
            }
            string[] adminname = new string[i];
            int j = 0;
            foreach (var item in list)
            {
                adminname[j] = item.Username;
                j++;
            }
            return adminname;
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            if (stopCalled)
            {

                var usr = OnlineUsers.Where(x => x.ConnectionID == Context.ConnectionId).FirstOrDefault();
                if (usr != null)
                {
                    OnlineUsers.Remove(usr);
                    string resultname = "tony";
                    var tousr = OnlineUsers.Where(x => x.Username == resultname).FirstOrDefault();
                    if (tousr!=null)
                    {
                        Clients.Client(tousr.ConnectionID).RemoveListNmae2(usr.Username);
                        Clients.Client(tousr.ConnectionID).ReceiveMessage(usr.Username);
                    }
                }
            }
            else
            {

            }

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }
}