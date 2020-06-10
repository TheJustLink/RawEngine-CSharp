using System;

namespace RawEngine
{
    public interface IComposable
    {
        int CountComponents { get; }


        void AddComponents(params IComponent[] components);
        void AddComponent<T>() where T : IComponent, new();
        void AddComponent(IComponent component);

        bool TryGetComponent<T>(out T component) where T : IComponent;
        bool TryGetComponent(Type type, out IComponent component);

        IComponent[] GetComponents();
        T[] GetComponents<T>();
        IComponent[] GetComponents(Type type);

        T GetComponent<T>();
        IComponent GetComponent(Type type);

        void RemoveComponents();
        void RemoveComponents<T>();
        void RemoveComponents(Type type);

        void RemoveComponent<T>();
        void RemoveComponent(Type type);

        bool ContainsComponents(params Type[] types);
        bool ContainsComponent<T>();
        bool ContainsComponent(Type type);
    }
}