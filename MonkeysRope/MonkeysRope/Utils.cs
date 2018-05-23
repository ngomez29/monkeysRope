using MonkeysRope.Classes;
using System.Collections;
using System.Collections.Generic;

namespace MonkeysRope
{
    public static class Utils
    {
        /// <summary>
        /// Get the monkeys that can start to cross the rope on same direction
        /// </summary>
        /// <param name="list"></param>
        /// <param name="currentDirection"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static List<Monkey> GetListOfMonkeysAllowed(ArrayList list, Direction currentDirection, int max)
        {
            List<Monkey> listOfMonkeys = new List<Monkey>();

            int amountOfMonkeysOnRow = 0;
            foreach (Monkey item in list)
            {
                if (amountOfMonkeysOnRow < max)
                {
                    if (item.Side == Direction.Right && currentDirection == Direction.Right)
                    {
                        listOfMonkeys.Add(item);
                        amountOfMonkeysOnRow++;
                    }
                    else if (item.Side == Direction.Left && currentDirection == Direction.Left)
                    {
                        listOfMonkeys.Add(item);
                        amountOfMonkeysOnRow++;
                    }
                }
                else
                {
                    break;
                }
            }
            return listOfMonkeys;
        }
    }
}
