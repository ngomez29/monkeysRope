using MonkeysRope.Interfaces;
using System;
using System.Threading;

namespace MonkeysRope.Classes
{
    public class Monkey : IMonkey
    {
        public Direccion Side { get; set; }
        public Guid ID { get; set; }
        public string Status { get; set; }

        /// <summary>
        /// Move monkeys
        /// </summary>
        public void MoveForward()
        {
            var to = Side.Equals(Direccion.Right) ? Direccion.Left : Direccion.Right;

            Status = State.Start.ToString() + ",";
            SetTextOnUI($"{Thread.CurrentThread.Name} enters the rope moving to: {to}");
            Thread.Sleep(new TimeSpan(0, 0, 1));

            Status += State.Moving.ToString() + ",";
            SetTextOnUI($"{Thread.CurrentThread.Name} 1/4 of the way across the rope");
            Thread.Sleep(new TimeSpan(0, 0, 1));

            SetTextOnUI($"{Thread.CurrentThread.Name} is in the middle of the rope");
            Thread.Sleep(new TimeSpan(0, 0, 1));

            SetTextOnUI($"{Thread.CurrentThread.Name} 3/4 way across the rope");
            Thread.Sleep(new TimeSpan(0, 0, 1));

            Status += State.Finish.ToString();
            SetTextOnUI($"{Thread.CurrentThread.Name} is off the rope." + Environment.NewLine);

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
