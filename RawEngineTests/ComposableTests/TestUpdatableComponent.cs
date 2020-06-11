using RawEngine;

namespace RawEngineTests.ComposableTests
{
    public class TestUpdatableComponent : IComponent, IUpdatable
    {
        public int Counter { get; private set; }

        public void Update()
        {
            Counter++;
        }
    }
}