using System;
using System.Data;
using System.Windows.Forms;
using System.ServiceModel;
using System.Net;
using System.ServiceModel.Discovery;
using System.Collections.ObjectModel;

namespace ChatClient
{
    [ServiceContract(CallbackContract = typeof(IChatService))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void Join(string memberName);
        [OperationContract(IsOneWay = true)]
        void Leave(string memberName);
        [OperationContract(IsOneWay = true)]
        void SendMessage(string memberName, string message);
    }

    public interface IChatChannel : IChatService, IClientChannel
    {
    }

    [ServiceBehavior(MaxItemsInObjectGraph = 2147483646, IncludeExceptionDetailInFaults = true)]
    public partial class ChatClient : Form, IChatService
    {
        private delegate void UserJoined(string name);
        private delegate void UserSendMessage(string name, string message);
        private delegate void UserLeft(string name);

        private static event UserJoined NewJoin;
        private static event UserSendMessage MessageSent;
        private static event UserLeft RemoveUser;

        private string userName;
        private IChatChannel channel;
        private DuplexChannelFactory<IChatChannel> factory;

        private DataTable DtTasks;

        public ChatClient()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }

        public ChatClient(string MachineuserName, string date = null)
        {
            InitializeComponent();
            lbldate.Text = lbldate.Text + " : " + date;
            txtUserName.Text = MachineuserName;
            txtDays.Enabled = true;
            btnLogin.Focus();
            MessageBox.Show("Login to Start", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.AcceptButton = btnLogin;
        }

        public ChatClient(string userName)
        {
            this.userName = userName;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                try
                {
                    NewJoin += new UserJoined(ChatClient_NewJoin);
                    MessageSent += new UserSendMessage(ChatClient_MessageSent);
                    RemoveUser += new UserLeft(ChatClient_RemoveUser);

                    channel = null;
                    this.userName = txtUserName.Text.Trim();
                    /**/
                    #region IpAddress
                    string strHostName = System.Net.Dns.GetHostName();
                    string IPAddress = "";
                    IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

                    foreach (IPAddress ipAddress in ipEntry.AddressList)
                    {
                        if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                        {
                            IPAddress = ipAddress.ToString();
                        }
                    }

                    string Address = string.Format("net.tcp://{0}/ChatServer", IPAddress);
                    Uri URiAddress = new Uri(Address, UriKind.RelativeOrAbsolute);

                    #endregion

                    InstanceContext instanceContext = new InstanceContext(new ChatClient(txtUserName.Text.Trim()));



                    ////NetPeerTcpBinding chatBinding = new NetPeerTcpBinding();
                    ////Uri baseAddress = new Uri(Address);
                    ////chatBinding.Port = 0;
                    ////chatBinding.Security.Mode = SecurityMode.None;
                    ////chatBinding.Resolver.Mode = PeerResolverMode.Custom;
                    ////chatBinding.Resolver.Custom.Address = new EndpointAddress(baseAddress);
                    ////chatBinding.Resolver.Custom.Binding = new NetTcpBinding(SecurityMode.None);
                    ////chatBinding.Resolver.Custom.Binding.OpenTimeout = TimeSpan.FromMinutes(5);
                    ////DuplexChannelFactory<IChatChannel> factory = new DuplexChannelFactory<IChatChannel>(instanceContext, chatBinding, "net.p2p://chatMesh/ChatServer");
                    ////channel = factory.CreateChannel();

                    /**/
                    InstanceContext context = new InstanceContext(
                        new ChatClient(txtUserName.Text.Trim()));
                    factory =
                        new DuplexChannelFactory<IChatChannel>(context, "ChatEndPoint");
                    ((System.ServiceModel.NetPeerTcpBinding)(((System.ServiceModel.ChannelFactory)(factory)).Endpoint.Binding)).Resolver.Custom.Address = new EndpointAddress(string.Format("net.tcp://{0}/ChatServer", IPAddress));
                    channel = factory.CreateChannel();
                    /**/

                    IOnlineStatus status = channel.GetProperty<IOnlineStatus>();
                    status.Offline += new EventHandler(Offline);
                    status.Online += new EventHandler(Online);
                    channel.Open();
                    channel.Join(this.userName);
                    grpMessageWindow.Enabled = true;
                    grpUserList.Enabled = true;
                    grpUserCredentials.Enabled = false;
                    this.AcceptButton = btnSend;
                    rtbMessages.AppendText("'''''''''''''''''''''WEL-COME to Chat Application''''''''''''''''''''''\r\n");
                    txtSendMessage.Select();
                    //txtSendMessage.Focus();
                    cmbProject.Focus();

                    CreateComponentTable();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void CreateComponentTable()
        {
            try
            {

                DtTasks = new DataTable();
                DataColumn dt1 = new DataColumn("User", "".GetType());
                dt1.ReadOnly = false;
                DtTasks.Columns.Add(dt1);

                DataColumn dt2 = new DataColumn("Project", "".GetType());
                dt2.ReadOnly = false;
                DtTasks.Columns.Add(dt2);

                DataColumn dt3 = new DataColumn("Tasks", "".GetType());
                dt3.ReadOnly = false;
                DtTasks.Columns.Add(dt3);

                DataColumn dt4 = new DataColumn("IsCompleted", "".GetType());
                dt4.ReadOnly = false;
                DtTasks.Columns.Add(dt4);

                DataColumn dt5 = new DataColumn("ETA", "".GetType());
                dt5.ReadOnly = false;
                DtTasks.Columns.Add(dt5);


                DtTasks.AcceptChanges();

            }
            catch (Exception ex)
            {

            }
        }

        void ChatClient_RemoveUser(string name)
        {
            try
            {
                rtbMessages.AppendText("\r\n");
                rtbMessages.AppendText(name + " left at " + DateTime.Now.ToString());
                lstUsers.Items.Remove(name);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
        }

        void ChatClient_MessageSent(string name, string message)
        {
            if (!lstUsers.Items.Contains(name))
            {
                lstUsers.Items.Add(name);
            }
            rtbMessages.AppendText("\r\n");
            rtbMessages.AppendText(name + " says: " + message);
        }

        void ChatClient_NewJoin(string name)
        {
            rtbMessages.AppendText("\r\n");
            rtbMessages.AppendText(name + " joined at: [" + DateTime.Now.ToString() + "]");
            lstUsers.Items.Add(name);
        }

        void Online(object sender, EventArgs e)
        {
            rtbMessages.AppendText("\r\nOnline: " + this.userName);
        }

        void Offline(object sender, EventArgs e)
        {
            rtbMessages.AppendText("\r\nOffline: " + this.userName);
        }

        #region IChatService Members

        public void Join(string memberName)
        {
            if (NewJoin != null)
            {
                NewJoin(memberName);
            }
        }

        public new void Leave(string memberName)
        {
            if (RemoveUser != null)
            {
                RemoveUser(memberName);
            }
        }

        public void SendMessage(string memberName, string message)
        {
            if (MessageSent != null)
            {
                MessageSent(memberName, message);
            }
        }

        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            channel.SendMessage(this.userName, txtSendMessage.Text.Trim());
            txtSendMessage.Clear();
            txtSendMessage.Select();
            txtSendMessage.Focus();
        }

        private void ChatClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (channel != null)
                {
                    channel.Leave(this.userName);
                    channel.Close();
                }
                if (factory != null)
                {
                    factory.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                //we have to get the index of a last row id:
                int index = dgvTasks.Rows.Count;

                //and count +1 to get a new row id:
                index++;
                this.dgvTasks.Rows.Add();
            }
        }

        private void btnAddnext_Click(object sender, EventArgs e)
        {
            DataRow dr = DtTasks.NewRow();
            dr["User"] = txtUserName.Text;
            dr["Project"] = cmbProject.SelectedText;
            dr["Tasks"] = txtTasks.Text;
            dr["IsCompleted"] = Convert.ToBoolean(chkcompleted.Checked);
            dr["ETA"] = txtDays.Text;

            DtTasks.Rows.Add(dr);
            txtTasks.Clear();
            chkcompleted.Checked = false;
            txtDays.Clear();
            DtTasks.TableName = "Daily_status";
            DtTasks.AcceptChanges();

            //dgvTasks.Rows.Add(dr);

            dgvTasks.DataSource = DtTasks;
            cmbProject.Focus();
        }

        private void chkcompleted_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcompleted.Checked)
            {
                txtDays.Enabled = false;
            }
            else
            {
                txtDays.Enabled = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel.Class1 excl = new ExportToExcel.Class1();
                ExportToExcel.Class1.ReadExistingExcel(DtTasks);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}