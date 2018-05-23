using MonkeysRope.Interfaces;

namespace MonkeysRope.Classes
{
    public class Rope : IRope
    {
        public Monkey Monkey { get; set; }

        const int MAX_ALLOWED = 3;

        public Direccion currentDirection { get; set; }

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

        public Direccion GetDireccion(Monkey monkey)
        {
            if (currentDirection == Direccion.Undefined)
            {
                currentDirection = monkey.Side;
            }
            else
            {
                currentDirection = currentDirection.Equals(Direccion.Right) ? Direccion.Left : Direccion.Right;
            }
            return currentDirection;
        }
    }

}
