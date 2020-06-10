using System;
using System.Collections.Generic;

using RawEngine.Extensions;

namespace RawEngine
{
    public class ComposableDefault : IComposable
    {
        public int CountComponents
        {
            get { return _components.Count; }
        }
        private Dictionary<Type, IComponent> _components;


        public ComposableDefault()
        {
            _components = new Dictionary<Type, IComponent>();
        }
        public ComposableDefault(params IComponent[] startComponents)
            : this()
        {
            AddComponents(startComponents);
        }


        public void AddComponents(params IComponent[] components)
        {
            for (int i = 0; i < components.Length; i++)
                AddComponent(components[i]);
        }
        public void AddComponent<T>() where T : IComponent, new()
        {
            this.AddComponent(new T());
        }
        public void AddComponent(IComponent component)
        {
            if (component is IActivable)
                ((IActivable)component).Enable();

            _components.Add(component.GetType(), component);
        }

        public bool TryGetComponent<T>(out T component) where T : IComponent
        {
            component = default(T);
            if (ContainsComponent<T>() == false)
                return false;

            component = GetComponent<T>();
            return true;
        }
        public bool TryGetComponent(Type type, out IComponent component)
        {
            component = null;
            if (ContainsComponent(type) == false)
                return false;

            component = GetComponent(type);
            return true;
        }

        public IComponent[] GetComponents()
        {
            var componentsBuffer = new IComponent[_components.Count];
            _components.Values.CopyTo(componentsBuffer, 0);

            return componentsBuffer;
        }
        public T[] GetComponents<T>()
        {
            return this.GetImplementations<T>();
        }
        public IComponent[] GetComponents(Type type)
        {
            return this.GetImplementations(type);
        }

        public T GetComponent<T>()
        {
            return (T)GetComponent(typeof(T));
        }
        public IComponent GetComponent(Type type)
        {
            // Interface
            if (type.IsInterface)
                return this.GetImplementation(type);

            // Component
            IComponent component;
            if (_components.TryGetValue(type, out component))
                return component;

            // Sub-Class
            return this.GetImplementation(type);
        }

        public void RemoveComponents()
        {
            this.RemoveComponents(this.GetComponents());
        }
        public void RemoveComponents<T>()
        {
            this.RemoveComponents(typeof(T));
        }
        public void RemoveComponents(Type type)
        {
            this.RemoveComponents(this.GetComponents(type));
        }
        private void RemoveComponents(IComponent[] components)
        {
            for (int i = 0; i < components.Length; i++)
                this.RemoveComponent(components[i]);
        }

        public void RemoveComponent<T>()
        {
            this.RemoveComponent(typeof(T));
        }
        public void RemoveComponent(Type type)
        {
            this.RemoveComponent(GetComponent(type));
        }
        private void RemoveComponent(IComponent component)
        {
            if (component is IActivable)
                ((IActivable)component).Disable();
            if (component is IDestroyable)
                ((IDestroyable)component).Destroy();

            _components.Remove(component.GetType());
        }

        public bool ContainsComponents(params Type[] types)
        {
            for (int i = 0; i < types.Length; i++)
                if (ContainsComponent(types[i]) == false)
                    return false;
            return true;
        }
        public bool ContainsComponent<T>()
        {
            return this.ContainsComponent(typeof(T));
        }
        public bool ContainsComponent(Type type)
        {
            // Interface
            if (type.IsInterface)
                return ContainsImplementation(type);
            // Component
            else if (_components.ContainsKey(type))
                return true;
            // Sub-Class
            else return ContainsImplementation(type);
        }
        

        private bool ContainsImplementation(Type type)
        {
            foreach (var component in _components)
                if (component.Key.IsImplementation(type))
                    return true;
            return false;
        }
        private T[] GetImplementations<T>()
        {
            var implementations = new List<T>();

            foreach (var component in _components)
                if (component.Key.IsImplementation(typeof(T)))
                    implementations.Add((T)component.Value);

            return implementations.ToArray();
        }
        private IComponent[] GetImplementations(Type type)
        {
            var implementations = new List<IComponent>();

            foreach (var component in _components)
                if (component.Key.IsImplementation(type))
                    implementations.Add(component.Value);

            return implementations.ToArray();
        }
        private IComponent GetImplementation(Type type)
        {
            foreach (var component in _components)
                if (component.Key.IsImplementation(type))
                    return component.Value;
            throw new KeyNotFoundException("Interface/Class '" + type.FullName + "' not found");
        }
    }
}