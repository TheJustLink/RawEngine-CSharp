namespace RawEngine
{
    public class TransformComponent : IComponent, IUpdatable
    {
        public Vector Position { get; set; }

        public TransformComponent() { }
        public TransformComponent(Vector startPosition)
        {
            this.Position = startPosition;
        }


        public void Update()
        {
            System.Console.WriteLine("FAQ");
        }


        public override string ToString()
        {
            return "{ Position : " + Position + " }";
        }
    }
}