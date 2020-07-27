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

namespace CSharpCppDllComm
{
    public partial class Form1 : Form
    {
        private EventWaitHandle MsgEvent = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateCppServer_Click(object sender, EventArgs e)
        {
            NativeMethods.CreateServer();
            MsgEvent = new EventWaitHandle(false, EventResetMode.AutoReset, "MyMsgEventName");
        }

        private void btnSendCppMsg_Click(object sender, EventArgs e)
        {
            NativeMethods.MessageSignal();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MsgEvent == null)
                return;
            if(MsgEvent.WaitOne(0)) // there is message from Cpp server
            {
                // so read it
                txtMsg.Text = NativeMethods.ReadMessage();
            }
        }
    }
}
