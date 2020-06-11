using RawEngine;

namespace RawEngineTests.ComposableTests
{
    public class TestDestroyableComponent : IComponent, IDestroyable
    {
        public bool Destroyed { get; private set; }

        public void Destroy()
        {
            Destroyed = true;
        }
    }
}