namespace MonkeysRope.Interfaces
{
    public interface IRope
    {
        void Run();

        //Direccion GetDireccion(Monkey monkey);

        int GetMaxAllowedAtSameTime();
    }
}
