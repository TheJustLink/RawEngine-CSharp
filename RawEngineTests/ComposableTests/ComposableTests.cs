using Microsoft.VisualStudio.TestTools.UnitTesting;

using RawEngine;

namespace RawEngineTests.ComposableTests
{
    [TestClass]
    public class ComposableTests
    {
        [TestMethod]
        public void Initialization1()
        {
            IComposable container = new ComposableDefault();

            Assert.IsTrue(container.CountComponents == 0);
        }
        [TestMethod]
        public void Initialization2()
        {
            IComposable container = new ComposableDefault(new TestComponent());

            Assert.IsTrue(container.CountComponents == 1);
        }

        [TestMethod]
        public void AddComponent()
        {
            IComposable container = new ComposableDefault();
            container.AddComponent(new TestComponent());

            Assert.IsTrue(container.CountComponents == 1);
        }
        [TestMethod]
        public void AddGenericComponent()
        {
            IComposable container = new ComposableDefault();
            container.AddComponent<TestComponent>();

            Assert.IsTrue(container.CountComponents == 1);
        }
        [TestMethod]
        public void AddComponents()
        {
            IComposable container = new ComposableDefault();
            container.AddComponents(new TestComponent());

            Assert.IsTrue(container.CountComponents == 1);
        }

        [TestMethod]
        public void GetComponent()
        {
            IComponent addedComponent = new TestComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent component = container.GetComponent(typeof(TestComponent));
            Assert.AreEqual(addedComponent, component);
        }
        [TestMethod]
        public void GetComponentInterface1()
        {
            IComponent addedComponent = new TestUpdatableComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent component = container.GetComponent(typeof(IUpdatable));
            Assert.AreEqual(addedComponent, component);
        }
        [TestMethod]
        public void GetComponentInterface2()
        {
            IComponent addedComponent = new TestUpdatableComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent component = container.GetComponent(typeof(IComponent));
            Assert.AreEqual(addedComponent, component);
        }
        [TestMethod]
        public void GetComponentNested()
        {
            IComponent addedComponent = new TestNestedComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent component = container.GetComponent(typeof(TestComponent));
            Assert.AreEqual(addedComponent, component);
        }

        [TestMethod]
        public void GetGenericComponent()
        {
            IComponent addedComponent = new TestComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent component = container.GetComponent<TestComponent>();
            Assert.AreEqual(addedComponent, component);
        }
        [TestMethod]
        public void GetGenericComponentInterface1()
        {
            IComponent addedComponent = new TestUpdatableComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent component = container.GetComponent<IUpdatable>() as IComponent;
            Assert.AreEqual(addedComponent, component);
        }
        [TestMethod]
        public void GetGenericComponentInterface2()
        {
            IComponent addedComponent = new TestUpdatableComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent component = container.GetComponent<IComponent>();
            Assert.AreEqual(addedComponent, component);
        }
        [TestMethod]
        public void GetGenericComponentNested()
        {
            IComponent addedComponent = new TestNestedComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent component = container.GetComponent<TestComponent>();
            Assert.AreEqual(addedComponent, component);
        }

