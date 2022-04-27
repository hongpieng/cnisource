using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Cognex.DataMan.SDK.Discovery;
using Cognex.DataMan.SDK.Utils;
using Cognex.DataMan.SDK;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;


namespace TCP_IP_Test
{

    public partial class Form1 : Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder reVal, int size, string filePath);

        string _strDelayINIpath = Application.StartupPath + @"\Config.ini";
        StringBuilder temp = new StringBuilder(5000);

        private DataManSystem _DMS1 = null;
        private DataManSystem _DMS2 = null;
       
        EthSystemConnector _ethDMS1connect;
        EthSystemConnector _ethDMS2connect;

        string _strDMS1 = "192.168.10.101";//카메라(탑) IP 주소
        string _strDMS2 = "192.168.10.123";//카메라(사이드) IP 주소
        int _intDMS = 23;
        int delayTime = 1000;
        
        string _strUserID = "admin";
        string _strPassword = "";

        public Form1()
        {
            InitializeComponent();
            
        }
        public void WriteLog(string sLog, bool bWriteLog)
        {
            try
            {
                {
                    rtxLog.Text += ("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + sLog + "\r\n");

                    if (bWriteLog) // Text 파일로 저장여부 확인
                    {
                        CNILog.Write("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + sLog + "\r\n");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro!");
            }
        }
        private void bt_connect_Click(object sender, EventArgs e)
        {
            try 
            {
                //카메라(탑) 연결
                _ethDMS1connect = new EthSystemConnector(IPAddress.Parse(_strDMS1), _intDMS);
                _ethDMS1connect.UserName = _strUserID;
                _ethDMS1connect.Password = _strPassword;
                _DMS1 = new DataManSystem(_ethDMS1connect);
                _DMS1.Connect();

                WriteLog("카메라(탑) 연결 완료", false);
                //카메라(사이드) 연결
                _ethDMS2connect = new EthSystemConnector(IPAddress.Parse(_strDMS2), _intDMS);
                _ethDMS2connect.UserName = _strUserID;
                _ethDMS2connect.Password = _strPassword;
                _DMS2 = new DataManSystem(_ethDMS2connect);
                _DMS2.Connect();

                WriteLog("카메라(사이드) 연결 완료", false);

                //MessageBox.Show("Devices Connected!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect: " + ex.ToString());
            }
           

        }

        /************************************삼성******************************************/
        private void btn_sumsung_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //카메라(탑) 트리거 온 및 코드사이즈 설정
                _DMS1.SendCommand("TRIGGER ON");
                _DMS1.SendCommand("SET C39.CODESIZE OFF 16 50");
                WriteLog("카메라(탑)코드 사이즈 변경 완료",true);

                //카메라(사이즈) 트리거 온 및 딜레이 타임 설정
                //_DMS2.SendCommand("TRIGGER ON");
                //_DMS2.SendCommand("SET OUTPUT.DELAY-TIME 1000");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send TRIGGER ON command: " + ex.ToString());
            }
        }

        private void btn_sumsung_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                //카메라 트리거 오프
                _DMS1.SendCommand("TRIGGER OFF");
                _DMS2.SendCommand("TRIGGER OFF");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send TRIGGER OFF command: " + ex.ToString());
            }
        }
        /************************************SK하이닉스******************************************/
        private void btn_sk_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //카메라(탑) 트리거 온 및 코드사이즈 설정
                _DMS1.SendCommand("TRIGGER ON");
                _DMS1.SendCommand("SET C39.CODESIZE OFF 1 16");
               

                Thread.Sleep(delayTime);
                //카메라(사이즈) 트리거 온 및 딜레이 타임 설정
                _DMS2.SendCommand("TRIGGER ON");
                _DMS2.SendCommand("SET OUTPUT.DELAY-TIME 500");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send TRIGGER ON command: " + ex.ToString());
            }
        }

        private void btn_sk_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                //카메라 트리거 오프
                _DMS1.SendCommand("TRIGGER OFF");
                _DMS2.SendCommand("TRIGGER OFF");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send TRIGGER OFF command: " + ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetPrivateProfileString("Setting", "DelayTime", null,temp,5000, _strDelayINIpath);
            delayTime = Int32.Parse(temp.ToString());

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WritePrivateProfileString("Setting", "DelayTime", delayTime.ToString(), _strDelayINIpath);
        }
    }
}
