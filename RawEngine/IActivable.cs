namespace RawEngine
{
    public interface IActivable
    {
        bool Enabled { get; }

        void Enable();
        void Disable();
    }
}