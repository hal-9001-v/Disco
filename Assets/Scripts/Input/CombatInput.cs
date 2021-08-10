// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/CombatInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CombatInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CombatInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CombatInput"",
    ""maps"": [
        {
            ""name"": ""Combat"",
            ""id"": ""bf8a1cc7-76e0-4087-ba1a-4b821c9ccee1"",
            ""actions"": [
                {
                    ""name"": ""RythmUp"",
                    ""type"": ""Button"",
                    ""id"": ""2a50f517-8b9a-46b3-ae4d-208dd1288005"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rhythm Down"",
                    ""type"": ""Button"",
                    ""id"": ""d74c313b-9964-4139-a682-2538c8ca0d28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rhythm Left"",
                    ""type"": ""Button"",
                    ""id"": ""1250b2fa-fdb7-4854-84e3-533c68be3948"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rhythm Right"",
                    ""type"": ""Button"",
                    ""id"": ""57854085-f1e7-4851-bd38-7f175bd78c95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Card Left"",
                    ""type"": ""Button"",
                    ""id"": ""9c0b6255-9738-4183-bbed-a2d5cb8ed8cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Card Right"",
                    ""type"": ""Button"",
                    ""id"": ""01c880ae-3594-444f-a990-dffc42627af7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Card Send"",
                    ""type"": ""Button"",
                    ""id"": ""25468bfd-06d9-42d7-b823-45df41bf2d6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1cc2fc4e-a74a-4c4d-9772-0e64a24c0f51"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""RythmUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07515d63-45e0-49fb-a27a-427d4852e3c8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""RythmUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddee3e83-bc54-4bed-a723-8a2d3572b16e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Rhythm Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfff7883-9db5-462a-97e4-19aeeab159db"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Rhythm Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13ad2d12-08e9-45ca-8da6-af81facf59d3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Rhythm Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba9cc088-9f35-40d7-a55d-9b74f1a7e5ac"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Rhythm Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""836764ed-cc09-4c77-af5c-8b2b381af461"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Card Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed911354-4d50-4fa9-abe5-2521d34bab8a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Card Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3bc9953-0b52-497b-8a94-fb475ea36838"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Card Send"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""CombatScheme"",
            ""bindingGroup"": ""CombatScheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_RythmUp = m_Combat.FindAction("RythmUp", throwIfNotFound: true);
        m_Combat_RhythmDown = m_Combat.FindAction("Rhythm Down", throwIfNotFound: true);
        m_Combat_RhythmLeft = m_Combat.FindAction("Rhythm Left", throwIfNotFound: true);
        m_Combat_RhythmRight = m_Combat.FindAction("Rhythm Right", throwIfNotFound: true);
        m_Combat_CardLeft = m_Combat.FindAction("Card Left", throwIfNotFound: true);
        m_Combat_CardRight = m_Combat.FindAction("Card Right", throwIfNotFound: true);
        m_Combat_CardSend = m_Combat.FindAction("Card Send", throwIfNotFound: true);
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

    // Combat
    private readonly InputActionMap m_Combat;
    private ICombatActions m_CombatActionsCallbackInterface;
    private readonly InputAction m_Combat_RythmUp;
    private readonly InputAction m_Combat_RhythmDown;
    private readonly InputAction m_Combat_RhythmLeft;
    private readonly InputAction m_Combat_RhythmRight;
    private readonly InputAction m_Combat_CardLeft;
    private readonly InputAction m_Combat_CardRight;
    private readonly InputAction m_Combat_CardSend;
    public struct CombatActions
    {
        private @CombatInput m_Wrapper;
        public CombatActions(@CombatInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @RythmUp => m_Wrapper.m_Combat_RythmUp;
        public InputAction @RhythmDown => m_Wrapper.m_Combat_RhythmDown;
        public InputAction @RhythmLeft => m_Wrapper.m_Combat_RhythmLeft;
        public InputAction @RhythmRight => m_Wrapper.m_Combat_RhythmRight;
        public InputAction @CardLeft => m_Wrapper.m_Combat_CardLeft;
        public InputAction @CardRight => m_Wrapper.m_Combat_CardRight;
        public InputAction @CardSend => m_Wrapper.m_Combat_CardSend;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void SetCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterface != null)
            {
                @RythmUp.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnRythmUp;
                @RythmUp.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnRythmUp;
                @RythmUp.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnRythmUp;
                @RhythmDown.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnRhythmDown;
                @RhythmDown.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnRhythmDown;
                @RhythmDown.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnRhythmDown;
                @RhythmLeft.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnRhythmLeft;
                @RhythmLeft.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnRhythmLeft;
                @RhythmLeft.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnRhythmLeft;
                @RhythmRight.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnRhythmRight;
                @RhythmRight.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnRhythmRight;
                @RhythmRight.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnRhythmRight;
                @CardLeft.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnCardLeft;
                @CardLeft.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnCardLeft;
                @CardLeft.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnCardLeft;
                @CardRight.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnCardRight;
                @CardRight.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnCardRight;
                @CardRight.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnCardRight;
                @CardSend.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnCardSend;
                @CardSend.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnCardSend;
                @CardSend.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnCardSend;
            }
            m_Wrapper.m_CombatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RythmUp.started += instance.OnRythmUp;
                @RythmUp.performed += instance.OnRythmUp;
                @RythmUp.canceled += instance.OnRythmUp;
                @RhythmDown.started += instance.OnRhythmDown;
                @RhythmDown.performed += instance.OnRhythmDown;
                @RhythmDown.canceled += instance.OnRhythmDown;
                @RhythmLeft.started += instance.OnRhythmLeft;
                @RhythmLeft.performed += instance.OnRhythmLeft;
                @RhythmLeft.canceled += instance.OnRhythmLeft;
                @RhythmRight.started += instance.OnRhythmRight;
                @RhythmRight.performed += instance.OnRhythmRight;
                @RhythmRight.canceled += instance.OnRhythmRight;
                @CardLeft.started += instance.OnCardLeft;
                @CardLeft.performed += instance.OnCardLeft;
                @CardLeft.canceled += instance.OnCardLeft;
                @CardRight.started += instance.OnCardRight;
                @CardRight.performed += instance.OnCardRight;
                @CardRight.canceled += instance.OnCardRight;
                @CardSend.started += instance.OnCardSend;
                @CardSend.performed += instance.OnCardSend;
                @CardSend.canceled += instance.OnCardSend;
            }
        }
    }
    public CombatActions @Combat => new CombatActions(this);
    private int m_CombatSchemeSchemeIndex = -1;
    public InputControlScheme CombatSchemeScheme
    {
        get
        {
            if (m_CombatSchemeSchemeIndex == -1) m_CombatSchemeSchemeIndex = asset.FindControlSchemeIndex("CombatScheme");
            return asset.controlSchemes[m_CombatSchemeSchemeIndex];
        }
    }
    public interface ICombatActions
    {
        void OnRythmUp(InputAction.CallbackContext context);
        void OnRhythmDown(InputAction.CallbackContext context);
        void OnRhythmLeft(InputAction.CallbackContext context);
        void OnRhythmRight(InputAction.CallbackContext context);
        void OnCardLeft(InputAction.CallbackContext context);
        void OnCardRight(InputAction.CallbackContext context);
        void OnCardSend(InputAction.CallbackContext context);
    }
}
