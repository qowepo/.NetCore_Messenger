using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyMessanger;

namespace WinFormsClient
{
    public partial class NikitaGram : Form
    {
        private static int MessageID;
        private static string UserName;
        private static MessangerClientAPI API = new MessangerClientAPI();
        public NikitaGram()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var getMessage = new Func<Task>(async () =>
            {
                Messange msg = await API.GetMessageHTTPAsync(MessageID);
                while (msg != null)
                {
                    lbxChat.Items.Add(msg);
                    MessageID++;
                    msg = await API.GetMessageHTTPAsync(MessageID);
                }
            });
            getMessage.Invoke();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            UserName = tbxUserName.Text;
            string Messange = tbxUserMessange.Text;
            if ((UserName.Length > 1) && (UserName.Length > 1))
            {
                Messange msg = new Messange(UserName, Messange, DateTime.Now);
                API.SendMessange(msg);
                
            }
        }
    }
}
