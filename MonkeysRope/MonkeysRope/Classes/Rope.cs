using MonkeysRope.Interfaces;

namespace MonkeysRope.Classes
{
    public class Rope : IRope
    {
        public Monkey Monkey { get; set; }

        const int MAX_ALLOWED = 3;

        public Direction currentDirection { get; set; }

        public int MonkeysInProgress { get; set; }

        public Rope()
        {

        }

        public void Run()
        {
            Monkey.MoveForward();
            MonkeysInProgress = MonkeysInProgress - 1;
        }

        public int GetMaxAllowedAtSameTime()
        {
            return MAX_ALLOWED;
        }

        public Direction GetDirection(Monkey monkey)
        {
            if (currentDirection == Direction.Undefined)
            {
                currentDirection = monkey.Side;
            }
            else
            {
                currentDirection = currentDirection.Equals(Direction.Right) ? Direction.Left : Direction.Right;
            }
            return currentDirection;
        }
    }

}
