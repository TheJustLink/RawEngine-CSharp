using System;
using System.Text;

using RawEngine;

namespace RawEngineDebug
{
    class Program
    {
        private static Random _rand = new Random(Guid.NewGuid().GetHashCode());

        private static void Main(string[] args)
        {
            GameObject gameObject = new GameObject(
                new TransformComponent()
            );

            var transform = gameObject.GetComponent<TransformComponent>();
            var whatcomponent = gameObject.GetComponent<IUpdatable>();
            var whatcomponents = gameObject.GetComponents<IUpdatable>();
            var whatcomponents2 = gameObject.GetComponents<IComponent>();

            gameObject.RemoveComponents<IUpdatable>();
            bool hasUpdatable = gameObject.ContainsComponent<IUpdatable>();

            Console.ReadKey(true);
        }

        private static string GetVectorsPrint(params Vector[] vectors)
        {
            var buffer = new StringBuilder();
            buffer.AppendLine(vectors.Length + " vectors : {");
            
            for (int i = 0; i < vectors.Length; i++)
                buffer.AppendLine(vectors[i] + " : SqrtMagnitude = " + vectors[i].SqrtMagnitude);

            buffer.Append("}");
            return buffer.ToString();
        }

        private static Vector[] GetRandomVectors(int count)
        {
            var vectors = new Vector[count];

            for (int i = 0; i < count; i++)
                vectors[i] = GetRandomVector();

            return vectors;
        }
        private static Vector GetRandomVector()
        {
            return new Vector(
                _rand.Next(0, 101),
                _rand.Next(0, 101)
            );
        }
    }
}