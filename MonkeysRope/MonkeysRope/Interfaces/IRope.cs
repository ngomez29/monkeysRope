using MonkeysRope.Classes;

namespace MonkeysRope.Interfaces
{
    public interface IRope
    {
        /// <summary>
        /// Run Rope Logic
        /// </summary>
        void Run();

        /// <summary>
        /// Get monkey direction
        /// </summary>
        /// <param name="monkey"></param>
        /// <returns></returns>
        Direction GetDirection(Monkey monkey);

        /// <summary>
        /// Get Allowed Monkeys Crossing at same time
        /// </summary>
        /// <returns></returns>
        int GetMaxAllowedAtSameTime();
    }

}
