namespace RawEngine
{
    public class GameObject : ComposableDefault
    {
        public GameObject() : base() { }
        public GameObject(params IComponent[] startComponents) : base(startComponents) { }
    }
}