using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonkeysRope.Classes;
using System.Threading;
using MonkeysRope;
using System.Collections;

namespace UnitTestProjectMonkeys
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OneMonkeyMovingToLeft()
        {
            var monkey = new Monkey() { ID = new Guid(), Side = Direction.Left };

            Rope myClass = new Rope();
            myClass.Monkey = monkey;
            myClass.Run();

            Assert.AreEqual(monkey.Status, "Start,Moving,Finish");

        }
        Rope rope = new Rope();

        void Run(object item)
        {
            rope.Monkey = (Monkey)item;
            rope.Run();
        }

        [TestMethod]
        public void TwoMonkeyMovingAtRightOneAtLeft()
        {
            ArrayList monkeyList = new ArrayList();

            monkeyList.Add(new Monkey() { ID = new Guid(), Side = Direction.Right });
            monkeyList.Add(new Monkey() { ID = new Guid(), Side = Direction.Right });
            monkeyList.Add(new Monkey() { ID = new Guid(), Side = Direction.Left });

            var direcctions = "";
            Direction currentDirection = Direction.Undefined;
            while (true)
            {
                if (monkeyList.Count > 0)
                    currentDirection = rope.GetDirection((Monkey)monkeyList[0]);
                else
                    break;

                direcctions += $"{rope.currentDirection.ToString()},";

                var newList = Utils.GetListOfMonkeysAllowed(monkeyList, currentDirection, rope.GetMaxAllowedAtSameTime());

                foreach (Monkey item in newList)
                {
                    monkeyList.Remove(item);
                    rope.MonkeysInProgress++;
                    var pool = new Thread(new ParameterizedThreadStart(Run))
                    {
                        Name = "Monkey"
                    };
                    pool.Start(item);
                }
            }
            Assert.AreEqual(direcctions, $"{Direction.Right},{Direction.Left},");
        }
    }
}
