using MonkeysRope.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonkeysRope
{
    public delegate void StringArgReturningVoidDelegate(string text);

    public partial class Form1 : Form
    {
        ArrayList monkeyList = new ArrayList();

        Rope rope = new Rope();

        public Form1()
        {
            InitializeComponent();
        }

        void Run(object item)
        {
            rope.Monkey = (Monkey)item;
            rope.Run();
        }

        public void UpdateStatus(string text)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringArgReturningVoidDelegate(UpdateStatus), new object[] { text });
                return;
            }
            // Must be on the UI thread if we've got this far
            txtLog.AppendText(text + Environment.NewLine);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            UpdateStatus("\r\nWaiting Monkeys");
            bw.RunWorkerAsync();
        }
    }
}