        [TestMethod]
        public void GetComponents1()
        {
            IComponent addedComponent1 = new TestComponent();
            IComponent addedComponent2 = new TestUpdatableComponent();
            IComponent addedComponent3 = new TestNestedComponent();
            IComposable container = new ComposableDefault(
                addedComponent1, addedComponent2, addedComponent3
            );

            IComponent[] components = container.GetComponents();
            Assert.IsTrue(components.Length == 3);
        }
        [TestMethod]
        public void GetComponents2()
        {
            IComponent addedComponent1 = new TestComponent();
            IComponent addedComponent2 = new TestUpdatableComponent();
            IComponent addedComponent3 = new TestNestedComponent();
            IComposable container = new ComposableDefault(
                addedComponent1, addedComponent2, addedComponent3
            );

            IComponent[] components = container.GetComponents(typeof(IComponent));
            Assert.IsTrue(components.Length == 3);
        }
        [TestMethod]
        public void GetComponents3()
        {
            IComponent addedComponent1 = new TestComponent();
            IComponent addedComponent2 = new TestUpdatableComponent();
            IComponent addedComponent3 = new TestNestedComponent();
            IComposable container = new ComposableDefault(
                addedComponent1, addedComponent2, addedComponent3
            );

            IComponent[] components = container.GetComponents(typeof(IUpdatable));
            Assert.IsTrue(components.Length == 1);
            Assert.AreEqual(addedComponent2, components[0]);
        }
        [TestMethod]
        public void GetComponents4()
        {
            IComponent addedComponent1 = new TestComponent();
            IComponent addedComponent2 = new TestUpdatableComponent();
            IComponent addedComponent3 = new TestNestedComponent();
            IComposable container = new ComposableDefault(
                addedComponent1, addedComponent2, addedComponent3
            );

            IComponent[] components = container.GetComponents(typeof(TestComponent));
            Assert.IsTrue(components.Length == 2);
        }
        [TestMethod]
        public void GetComponents5()
        {
            IComponent addedComponent1 = new TestComponent();
            IComponent addedComponent2 = new TestNestedComponent();
            IComposable container = new ComposableDefault(
                addedComponent1, addedComponent2
            );

            IComponent[] components = container.GetComponents(typeof(IUpdatable));
            Assert.IsTrue(components.Length == 0);
        }
        [TestMethod]
        public void GetComponents6()
        {
            IComponent addedComponent = new TestUpdatableComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent[] components = container.GetComponents(typeof(TestComponent));
            Assert.IsTrue(components.Length == 0);
        }

        [TestMethod]
        public void GetGenericComponents1()
        {
            IComponent addedComponent1 = new TestComponent();
            IComponent addedComponent2 = new TestUpdatableComponent();
            IComponent addedComponent3 = new TestNestedComponent();
            IComposable container = new ComposableDefault(
                addedComponent1, addedComponent2, addedComponent3
            );

            IComponent[] components = container.GetComponents<IComponent>();
            Assert.IsTrue(components.Length == 3);
        }
        [TestMethod]
        public void GetGenericComponents2()
        {
            IComponent addedComponent1 = new TestComponent();
            IComponent addedComponent2 = new TestUpdatableComponent();
            IComponent addedComponent3 = new TestNestedComponent();
            IComposable container = new ComposableDefault(
                addedComponent1, addedComponent2, addedComponent3
            );

            IUpdatable[] updatables = container.GetComponents<IUpdatable>();
            Assert.IsTrue(updatables.Length == 1);
            Assert.AreEqual(addedComponent2, updatables[0]);
        }
        [TestMethod]
        public void GetGenericComponents3()
        {
            IComponent addedComponent1 = new TestComponent();
            IComponent addedComponent2 = new TestUpdatableComponent();
            IComponent addedComponent3 = new TestNestedComponent();
            IComposable container = new ComposableDefault(
                addedComponent1, addedComponent2, addedComponent3
            );

            IComponent[] components = container.GetComponents<TestComponent>();
            Assert.IsTrue(components.Length == 2);
        }
        [TestMethod]
        public void GetGenericComponents4()
        {
            IComponent addedComponent1 = new TestComponent();
            IComponent addedComponent2 = new TestNestedComponent();
            IComposable container = new ComposableDefault(
                addedComponent1, addedComponent2
            );

            IUpdatable[] updatables = container.GetComponents<IUpdatable>();
            Assert.IsTrue(updatables.Length == 0);
        }
        [TestMethod]
        public void GetGenericComponents6()
        {
            IComponent addedComponent = new TestUpdatableComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent[] components = container.GetComponents<TestComponent>();
            Assert.IsTrue(components.Length == 0);
        }

