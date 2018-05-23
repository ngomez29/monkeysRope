using MonkeysRope.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonkeysRope
{
    public delegate void StringArgReturningVoidDelegate(string text);

    public partial class Form1 : Form
    {
        /// <summary>
        /// Global list of monkeys works as a queue
        /// </summary>
        ArrayList monkeyList = new ArrayList();

        Rope rope = new Rope();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Call rope functionality 
        /// </summary>
        /// <param name="item"></param>
        void Run(object item)
        {
            rope.Monkey = (Monkey)item;
            rope.Run();
        }

        /// <summary>
        /// Update log text on UI
        /// </summary>
        /// <param name="text"></param>
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

        /// <summary>
        /// Starts process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            UpdateStatus("\r\nWaiting Monkeys");
            tStart.Enabled = true;
        }

        /// <summary>
        /// Add Monkey to left side
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            UpdateStatus($"A new Monkey is waiting in line...");

            monkeyList.Add(new Monkey() { ID = new Guid(), Side = Direction.Left });
        }

        /// <summary>
        /// Add Monkey to right side
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            UpdateStatus($"A new Monkey is waiting in line...");

            monkeyList.Add(new Monkey() { ID = new Guid(), Side = Direction.Right });
        }

        /// <summary>
        /// Clear log info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        /// <summary>
        /// Rope logic to handle monkeys threads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tStart_Tick(object sender, EventArgs e)
        {
            Direction currentDirection = Direction.Undefined;

            var newList = new List<Monkey>();

            if (rope.MonkeysInProgress == 0)
            {
                if (monkeyList.Count > 0)
                {
                    currentDirection = rope.GetDirection((Monkey)monkeyList[0]);
                }

                newList = Utils.GetListOfMonkeysAllowed(monkeyList, currentDirection, rope.GetMaxAllowedAtSameTime());

                if (newList.Count != 0)
                {
                    var to = currentDirection.Equals(Direction.Right) ? Direction.Left : Direction.Right;
                    UpdateStatus($"Start to cross the rope from {currentDirection} to {to}" + Environment.NewLine);
                }
            }

            foreach (Monkey item in newList)
            {
                if (rope.MonkeysInProgress < 3 && currentDirection.Equals(item.Side))
                {
                    monkeyList.Remove(item);
                    rope.MonkeysInProgress++;
                    var pool = new Thread(new ParameterizedThreadStart(Run))
                    {
                        Name = "Monkey"
                    };
                    pool.IsBackground = true;
                    pool.Start(item);
                }
            }
        }

        /// <summary>
        /// Stop process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            UpdateStatus("Process has been stopped...");

            tStart.Enabled = false;
        }
    }
}
