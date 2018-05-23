using MonkeysRope.Interfaces;
using System;
using System.Threading;

namespace MonkeysRope.Classes
{
    public class Monkey : IMonkey
    {
        public Direction Side { get; set; }
        public Guid ID { get; set; }
        public string Status { get; set; }

        /// <summary>
        /// Move monkeys
        /// </summary>
        public void MoveForward()
        {
            var to = Side.Equals(Direction.Right) ? Direction.Left : Direction.Right;
            Thread.Sleep(new TimeSpan(0, 0, 1));
            Status = State.Start.ToString() + ",";
            SetTextOnUI($"{Thread.CurrentThread.Name} enters the rope moving to: {to}");
            
            Status += State.Moving.ToString() + ",";
            SetTextOnUI($"{Thread.CurrentThread.Name} 1/4 of the way across the rope");
            SetTextOnUI($"{Thread.CurrentThread.Name} is in the middle of the rope");
            SetTextOnUI($"{Thread.CurrentThread.Name} 3/4 way across the rope");
            SetTextOnUI($"{Thread.CurrentThread.Name} is off the rope." + Environment.NewLine);
            Status += State.Finish.ToString();
            Thread.Sleep(new TimeSpan(0, 0, 3));

        }

        /// <summary>
        /// Send Log/Text to UI
        /// </summary>
        /// <param name="text"></param>
        private void SetTextOnUI(string text)
        {
            if (Program.mainForm != null)
                Program.mainForm.UpdateStatus(text);
        }
    }
}
