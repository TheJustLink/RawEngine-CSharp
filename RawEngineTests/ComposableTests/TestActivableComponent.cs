using RawEngine;

namespace RawEngineTests.ComposableTests
{
    public class TestActivableComponent : IComponent, IActivable
    {
        public bool Enabled { get; private set; }
        
        public void Enable()
        {
            Enabled = true;
        }
        public void Disable()
        {
            Enabled = false;
        }
    }
}