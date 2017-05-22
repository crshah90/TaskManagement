using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.PeerResolvers;
using System.Globalization;
using System.Linq;
using System.Configuration;
using System.Data.OleDb;
using System.Net;
using System.ServiceModel.Discovery;


namespace ChatServer
{
    public partial class ChatServer : Form
    {
        private CustomPeerResolverService cprs;
        private ServiceHost host;

        private List<DateTime> PreviousMonthCarryForwardDates = new List<DateTime>();
        private List<DateTime> CurrentMonthDates = new List<DateTime>();
        private DataTable DTHolidayDates = new DataTable();
        
        private DataTable CalendarDT;
        private static DateTime D = DateTime.Today;
        private static string FileName = System.Configuration.ConfigurationManager.AppSettings["ExcelfilePath"].ToString();
        private static string FileExtension = System.Configuration.ConfigurationManager.AppSettings["FilePathExtension"].ToString();
        private static string FilePath = FileName + FileExtension;
        private static string MachineUserName = System.Environment.UserName;
        private string Selectedcellvalue = "";

        private string userName;
        private string IPAddress = "";
        private string strHostName = "";
        //private IChatChannel channel;
        //private DuplexChannelFactory<IChatChannel> factory;

        

        public ChatServer()
        {
            DTHolidayDates.Locale = CultureInfo.InvariantCulture;
            InitializeComponent();
            this.strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(this.strHostName);
            foreach (IPAddress ipAddress in ipEntry.AddressList)
            {
                if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    this.IPAddress = ipAddress.ToString();
                }
            }
            btnStop.Enabled = false;
            timer1.Enabled = true;
            timer1.Interval = 1000;
            LoadYear();
            LoadMonth();
            Calculate(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue));
            ////backgroundWorker1.RunWorkerAsync(1000);
            ////HighLightTodaysDate();
            //Process proc = new Process();
            //proc.StartInfo.FileName = "net.exe";
            //proc.StartInfo.CreateNoWindow = true;
            //proc.StartInfo.Arguments = "view";
            //proc.StartInfo.RedirectStandardOutput = true;
            //proc.StartInfo.UseShellExecute = false;
            //proc.Start();
        }

        public ChatServer(string userName)
        {
            this.userName = userName;
        }

        [ServiceContract(CallbackContract = typeof(IChatService))]
        private interface IChatService
        {
            [OperationContract(IsOneWay = true)]
            void Join(string memberName);
            [OperationContract(IsOneWay = true)]
            void Leave(string memberName);
            [OperationContract(IsOneWay = true)]
            void SendMessage(string memberName, string message);
        }

        private interface IChatChannel : IChatService, IClientChannel
        {
        }

        private void HighLightTodaysDate()
        {

            int New_Month_value = 0;
            int New_year_value = 0;
            string New_date_value = "";
            int Check_FirstDate = 0;
            DateTime CurrentDate = System.DateTime.Today.Date;

            if (Convert.ToString(CurrentDate) != Convert.ToString(New_date_value))
            {
                for (int i = 0; i < gvCalendar.Rows.Count; i++)
                {
                    for (int j = 0; j < gvCalendar.Columns.Count; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            continue;
                        }
                        if (string.IsNullOrEmpty(Convert.ToString(gvCalendar[j, i].Value)))
                        {
                            break;
                        }
                        if (Convert.ToInt16(gvCalendar[j, i].Value, CultureInfo.CurrentCulture) == 1)
                        {
                            Check_FirstDate = 1;
                        }

                        if (Check_FirstDate == 0)
                        {
                            var month = Convert.ToString(Convert.ToInt16(cmbMonth.SelectedValue) == 1 ? 12 : Convert.ToInt16(cmbMonth.SelectedValue) - 1, CultureInfo.InvariantCulture);
                            var year = Convert.ToString(Convert.ToInt16(cmbMonth.SelectedValue) == 1 ? Convert.ToInt16(cmbYear.SelectedValue) - 1 : Convert.ToInt16(cmbYear.SelectedValue));
                            var date = Convert.ToString(Convert.ToInt16(gvCalendar[j, i].Value));
                            D = DateTime.ParseExact(month + "/" + date + "/" + year, "M/d/yyyy", new CultureInfo("en-US"));
                        }
                        else
                        {
                            var month = Convert.ToString(cmbMonth.SelectedValue);
                            var year = Convert.ToString(cmbYear.SelectedValue);
                            var date = gvCalendar[j, i].Value;
                            D = DateTime.ParseExact(month + "/" + date + "/" + year, "M/d/yyyy", new CultureInfo("en-US"));
                        }


                        //DataRow[] dr = DTHolidayDates.Select("Date = '#" + D + "#'");

                        if (CurrentDate == D)
                        {
                            var value = gvCalendar[j, i];
                            gvCalendar[j, i].Selected = true;
                            gvCalendar[j, i].Style.SelectionBackColor = System.Drawing.Color.Teal;
                            gvCalendar[j, i].Style.ForeColor = System.Drawing.Color.White;

                            if (j == 0 || j == 6)
                            {
                                gvCalendar[j, i].Style.ForeColor = System.Drawing.Color.Red;
                            }
                            //gvCalendar[j, i].Style.ForeColor = System.Drawing.Color.Red;

                            New_date_value = Convert.ToString(CurrentDate);
                            continue;

                        }
                    }
                }
            }

        }

        private void LoadMonth()
        {
            cmbMonth.Items.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("Month", "".GetType());
            dt.Columns.Add("MonthValue", "".GetType());

            int j = 12;
            string[] strMonth = new string[12];
            strMonth[0] = "January";
            strMonth[1] = "February";
            strMonth[2] = "March";
            strMonth[3] = "April";
            strMonth[4] = "May";
            strMonth[5] = "June";
            strMonth[6] = "July";
            strMonth[7] = "August";
            strMonth[8] = "September";
            strMonth[9] = "October";
            strMonth[10] = "November";
            strMonth[11] = "December";



            for (int i = 0; i < j; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Month"] = strMonth[i];
                dr["MonthValue"] = (i + 1).ToString();
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            this.cmbMonth.SelectedIndexChanged -= new EventHandler(cmbMonth_SelectedIndexChanged_1);
            cmbMonth.DataSource = dt;
            cmbMonth.DisplayMember = "Month";
            cmbMonth.ValueMember = "MonthValue";
            this.cmbMonth.SelectedIndexChanged += new EventHandler(cmbMonth_SelectedIndexChanged_1);

            //dt.Dispose();
        }

        private void LoadYear()
        {
            cmbYear.Items.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("Year", "".GetType());
            dt.Columns.Add("Value", "".GetType());

            int j = 2030;
            for (int i = 1990; i < j; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Year"] = i.ToString();
                dr["Value"] = i.ToString();
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            this.cmbYear.SelectedIndexChanged -= new EventHandler(cmbYear_SelectedIndexChanged_1);
            cmbYear.DataSource = dt;
            cmbYear.DisplayMember = "Year";
            cmbYear.ValueMember = "Year";
            this.cmbYear.SelectedIndexChanged += new EventHandler(cmbYear_SelectedIndexChanged_1);

            //dt.Dispose();
        }

        private void cmbMonth_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //CalculateDaysIntheMonth();
            Calculate(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue));
        }

        private void cmbYear_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //CalculateDaysIntheMonth();
            Calculate(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue));
        }

        public void Calculate(int year, int month)
        {

            // Current Month Dates
            DateTime date = DateTime.Now;
            for (int i = month; i <= month; i++)
            {
                date = new DateTime(year, i, DateTime.DaysInMonth(year, i), System.Globalization.CultureInfo.CurrentCulture.Calendar);
                while (date.DayOfWeek != DayOfWeek.Thursday)
                {
                    date = date.AddDays(-1);
                }
            }
            date = date.AddDays(-3); // Consider from Monday of the week of last thursday of the Month
            int noofdaysleft = (DateTime.DaysInMonth(year, month) - date.Day) + 1; // No Of Days excluding the last week from monday .i.e from 1 to "date - 1" days
            int noofdaysinthismonth = (date.Day) - 1; // till the monday of this week in which the last thursday falls
            CurrentMonthDates = Enumerable.Range(-noofdaysinthismonth, noofdaysinthismonth).Select(i => date.AddDays(i)).ToList();

            // Previous Month Dates
            // if current month selected is january, then previous month would be December of previous year
            DateTime PreviousMonthdate = DateTime.Now;
            int PreviousMonth = month == 1 ? 12 : month - 1;
            int PreviousYear = month == 1 ? year - 1 : year;

            for (int i = PreviousMonth; i <= PreviousMonth; i++)
            {
                //Get the last date of previous month
                PreviousMonthdate = new DateTime(PreviousYear, i, DateTime.DaysInMonth(PreviousYear, i), System.Globalization.CultureInfo.CurrentCulture.Calendar);
                // Loop from the end of the month to find the date of the last thursday
                while (PreviousMonthdate.DayOfWeek != DayOfWeek.Thursday)
                {
                    PreviousMonthdate = PreviousMonthdate.AddDays(-1);
                }
            }
            int noofdaysleftinpreviousmonth = (DateTime.DaysInMonth(PreviousYear, PreviousMonth) - PreviousMonthdate.Day) + 1;
            int noofdaysinpreviousmonth = PreviousMonthdate.Day - 1;
            PreviousMonthCarryForwardDates = Enumerable.Range(-3, 3 + noofdaysleftinpreviousmonth).Select(i => PreviousMonthdate.AddDays(i)).ToList();

            // Add all the dates in one with the previous one dates in the begining of the list
            PreviousMonthCarryForwardDates.AddRange(CurrentMonthDates);
            //foreach (var item in CurrentMonthDates)
            //{
            //    PreviousMonthCarryForwardDates.Add(item);
            //}

            if (PreviousMonthCarryForwardDates.ToList().Count > 0)
            {
                InitiliazeDT();
                LoadData();
                //HighLightTodaysDate();
            }
        }

        private void LoadData()
        {
            //decimal weekcount = Math.Round(Convert.ToDecimal(PreviousMonthCarryForwardDates.ToList().Count / 7), 0);
            Int32 weekcount = CalculateNoOfWeeks();

            if (CalendarDT.Columns.Count == 7)
            {
                int k = 0;
                for (int i = 1; i <= weekcount; i++)
                {
                    DataRow dr = CalendarDT.NewRow();
                    int weekdayscount = 0;

                    for (int j = k; j <= PreviousMonthCarryForwardDates.ToList().Count - 1; j++)
                    {
                        if (i == 1 && weekdayscount == 0)
                        {
                            dr["Sun"] = "";
                            weekdayscount += 1;
                            //k += 1;
                        }
                        switch (PreviousMonthCarryForwardDates[j].DayOfWeek)
                        {
                            case DayOfWeek.Friday:
                                dr["Fri"] = PreviousMonthCarryForwardDates[j].Day;
                                weekdayscount += 1;
                                k += 1;
                                break;
                            case DayOfWeek.Monday:
                                dr["Mon"] = PreviousMonthCarryForwardDates[j].Day;
                                weekdayscount += 1;
                                k += 1;
                                break;
                            case DayOfWeek.Saturday:
                                dr["Sat"] = PreviousMonthCarryForwardDates[j].Day;
                                weekdayscount += 1;
                                k += 1;
                                break;
                            case DayOfWeek.Sunday:
                                dr["Sun"] = PreviousMonthCarryForwardDates[j].Day;
                                weekdayscount += 1;
                                k += 1;
                                break;
                            case DayOfWeek.Thursday:
                                dr["Thu"] = PreviousMonthCarryForwardDates[j].Day;
                                weekdayscount += 1;
                                k += 1;
                                break;
                            case DayOfWeek.Tuesday:
                                dr["Tue"] = PreviousMonthCarryForwardDates[j].Day;
                                weekdayscount += 1;
                                k += 1;
                                break;
                            case DayOfWeek.Wednesday:
                                dr["Wed"] = PreviousMonthCarryForwardDates[j].Day;
                                weekdayscount += 1;
                                k += 1;
                                break;
                            default:
                                break;
                        }
                        if (weekdayscount % 7 == 0 && weekdayscount != 0)
                        {
                            CalendarDT.Rows.Add(dr);
                            CalendarDT.AcceptChanges();
                            //gvCalendar.Rows.Add(dr);
                            break;
                        }
                        if (i == weekcount)
                        {
                            CalendarDT.Rows.Add(dr);
                            CalendarDT.AcceptChanges();
                            //gvCalendar.Rows.Add(dr);
                            break;
                        }
                    }
                }

                //int t = CalendarDT.Rows.Count;
                gvCalendar.DataSource = CalendarDT;

                CalendarProperties();
                //gvCalendar.Columns[0].CellTemplate.Style.BackColor = System.Drawing.Color.Red;
                CalendarDT.Dispose();

            }

        }

        private void CalendarProperties()
        {

            ReadDatesFromExcel(FilePath, FileExtension, "Yes");

            gvCalendar.AutoGenerateColumns = true;
            gvCalendar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            gvCalendar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            gvCalendar.AllowUserToOrderColumns = false;
            gvCalendar.AllowUserToResizeColumns = false;
            gvCalendar.AutoSize = false;

            gvCalendar.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvCalendar.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvCalendar.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvCalendar.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvCalendar.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvCalendar.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            gvCalendar.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            gvCalendar.Columns[0].CellTemplate.Style.ForeColor = System.Drawing.Color.Red;
            gvCalendar.Columns[6].CellTemplate.Style.ForeColor = System.Drawing.Color.Red;
        }

        private void ReadDatesFromExcel(string filePath, string Extension, string isHDR)
        {
            DTHolidayDates.Clear();
            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
            }
            conStr = String.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            //DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            

            //Read Data from First Sheet
            
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(DTHolidayDates);
            connExcel.Close();

            int Check_FirstDate = 0;
            //List<DateTime> list = DTHolidayDates.AsEnumerable()
            //              .Select(r => r.Field<DateTime>("Date"))
            //              .ToList();
            for (int i = 0; i < gvCalendar.Rows.Count; i++)
            {
                for (int j = 0; j < gvCalendar.Columns.Count; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(gvCalendar[j, i].Value)) )
                    {
                        break;
                    }
                    if (Convert.ToInt16(gvCalendar[j, i].Value) == 1)
                    {
                        Check_FirstDate = 1;
                    }

                    if (Check_FirstDate == 0)
                    {
                        var month = Convert.ToString(Convert.ToInt16(cmbMonth.SelectedValue) == 1 ? 12 : Convert.ToInt16(cmbMonth.SelectedValue) - 1);
                        var year = Convert.ToString(Convert.ToInt16(cmbMonth.SelectedValue) == 1 ? Convert.ToInt16(cmbYear.SelectedValue) - 1 : Convert.ToInt16(cmbYear.SelectedValue));
                        var date = Convert.ToString(Convert.ToInt16(gvCalendar[j, i].Value));
                        D = DateTime.ParseExact(month + "/" + date + "/" + year, "M/d/yyyy", new CultureInfo("en-US"));

                    }
                    else
                    {
                        var month = Convert.ToString(cmbMonth.SelectedValue);
                        var year = Convert.ToString(cmbYear.SelectedValue);
                        var date = gvCalendar[j, i].Value;
                        D = DateTime.ParseExact(month + "/" + date + "/" + year, "M/d/yyyy", new CultureInfo("en-US"));
                    }



                    //DataRow[] dr = DTHolidayDates.Select("Date = '#" + D + "#'");
                    var dr1 = (from p in DTHolidayDates.AsEnumerable()
                               where p.Field<DateTime>("Date") == D
                               select p).FirstOrDefault();
                    if (dr1 != null)
                    {
                        var value = gvCalendar[j, i];
                        var Name = (from p in DTHolidayDates.AsEnumerable()
                                    where p.Field<DateTime>("Date") == D
                                    select p.Field<String>("Name")).FirstOrDefault();
                        //gvCalendar[j, i].Style.BackColor =System.Drawing.Color.Orange;
                        switch (Name)
                        {
                            case "General":
                                gvCalendar[j, i].Style.ForeColor = System.Drawing.Color.Red;
                                break;
                            case "Nilesh":
                                gvCalendar[j, i].Style.ForeColor = lblNilesh.ForeColor;
                                break;
                            case "Reshma":
                                gvCalendar[j, i].Style.ForeColor = lblReshma.ForeColor;
                                break;
                            //case "Prasad":
                            //    gvCalendar[j, i].Style.ForeColor = lblPrasad.ForeColor;
                            //    break;
                            case "Loukik":
                                gvCalendar[j, i].Style.ForeColor = lblLoukik.ForeColor;
                                break;
                            case "Rupali":
                                gvCalendar[j, i].Style.ForeColor = lblRupali.ForeColor;
                                break;
                            case "Mohit":
                                gvCalendar[j, i].Style.ForeColor = lblMohit.ForeColor;
                                break;
                            case "Chintan":
                                gvCalendar[j, i].Style.ForeColor = lblChintan.ForeColor;
                                break;
                            //case "Smita":
                            //    gvCalendar[j, i].Style.ForeColor = lblSmita.ForeColor;
                            //    break;
                            default:
                                break;
                        }
                        if (j == 0 || j == 6)
                        {
                            gvCalendar[j, i].Style.ForeColor = System.Drawing.Color.Red;
                        }
                        //gvCalendar[j, i].Style.ForeColor = System.Drawing.Color.Red;
                        continue;
                    }
                }
            }

            connExcel.Dispose();
            cmdExcel.Dispose();
            oda.Dispose();
        }

        private Int32 CalculateNoOfWeeks()
        {
            Int32 weekcount = 0;
            int mondays = 0;
            int daysThisMonth = PreviousMonthCarryForwardDates.ToList().Count;
            DateTime beginingOfThisMonth = PreviousMonthCarryForwardDates[0];
            for (int i = 0; i <= daysThisMonth - 1; i++)
            {
                if (beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Monday)
                {
                    mondays++;
                }
                if (i == daysThisMonth - 1)
                {
                    if (beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
                    {
                        mondays++;
                    }
                }
            }

            weekcount = mondays;
            return weekcount;
        }

        private void InitiliazeDT()
        {
            CalendarDT = new DataTable();
            CalendarDT.Locale = CultureInfo.InvariantCulture;
            CalendarDT.Columns.Add("Sun", "1".GetType());
            CalendarDT.Columns.Add("Mon", "1".GetType());
            CalendarDT.Columns.Add("Tue", "1".GetType());
            CalendarDT.Columns.Add("Wed", "1".GetType());
            CalendarDT.Columns.Add("Thu", "1".GetType());
            CalendarDT.Columns.Add("Fri", "1".GetType());
            CalendarDT.Columns.Add("Sat", "1".GetType());
            CalendarDT.AcceptChanges();
        }

        private void btnPreviousMonth_Click(object sender, EventArgs e)
        {
            try
            {
                //int selectedvalue = Convert.ToInt32(cmbMonth.SelectedValue);
                int month = Convert.ToInt32(cmbMonth.SelectedValue) == 1 ? 12 : Convert.ToInt32(cmbMonth.SelectedValue) - 1;
                int year = Convert.ToInt32(cmbMonth.SelectedValue) == 1 ? (Convert.ToInt32(cmbYear.SelectedValue) - 1) : Convert.ToInt32(cmbYear.SelectedValue);

                if (year == 1989)
                {
                    MessageBox.Show("Year Cannot Be Less Than 1990", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign, false);
                    return;
                }

                this.cmbMonth.SelectedIndexChanged -= new EventHandler(cmbMonth_SelectedIndexChanged_1);
                cmbMonth.SelectedValue = Convert.ToString(month);
                this.cmbMonth.SelectedIndexChanged += new EventHandler(cmbMonth_SelectedIndexChanged_1);

                this.cmbYear.SelectedIndexChanged -= new EventHandler(cmbYear_SelectedIndexChanged_1);
                cmbYear.SelectedValue = Convert.ToString(year);
                this.cmbYear.SelectedIndexChanged += new EventHandler(cmbYear_SelectedIndexChanged_1);

                Calculate(year, month);
                //HighLightTodaysDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error1", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }


        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            try
            {

                //int selectedvalue = Convert.ToInt32(cmbMonth.SelectedValue);
                int month = Convert.ToInt32(cmbMonth.SelectedValue) == 12 ? 1 : Convert.ToInt32(cmbMonth.SelectedValue) + 1;
                int year = Convert.ToInt32(cmbMonth.SelectedValue) == 12 ? (Convert.ToInt32(cmbYear.SelectedValue) + 1) : Convert.ToInt32(cmbYear.SelectedValue);

                this.cmbMonth.SelectedIndexChanged -= new EventHandler(cmbMonth_SelectedIndexChanged_1);
                cmbMonth.SelectedValue = Convert.ToString(month);
                this.cmbMonth.SelectedIndexChanged += new EventHandler(cmbMonth_SelectedIndexChanged_1);

                this.cmbYear.SelectedIndexChanged -= new EventHandler(cmbYear_SelectedIndexChanged_1);
                cmbYear.SelectedValue = Convert.ToString(year);
                this.cmbYear.SelectedIndexChanged += new EventHandler(cmbYear_SelectedIndexChanged_1);
                Calculate(year, month);
                //HighLightTodaysDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error1", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        private void gvCalendar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        //    string s = e.Value.ToString();
        //    DataRow[] drtempdates;
        //    //drtempdates = DTHolidayDates.Select("Date = '" + e.Value); 
        //    if (e.Value == "")
        //    {

        //    }
        }

        private void gvCalendar_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //int index = e.RowIndex;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Hi");
            //HighLightTodaysDate();
        }

        private void gvCalendar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string Address = string.Format(CultureInfo.InvariantCulture ,"net.tcp://{0}/ChatServer", IPAddress);
                /*
                NetTcpBinding binding = new NetTcpBinding();
                binding.Security.Mode = SecurityMode.None;
                binding.MaxReceivedMessageSize = 1000000;
                binding.OpenTimeout = TimeSpan.FromMinutes(10);
                binding.SendTimeout = TimeSpan.FromMinutes(5);
                binding.ReceiveTimeout = TimeSpan.FromMinutes(5);
                binding.MaxBufferPoolSize = 1000000;
                binding.MaxConnections = 6;
                binding.MaxBufferSize = 1000000;
                binding.ReliableSession.Ordered = false;
                binding.ReliableSession.Enabled = false;
                binding.TransferMode = TransferMode.Streamed;

                System.ServiceModel.PeerResolvers.CustomPeerResolverService crs = new System.ServiceModel.PeerResolvers.CustomPeerResolverService();
                crs.RefreshInterval = TimeSpan.FromSeconds(5);
                crs.ControlShape = true;
                ServiceHost Resolver = new ServiceHost(crs, URiAddress);
                Resolver.AddServiceEndpoint(typeof(System.ServiceModel.PeerResolvers.IPeerResolverContract), new NetTcpBinding(),Address, URiAddress);
                Resolver.OpenTimeout = TimeSpan.FromMinutes(5);
                crs.Open();
                Resolver.Open(TimeSpan.FromDays(100000));
                 */

                cprs = new CustomPeerResolverService();
                cprs.RefreshInterval = TimeSpan.FromSeconds(5);
                host = new ServiceHost(cprs);
                //ServiceDiscoveryBehavior discoveryBehavior = new ServiceDiscoveryBehavior();
                //host.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
                //discoveryBehavior.AnnouncementEndpoints.Add(new UdpAnnouncementEndpoint());
                host.BaseAddresses[0].AbsoluteUri.Replace(host.BaseAddresses[0].AbsoluteUri.ToString(), string.Format("net.tcp://{0}/ChatServer", IPAddress));
                host.Description.Endpoints[0].Address = new EndpointAddress(new Uri(string.Format("net.tcp://{0}/ChatServer", IPAddress)));
                host.Description.Endpoints[0].ListenUri = new Uri(string.Format("net.tcp://{0}/ChatServer", IPAddress));
                //host.Description.Endpoints.Add(new UdpDiscoveryEndpoint());
                cprs.ControlShape = true;
                cprs.Open();
                host.Open(TimeSpan.FromDays(1000000));

                btnStart.Enabled = false;
                btnStop.Enabled = true;
                string Message = "Server started successfully.";
                string date = "";
                date = Convert.ToString(gvCalendar.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) + "-" + cmbMonth.SelectedValue + "-" + cmbYear.SelectedValue;
                
                ChatClient.ChatClient frm = new ChatClient.ChatClient(MachineUserName, date);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }


        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //string date = "", MachineUserName = "";
            //date = Selectedcellvalue;
            //MachineUserName = Environment.UserName;
            //MeridianPeople frm = new MeridianPeople(date, MachineUserName);
            //frm.Show();
        }

        private void gvCalendar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Selectedcellvalue = Convert.ToString(gvCalendar[e.ColumnIndex, e.RowIndex].Value) + "-" + cmbMonth.SelectedValue + "-" + cmbYear.SelectedValue;
        }

        private void gvCalendar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Selectedcellvalue = Convert.ToString(gvCalendar[e.ColumnIndex, e.RowIndex].Value) + "-" + cmbMonth.SelectedValue + "-" + cmbYear.SelectedValue;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                cprs = new CustomPeerResolverService();
                cprs.RefreshInterval = TimeSpan.FromSeconds(5);
                host = new ServiceHost(cprs);
                host.BaseAddresses[0].AbsoluteUri.Replace(host.BaseAddresses[0].AbsoluteUri.ToString(), string.Format("net.tcp://{0}/ChatServer", IPAddress));
                host.Description.Endpoints[0].Address = new EndpointAddress(new Uri(string.Format("net.tcp://{0}/ChatServer", IPAddress)));
                host.Description.Endpoints[0].ListenUri = new Uri(string.Format("net.tcp://{0}/ChatServer", IPAddress));
                cprs.ControlShape = true;
                cprs.Open();
                host.Open(TimeSpan.FromDays(1000000));
                lblMessage.Text = "Server started successfully.";
                ChatClient.ChatClient frm = new ChatClient.ChatClient();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                cprs.Close();
                host.Close();
                lblMessage.Text = "Server stopped successfully.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void ChatServer_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void ChatServer_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, 0);
            //string Address = string.Format("net.tcp://{0}/ChatServer", IPAddress);
            cprs = new CustomPeerResolverService();
            cprs.RefreshInterval = TimeSpan.FromSeconds(5);
            host = new ServiceHost(cprs);
            ServiceDiscoveryBehavior discoveryBehavior = new ServiceDiscoveryBehavior();
            host.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
            discoveryBehavior.AnnouncementEndpoints.Add(new UdpAnnouncementEndpoint());
            host.BaseAddresses[0].AbsoluteUri.Replace(host.BaseAddresses[0].AbsoluteUri.ToString(), string.Format("net.tcp://{0}/ChatServer", IPAddress));
            host.Description.Endpoints[0].Address = new EndpointAddress(new Uri(string.Format("net.tcp://{0}/ChatServer", IPAddress)));
            host.Description.Endpoints[0].ListenUri = new Uri(string.Format("net.tcp://{0}/ChatServer", IPAddress));
            host.Description.Endpoints.Add(new UdpDiscoveryEndpoint());
            cprs.ControlShape = true;
            cprs.Open();
            host.Open(TimeSpan.FromDays(1000000));

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            string Message = "Daily Routine server started successfully.";
            MessageBox.Show(Message);
            //string date = "";
            //date = Convert.ToString(gvCalendar.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) + "-" + cmbMonth.SelectedValue + "-" + cmbYear.SelectedValue;
            //ChatClient.ChatClient frm = new ChatClient.ChatClient(MachineUserName, date);
            //frm.Show();
        }
    }
}