        [TestMethod]
        public void TryGetComponent1()
        {
            IComponent addedComponent = new TestComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent component;
            bool result = container.TryGetComponent(typeof(TestComponent), out component);
            Assert.IsTrue(result);
            Assert.IsNotNull(component);
            Assert.AreEqual(addedComponent, component);
        }
        [TestMethod]
        public void TryGetComponent3()
        {
            IComponent addedComponent = new TestUpdatableComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent component;
            bool result = container.TryGetComponent(typeof(TestComponent), out component);
            Assert.IsTrue(result == false);
            Assert.IsNull(component);
        }
        [TestMethod]
        public void TryGetComponentInterface1()
        {
            IComponent addedComponent = new TestUpdatableComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent component;
            bool result = container.TryGetComponent(typeof(IUpdatable), out component);
            Assert.IsTrue(result);
            Assert.IsNotNull(component);
            Assert.AreEqual(addedComponent, component);
        }
        [TestMethod]
        public void TryGetComponentInterface2()
        {
            IComponent addedComponent = new TestComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent component;
            bool result = container.TryGetComponent(typeof(IUpdatable), out component);
            Assert.IsTrue(result == false);
            Assert.IsNull(component);
        }
        [TestMethod]
        public void TryGetComponentInterface3()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            IComponent component;
            bool result = container.TryGetComponent(typeof(IComponent), out component);
            Assert.IsTrue(result);
            Assert.IsNotNull(component);
        }
        [TestMethod]
        public void TryGetComponentNested()
        {
            IComponent addedComponent = new TestNestedComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IComponent component;
            bool result = container.TryGetComponent(typeof(TestComponent), out component);
            Assert.IsTrue(result);
            Assert.IsNotNull(component);
            Assert.AreEqual(addedComponent, component);
        }

