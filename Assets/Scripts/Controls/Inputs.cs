// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/New Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Controls
{
    public class @Inputs : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Inputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""Primary"",
            ""id"": ""b726f0d8-3393-43be-9dd1-f1cad6d777e5"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f0e33ca3-94ae-48ed-aba5-ada4cf3aec3d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""PassThrough"",
                    ""id"": ""25dc5ee7-7fde-42b8-a797-efa2befcd33b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a6678bd0-dbbc-4095-a7e4-8b65cca07d9b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""298899dd-c2b4-4c69-b752-0f9a15553614"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5a386093-cb71-4e1f-90e9-d105648856d4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""79849602-d29a-4244-91e6-b4498bf6f463"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6506da83-f3c1-4ccf-993d-dbf4616365b8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fc5782d1-a8e9-409a-a45a-efa36b437527"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9d1ba8ad-b684-439e-9865-1f2c53610453"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c3b8269-162a-4490-94a0-8793af6a5fca"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Main"",
            ""bindingGroup"": ""Main"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Primary
            m_Primary = asset.FindActionMap("Primary", throwIfNotFound: true);
            m_Primary_Movement = m_Primary.FindAction("Movement", throwIfNotFound: true);
            m_Primary_Fire = m_Primary.FindAction("Fire", throwIfNotFound: true);
            m_Primary_Restart = m_Primary.FindAction("Restart", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Primary
        private readonly InputActionMap m_Primary;
        private IPrimaryActions m_PrimaryActionsCallbackInterface;
        private readonly InputAction m_Primary_Movement;
        private readonly InputAction m_Primary_Fire;
        private readonly InputAction m_Primary_Restart;
        public struct PrimaryActions
        {
            private @Inputs m_Wrapper;
            public PrimaryActions(@Inputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Primary_Movement;
            public InputAction @Fire => m_Wrapper.m_Primary_Fire;
            public InputAction @Restart => m_Wrapper.m_Primary_Restart;
            public InputActionMap Get() { return m_Wrapper.m_Primary; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PrimaryActions set) { return set.Get(); }
            public void SetCallbacks(IPrimaryActions instance)
            {
                if (m_Wrapper.m_PrimaryActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_PrimaryActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_PrimaryActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_PrimaryActionsCallbackInterface.OnMovement;
                    @Fire.started -= m_Wrapper.m_PrimaryActionsCallbackInterface.OnFire;
                    @Fire.performed -= m_Wrapper.m_PrimaryActionsCallbackInterface.OnFire;
                    @Fire.canceled -= m_Wrapper.m_PrimaryActionsCallbackInterface.OnFire;
                    @Restart.started -= m_Wrapper.m_PrimaryActionsCallbackInterface.OnRestart;
                    @Restart.performed -= m_Wrapper.m_PrimaryActionsCallbackInterface.OnRestart;
                    @Restart.canceled -= m_Wrapper.m_PrimaryActionsCallbackInterface.OnRestart;
                }
                m_Wrapper.m_PrimaryActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                    @Restart.started += instance.OnRestart;
                    @Restart.performed += instance.OnRestart;
                    @Restart.canceled += instance.OnRestart;
                }
            }
        }
        public PrimaryActions @Primary => new PrimaryActions(this);
        private int m_MainSchemeIndex = -1;
        public InputControlScheme MainScheme
        {
            get
            {
                if (m_MainSchemeIndex == -1) m_MainSchemeIndex = asset.FindControlSchemeIndex("Main");
                return asset.controlSchemes[m_MainSchemeIndex];
            }
        }
        public interface IPrimaryActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
            void OnRestart(InputAction.CallbackContext context);
        }
    }
}
