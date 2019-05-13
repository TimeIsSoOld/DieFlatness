using Cognex.VisionPro;
using Cognex.VisionPro.Implementation.Internal;
using Cognex.VisionPro.ToolBlock;
using GeneralComponent;
using SmartRayImageSource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DieFlatness
{
    public partial class Form1 : Form
    {
        GeneralComponent.TcpServer MyTCPServer = null;
        Random rand = new Random();

        List<AuthControlHelper> AuthoritionHelper = new List<AuthControlHelper>();
        enum SensorStatus
        {
            Idle,
            Scaning,
            Aborting

        }
        public Form1()
        {
            InitializeComponent();
        }

        CogToolBlock visionProAlg;
        ImageSource SmartRayImageSource;
        private void button1_Click(object sender, EventArgs e)
        {
            if (MyTCPServer == null)
            {
                MyTCPServer = new TcpServer();
                this.MyTCPServer.Port = 2000;
                this.MyTCPServer.DataType = TcpServer.StreamType.Text;
                this.MyTCPServer.OnConnect += Connection2_OnConnect;
                this.MyTCPServer.OnLeaving += Connection2_OnLeaving;

                MyTCPServer.Open();

            }
            else
            {
       
            }

            SmartRayImageSource.ImageSource srIs = new ImageSource();

            if (srIs.Configure(Application.StartupPath+"/ScanSmartRay_2/SmartRayImageSource.xml"))
            {
                SmartRayImageSource = srIs;

                SmartRayImageSource.OnImage += ImageSource_OnImage;
            }

            if (srIs != null)
            {
                srIs.OnPackageImage += SrIs_OnPackageImage;
            }
            // this.MainDisplay.ColorMapLoad(Application.StartupPath + "/ColorMap.map");


            NotifierHelper.Notify("App.Init.Sucess", "完成初始化。");
           
            //}


            {
                visionProAlg = (CogSerializer.LoadObjectFromFile(Application.StartupPath+"/XXX.vpp") as CogToolBlock);
                visionProAlg.Ran += VisionAlgorithm_OnRan;

            }
            MessageBox.Show("完成初始化");
        }


        public void DisplayResult(object disp)
        {
            CogRecordDisplay Display = disp as CogRecordDisplay;
            CogToolBlock checker = visionProAlg;
            if (Display.InvokeRequired)
            {
                Display.BeginInvoke((Action)delegate
                {
                    DisplayResult(Display, checker);
                });
            }
            else
            {
                DisplayResult(Display, checker);
            }
        }
        private void DisplayResult(CogRecordDisplay Display, CogToolBlock checker)
        {
            if (checker.RunStatus.Result != 0)
            {
                Display.Image = (checker.Outputs["OutputImage"].Value as Cognex.VisionPro.ICogImage);
                Display.Fit(false);
            }
            else
            {
                Cognex.VisionPro.ICogRecord record = checker.CreateLastRunRecord();
                Display.Image = (checker.Outputs["OutputImage"].Value as Cognex.VisionPro.ICogImage);
                Display.Record = record;
                Display.Fit(false);
            }
        }
        private void VisionAlgorithm_OnRan(object sender, EventArgs e)
        {
            DisplayResult(this.MainDisplay);

            if (visionProAlg.RunStatus.Result != CogToolResultConstants.Accept)
            {
                MyTCPServer.Send("NoData");
                objScanState = ScanState.NODATA;
            }
            else
            {

               DealDataSend(visionProAlg);
               
                objScanState = ScanState.SUCCEED;
            }
        }


        private void DealDataSend(CogToolBlock checker)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    DisplayData(checker);

                }));
            }
            else
            {
                DisplayData(checker);
            }


        }
        double Wight;
        private void DisplayData(CogToolBlock checker)
        {
            Wight = Convert.ToDouble(checker.Outputs["Width"].Value);
            label2.Text = Wight.ToString("F2");
        }

        DateTime lastScanTime;
        enum ScanState
        {

            INITIAL,
            OVERTIME,
            AWAIT,
            SCANNING,
            NODATA,
            SUCCEED,
            ERROR
        }
        ScanState objScanState
        {
            get
            {
                return _objScanState;
            }
            set
            {
                if (_objScanState != value)
                {
                    _objScanState = value;
                    NotifierHelper.Notify("ScanState.Changed", _objScanState);
                }
            }
        }
        ScanState _objScanState = ScanState.INITIAL;
        private void SrIs_OnPackageImage(object theImage)
        {
            if (Sr_status == SensorStatus.Idle)
            {
                NotifierHelper.Notify("Sensor.StartScan", "启动扫描。");
                objScanState = ScanState.SCANNING;
                Sr_status = SensorStatus.Scaning;
                lastScanTime = DateTime.Now;

                watchOn = new Thread(SensorWatchOn);
                watchOn.Start();
                //SR_timer.Interval = 8000;
                //SR_timer.Start();
            }
            this.LiveDisplay.Image = theImage as ICogImage;
            LiveDisplay.Fit();
        }

        private void SensorWatchOn()
        {
            NotifierHelper.Notify("Sensor.SensorWatchOn", "扫描监视");
            while (true)
            {
                TimeSpan x = DateTime.Now - lastScanTime;
                if (x.TotalMilliseconds > 6000)
                {
                    if (Sr_status == SensorStatus.Scaning)
                    {
                        NotifierHelper.Notify("Sensor.ScanTimeOut", "扫描超时。");
                        {
                            SmartRayImageSource.Stop();
                            Sr_status = SensorStatus.Aborting;
                            Thread.Sleep(500);
                            SmartRayImageSource.ImageSource srIs = SmartRayImageSource as SmartRayImageSource.ImageSource;
                            srIs.ClearDatas();
                            SmartRayImageSource.SoftTrigger();
                            objScanState = ScanState.OVERTIME;
                            //Connection2.Send("OverTime");
                            NotifierHelper.Notify("ImageSource.SoftTriger");
                        }
                    }
                    break;

                }
                Thread.Sleep(100);
            }
            //watchOn.Abort();

            NotifierHelper.Notify("Sensor.SensorWatchOnStop", "扫描监视结束");

        }
        Thread watchOn;
        SensorStatus Sr_status = SensorStatus.Idle;
        private void ImageSource_OnImage(Object theImage)
        {
            if (watchOn != null)
            {
                watchOn.Abort();
            }

            if (Sr_status == SensorStatus.Aborting)
            {
                SmartRayImageSource.SoftTrigger();
                NotifierHelper.Notify("ImageSource.SoftTriger");
            }
            else

            {
                NotifierHelper.Notify("Sensor.OnImage", "获得图像。");

                object[] imgs = theImage as object[];

                this.LiveDisplay.Image = imgs[0] as ICogImage;
                LiveDisplay.Fit();

                visionProAlg.Inputs["ZMap"] .Value= imgs[0];
                visionProAlg.Inputs["Intensity"].Value = imgs[1];
                visionProAlg.Run();
                //this.VisionProject.VisionAlgorithm.Inputs["ZMap"] = imgs[0];
                //this.VisionProject.VisionAlgorithm.Inputs["Intensity"] = imgs[1];
                //this.VisionProject.VisionAlgorithm.Run();
            }

            Sr_status = SensorStatus.Idle;

        }




        private int client_count = 0;
        private void Connection2_OnConnect(TcpServerConnection connection)
        {
            client_count++;
            NotifierHelper.Notify("Connection.ClientIn");

            //if (client_count > 0)
            {
                UpdateClientStatus();

            }
        }
        private void Connection2_OnLeaving(TcpServerConnection connection)
        {
            client_count--;
            NotifierHelper.Notify("Connection.ClientLeave", "客户端断开。");
            UpdateClientStatus();
        }
        private void UpdateClientStatus()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(
                    () =>
                    {
                        this.cbClient.Checked = (client_count > 0);
                    }
                    ));
            }
            else
            {
                this.cbClient.Checked = client_count > 0;

            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            SmartRayImageSource.SoftTrigger();
            NotifierHelper.Notify("ImageSource.SoftTriger");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CogComponentEditorForm cfgWnd = new CogComponentEditorForm(visionProAlg, false, true);
            cfgWnd.Show();
            cfgWnd.BringToFront();
        }
    }
}