        [TestMethod]
        public void TryGetGenericComponent1()
        {
            IComponent addedComponent = new TestComponent();
            IComposable container = new ComposableDefault(addedComponent);

            TestComponent component;
            bool result = container.TryGetComponent<TestComponent>(out component);
            Assert.IsTrue(result);
            Assert.IsNotNull(component);
            Assert.AreEqual(addedComponent, component);
        }
        [TestMethod]
        public void TryGetGenericComponent2()
        {
            IComponent addedComponent = new TestUpdatableComponent();
            IComposable container = new ComposableDefault(addedComponent);

            TestComponent component;
            bool result = container.TryGetComponent<TestComponent>(out component);
            Assert.IsTrue(result == false);
            Assert.IsNull(component);
        }
        [TestMethod]
        public void TryGetGenericComponentInterface1()
        {
            IComponent addedComponent = new TestUpdatableComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IUpdatable updatable;
            bool result = container.TryGetComponent<IUpdatable>(out updatable);
            Assert.IsTrue(result);
            Assert.IsNotNull(updatable);
            Assert.AreEqual(addedComponent, updatable);
        }
        [TestMethod]
        public void TryGetGenericComponentInterface2()
        {
            IComponent addedComponent = new TestComponent();
            IComposable container = new ComposableDefault(addedComponent);

            IUpdatable updatable;
            bool result = container.TryGetComponent<IUpdatable>(out updatable);
            Assert.IsTrue(result == false);
            Assert.IsNull(updatable);
        }
        [TestMethod]
        public void TryGetGenericComponentInterface3()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            IComponent component;
            bool result = container.TryGetComponent<IComponent>(out component);
            Assert.IsTrue(result);
            Assert.IsNotNull(component);
        }
        [TestMethod]
        public void TryGetGenericComponentNested()
        {
            IComponent addedComponent = new TestNestedComponent();
            IComposable container = new ComposableDefault(addedComponent);

            TestComponent component;
            bool result = container.TryGetComponent<TestComponent>(out component);
            Assert.IsTrue(result);
            Assert.IsNotNull(component);
            Assert.AreEqual(addedComponent, component);
        }

        [TestMethod]
        public void RemoveComponent1()
        {
            IComposable container = new ComposableDefault(
                new TestComponent()
            );

            container.RemoveComponent(typeof(TestComponent));
            Assert.IsTrue(container.CountComponents == 0);
        }
        [TestMethod]
        public void RemoveComponent2()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent()
            );

            container.RemoveComponent(typeof(TestComponent));
            Assert.IsTrue(container.CountComponents == 1);
        }
        [TestMethod]
        public void RemoveComponent3()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            // Remove one first component
            container.RemoveComponent(typeof(TestComponent));
            Assert.IsTrue(container.CountComponents == 2);
        }
        [TestMethod]
        public void RemoveComponent4()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestNestedComponent()
            );

            container.RemoveComponent(typeof(IUpdatable));
            Assert.IsTrue(container.CountComponents == 2);
        }
        [TestMethod]
        public void RemoveComponent5()
        {
            IComposable container = new ComposableDefault(
                new TestUpdatableComponent()
            );

            container.RemoveComponent(typeof(TestComponent));
            Assert.IsTrue(container.CountComponents == 1);
        }
        [TestMethod]
        public void RemoveComponentInterface1()
        {
            IComposable container = new ComposableDefault(
                new TestUpdatableComponent()
            );

            container.RemoveComponent(typeof(IUpdatable));
            Assert.IsTrue(container.CountComponents == 0);
        }
        [TestMethod]
        public void RemoveComponentInterface2()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            container.RemoveComponent(typeof(IUpdatable));
            Assert.IsTrue(container.CountComponents == 2);
        }
        [TestMethod]
        public void RemoveComponentInterface3()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            // Remove one first component
            container.RemoveComponent(typeof(IComponent));
            Assert.IsTrue(container.CountComponents == 2);
        }
        [TestMethod]
        public void RemoveComponentInterfaceActivable()
        {
            var component = new TestActivableComponent();
            component.Enable();
            IComposable container = new ComposableDefault(component);

            // Disable in component
            container.RemoveComponent(typeof(IActivable));

            Assert.IsTrue(container.CountComponents == 0);
            Assert.IsTrue(component.Enabled == false);
        }
        [TestMethod]
        public void RemoveComponentInterfaceDestroyable()
        {
            var component = new TestDestroyableComponent();
            IComposable container = new ComposableDefault(component);

            // Disable in component
            container.RemoveComponent(typeof(IDestroyable));

            Assert.IsTrue(container.CountComponents == 0);
            Assert.IsTrue(component.Destroyed);
        }
        [TestMethod]
        public void RemoveComponentNested1()
        {
            IComposable container = new ComposableDefault(
                new TestNestedComponent()
            );

            container.RemoveComponent(typeof(TestComponent));
            Assert.IsTrue(container.CountComponents == 0);
        }
        [TestMethod]
        public void RemoveComponentNested2()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            // Remove one first component
            container.RemoveComponent(typeof(TestComponent));
            Assert.IsTrue(container.CountComponents == 2);
        }

        [TestMethod]
        public void RemoveGenericComponent1()
        {
            IComposable container = new ComposableDefault(
                new TestComponent()
            );

            container.RemoveComponent<TestComponent>();
            Assert.IsTrue(container.CountComponents == 0);
        }
        [TestMethod]
        public void RemoveGenericComponent2()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent()
            );

            container.RemoveComponent<TestComponent>();
            Assert.IsTrue(container.CountComponents == 1);
        }
        [TestMethod]
        public void RemoveGenericComponent3()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            // Remove one first component
            container.RemoveComponent<TestComponent>();
            Assert.IsTrue(container.CountComponents == 2);
        }
        [TestMethod]
        public void RemoveGenericComponent4()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestNestedComponent()
            );

            container.RemoveComponent<IUpdatable>();
            Assert.IsTrue(container.CountComponents == 2);
        }
        [TestMethod]
        public void RemoveGenericComponent5()
        {
            IComposable container = new ComposableDefault(
                new TestUpdatableComponent()
            );

            container.RemoveComponent<TestComponent>();
            Assert.IsTrue(container.CountComponents == 1);
        }
        [TestMethod]
        public void RemoveGenericComponentInterface1()
        {
            IComposable container = new ComposableDefault(
                new TestUpdatableComponent()
            );

            container.RemoveComponent<IUpdatable>();
            Assert.IsTrue(container.CountComponents == 0);
        }
        [TestMethod]
        public void RemoveGenericComponentInterface2()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            container.RemoveComponent<IUpdatable>();
            Assert.IsTrue(container.CountComponents == 2);
        }
        [TestMethod]
        public void RemoveGenericComponentInterface3()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            // Remove one first component
            container.RemoveComponent<IComponent>();
            Assert.IsTrue(container.CountComponents == 2);
        }
        [TestMethod]
        public void RemoveGenericComponentInterfaceActivable()
        {
            var component = new TestActivableComponent();
            component.Enable();
            IComposable container = new ComposableDefault(component);

            // Disable in component
            container.RemoveComponent<IActivable>();

            Assert.IsTrue(container.CountComponents == 0);
            Assert.IsTrue(component.Enabled == false);
        }
        [TestMethod]
        public void RemoveGenericComponentInterfaceDestroyable()
        {
            var component = new TestDestroyableComponent();
            IComposable container = new ComposableDefault(component);

            // Disable in component
            container.RemoveComponent<IDestroyable>();

            Assert.IsTrue(container.CountComponents == 0);
            Assert.IsTrue(component.Destroyed);
        }
        [TestMethod]
        public void RemoveGenericComponentNested1()
        {
            IComposable container = new ComposableDefault(
                new TestNestedComponent()
            );

            container.RemoveComponent<TestComponent>();
            Assert.IsTrue(container.CountComponents == 0);
        }
        [TestMethod]
        public void RemoveGenericComponentNested2()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            // Remove one first component
            container.RemoveComponent<TestComponent>();
            Assert.IsTrue(container.CountComponents == 2);
        }

        [TestMethod]
        public void RemoveComponents1()
        {
            IComposable container = new ComposableDefault(
                new TestComponent()
            );

            container.RemoveComponents(typeof(TestComponent));
            Assert.IsTrue(container.CountComponents == 0);
        }
        [TestMethod]
        public void RemoveComponents2()
        {
            IComposable container = new ComposableDefault();

            container.RemoveComponents(typeof(TestComponent));
            Assert.IsTrue(container.CountComponents == 0);
        }
        [TestMethod]
        public void RemoveComponentsInterface1()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            container.RemoveComponents(typeof(IUpdatable));
            Assert.IsTrue(container.CountComponents == 2);
        }
        [TestMethod]
        public void RemoveComponentsInterface2()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            container.RemoveComponents(typeof(IComponent));
            Assert.IsTrue(container.CountComponents == 0);
        }
        [TestMethod]
        public void RemoveComponentsNested()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            container.RemoveComponents(typeof(TestComponent));
            Assert.IsTrue(container.CountComponents == 1);
        }

        [TestMethod]
        public void RemoveGenericComponents1()
        {
            IComposable container = new ComposableDefault(
                new TestComponent()
            );

            container.RemoveComponents<TestComponent>();
            Assert.IsTrue(container.CountComponents == 0);
        }
        [TestMethod]
        public void RemoveGenericComponents2()
        {
            IComposable container = new ComposableDefault();

            container.RemoveComponents<TestComponent>();
            Assert.IsTrue(container.CountComponents == 0);
        }
        [TestMethod]
        public void RemoveGenericComponentsInterface1()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            container.RemoveComponents<IUpdatable>();
            Assert.IsTrue(container.CountComponents == 2);
        }
        [TestMethod]
        public void RemoveGenericComponentsInterface2()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            container.RemoveComponents<IComponent>();
            Assert.IsTrue(container.CountComponents == 0);
        }
        [TestMethod]
        public void RemoveGenericComponentsNested()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent()
            );

            container.RemoveComponents<TestComponent>();
            Assert.IsTrue(container.CountComponents == 1);
        }

        [TestMethod]
        public void RemoveComponents()
        {
            var activableComponent = new TestActivableComponent();
            activableComponent.Enable();
            var destroyableComponent = new TestDestroyableComponent();

            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent(),
                new TestNestedComponent(),
                activableComponent,
                destroyableComponent
            );

            container.RemoveComponents();
            Assert.IsTrue(container.CountComponents == 0);
            Assert.IsTrue(activableComponent.Enabled == false);
            Assert.IsTrue(destroyableComponent.Destroyed);
        }

        [TestMethod]
        public void ContainsComponent1()
        {
            IComposable container = new ComposableDefault(
                new TestComponent()
            );

            bool result = container.ContainsComponent(typeof(TestComponent));
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ContainsComponent2()
        {
            IComposable container = new ComposableDefault(
                new TestUpdatableComponent()
            );

            bool result = container.ContainsComponent(typeof(TestComponent));
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void ContainsComponentInterface1()
        {
            IComposable container = new ComposableDefault(
                new TestUpdatableComponent()
            );

            bool result = container.ContainsComponent(typeof(IUpdatable));
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ContainsComponentInterface2()
        {
            IComposable container = new ComposableDefault(
                new TestComponent()
            );

            bool result = container.ContainsComponent(typeof(IUpdatable));
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void ContainsComponentInterface3()
        {
            IComposable container = new ComposableDefault(
                new TestComponent()
            );

            bool result = container.ContainsComponent(typeof(IComponent));
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ContainsComponentNested()
        {
            IComposable container = new ComposableDefault(
                new TestNestedComponent()
            );

            bool result = container.ContainsComponent(typeof(TestComponent));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsGenericComponent1()
        {
            IComposable container = new ComposableDefault(
                new TestComponent()
            );

            bool result = container.ContainsComponent<TestComponent>();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ContainsGenericComponent2()
        {
            IComposable container = new ComposableDefault(
                new TestUpdatableComponent()
            );

            bool result = container.ContainsComponent<TestComponent>();
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void ContainsGenericComponentInterface1()
        {
            IComposable container = new ComposableDefault(
                new TestUpdatableComponent()
            );

            bool result = container.ContainsComponent<IUpdatable>();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ContainsGenericComponentInterface2()
        {
            IComposable container = new ComposableDefault(
                new TestComponent()
            );

            bool result = container.ContainsComponent<IUpdatable>();
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void ContainsGenericComponentInterface3()
        {
            IComposable container = new ComposableDefault(
                new TestComponent()
            );

            bool result = container.ContainsComponent<IComponent>();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ContainsGenericComponentNested()
        {
            IComposable container = new ComposableDefault(
                new TestNestedComponent()
            );

            bool result = container.ContainsComponent<TestComponent>();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsComponents1()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestUpdatableComponent()
            );

            bool result = container.ContainsComponents(typeof(TestComponent), typeof(TestUpdatableComponent));
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ContainsComponents2()
        {
            IComposable container = new ComposableDefault(
                new TestComponent(),
                new TestNestedComponent()
            );

            bool result = container.ContainsComponents(typeof(TestComponent), typeof(TestUpdatableComponent));
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void ContainsComponents3()
        {
            IComposable container = new ComposableDefault(
                new TestComponent()
            );

            bool result = container.ContainsComponents(typeof(IComponent), typeof(TestUpdatableComponent));
            Assert.IsTrue(result == false);
        }
    }
}