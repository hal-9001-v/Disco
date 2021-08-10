// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/NormalInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NormalInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NormalInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""NormalInput"",
    ""maps"": [
        {
            ""name"": ""Map"",
            ""id"": ""badc2003-a016-4044-8ca3-0fd14fda28a5"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""016fb5c3-9dc2-447c-be48-ce50349fdc12"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""8586698f-4f17-4411-a474-e53207b69c18"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Text"",
                    ""type"": ""Button"",
                    ""id"": ""89bafa49-d1b4-40fb-b1d4-f14f101c04d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b28a4302-86b9-4b29-82c4-387798db5d95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Change Answer"",
                    ""type"": ""Button"",
                    ""id"": ""288dc7c9-2b13-4054-905f-e3b84d195801"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConfirmAnswer"",
                    ""type"": ""Button"",
                    ""id"": ""c8fea6f8-876f-4fce-96c5-04b644bad6df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""384303da-f7b3-4b88-84cf-2603ec98cdad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeCard"",
                    ""type"": ""Value"",
                    ""id"": ""d9bdf408-51dd-45d6-9873-102f86416e7c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConfirmCard"",
                    ""type"": ""Button"",
                    ""id"": ""eaf0dbc0-6cc4-41e2-9ecf-f82ce9b51ff2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e2d10c2c-331e-4c1c-83f5-666f7153c3eb"",
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
                    ""id"": ""0fb2df20-13ff-4d77-95c8-a22014a65231"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2670ad4d-3420-4478-b236-8000d103c89a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""94f1231f-ffaf-477b-b101-f516412d8584"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a366532a-e3d0-41fa-97a9-2fb1b8e49fe5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""69e146ae-d53b-46fb-a424-980a412ae832"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d78b73c2-5aba-42c4-a75f-4843695c28ae"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""312b5810-7044-4a18-b911-2d026030d753"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""77353918-a136-4b8e-8188-f54094487f5e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c1091bea-5565-425b-b67e-4f2325345e4c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3ab97461-0c2c-4349-b558-32c343a79f50"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26a7516c-a376-4128-b105-744a3b578e1d"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Text"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a3e0454-4083-4d31-8ffc-f01e2516e6f8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""949e958a-4e8e-46f9-bec0-eab4135eeeb4"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a3486d5e-91e2-4c31-89b3-ec35963043a4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change Answer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""484602a4-55ad-4400-b4ca-27bd82594528"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Change Answer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""22ee2656-7db5-4b2d-b3de-bf81beb0ff02"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Change Answer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""fdbe7d33-b5c4-49ef-916a-ea393924264c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Change Answer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""88335f54-87ee-40b2-ae96-7a5c2dbf8d8a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Change Answer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6cd82772-a188-411b-93be-2482d211ee41"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Change Answer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7019c9dc-df6c-4031-acf8-c043d4742f2f"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ConfirmAnswer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""842740da-07e4-4d94-9334-8643601046ff"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ConfirmAnswer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a57c851-7d60-48ef-a28d-52de1599dfdf"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ConfirmAnswer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffa11535-b350-45e8-a049-acb23fa405b8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""477df1ff-3751-41b3-99ad-6f6704fad489"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCard"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f3858014-3eee-41ff-85a2-9c857478984d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ChangeCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""85f9f4e8-42e4-4ae9-b305-ad128d48591b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ChangeCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""78197175-86d1-4323-8f53-b5be00e74144"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ChangeCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""50f5b82e-25db-4ac5-9fcf-151c8ea1d1ad"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ChangeCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c31b9d71-c171-4ee3-a793-13d72d35f752"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ChangeCard"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""28900869-f1d3-40a4-b032-ff60862189a7"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ChangeCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9e9b4f6d-a1a1-4d06-830b-46669f2f5568"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ChangeCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5544cce7-6958-451a-9115-7ff06e6949b2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ChangeCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d0d2ce10-e4ca-4c30-840c-404ea8c0a464"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ChangeCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""93b5a45c-c901-416d-968b-c3c4b5ff1ba3"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ConfirmCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5dec7f3-2e76-4c27-93bb-eebda8e07264"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ConfirmCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27034ee0-4462-4c71-9c0f-4e7b4f21e537"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Normal"",
                    ""action"": ""ConfirmCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Normal"",
            ""bindingGroup"": ""Normal"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""bindingGroup"": ""Combat"",
            ""devices"": []
        }
    ]
}");
        // Map
        m_Map = asset.FindActionMap("Map", throwIfNotFound: true);
        m_Map_Movement = m_Map.FindAction("Movement", throwIfNotFound: true);
        m_Map_Interaction = m_Map.FindAction("Interaction", throwIfNotFound: true);
        m_Map_Text = m_Map.FindAction("Text", throwIfNotFound: true);
        m_Map_Pause = m_Map.FindAction("Pause", throwIfNotFound: true);
        m_Map_ChangeAnswer = m_Map.FindAction("Change Answer", throwIfNotFound: true);
        m_Map_ConfirmAnswer = m_Map.FindAction("ConfirmAnswer", throwIfNotFound: true);
        m_Map_Jump = m_Map.FindAction("Jump", throwIfNotFound: true);
        m_Map_ChangeCard = m_Map.FindAction("ChangeCard", throwIfNotFound: true);
        m_Map_ConfirmCard = m_Map.FindAction("ConfirmCard", throwIfNotFound: true);
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

    // Map
    private readonly InputActionMap m_Map;
    private IMapActions m_MapActionsCallbackInterface;
    private readonly InputAction m_Map_Movement;
    private readonly InputAction m_Map_Interaction;
    private readonly InputAction m_Map_Text;
    private readonly InputAction m_Map_Pause;
    private readonly InputAction m_Map_ChangeAnswer;
    private readonly InputAction m_Map_ConfirmAnswer;
    private readonly InputAction m_Map_Jump;
    private readonly InputAction m_Map_ChangeCard;
    private readonly InputAction m_Map_ConfirmCard;
    public struct MapActions
    {
        private @NormalInput m_Wrapper;
        public MapActions(@NormalInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Map_Movement;
        public InputAction @Interaction => m_Wrapper.m_Map_Interaction;
        public InputAction @Text => m_Wrapper.m_Map_Text;
        public InputAction @Pause => m_Wrapper.m_Map_Pause;
        public InputAction @ChangeAnswer => m_Wrapper.m_Map_ChangeAnswer;
        public InputAction @ConfirmAnswer => m_Wrapper.m_Map_ConfirmAnswer;
        public InputAction @Jump => m_Wrapper.m_Map_Jump;
        public InputAction @ChangeCard => m_Wrapper.m_Map_ChangeCard;
        public InputAction @ConfirmCard => m_Wrapper.m_Map_ConfirmCard;
        public InputActionMap Get() { return m_Wrapper.m_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MapActions set) { return set.Get(); }
        public void SetCallbacks(IMapActions instance)
        {
            if (m_Wrapper.m_MapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnMovement;
                @Interaction.started -= m_Wrapper.m_MapActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnInteraction;
                @Text.started -= m_Wrapper.m_MapActionsCallbackInterface.OnText;
                @Text.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnText;
                @Text.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnText;
                @Pause.started -= m_Wrapper.m_MapActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnPause;
                @ChangeAnswer.started -= m_Wrapper.m_MapActionsCallbackInterface.OnChangeAnswer;
                @ChangeAnswer.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnChangeAnswer;
                @ChangeAnswer.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnChangeAnswer;
                @ConfirmAnswer.started -= m_Wrapper.m_MapActionsCallbackInterface.OnConfirmAnswer;
                @ConfirmAnswer.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnConfirmAnswer;
                @ConfirmAnswer.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnConfirmAnswer;
                @Jump.started -= m_Wrapper.m_MapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnJump;
                @ChangeCard.started -= m_Wrapper.m_MapActionsCallbackInterface.OnChangeCard;
                @ChangeCard.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnChangeCard;
                @ChangeCard.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnChangeCard;
                @ConfirmCard.started -= m_Wrapper.m_MapActionsCallbackInterface.OnConfirmCard;
                @ConfirmCard.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnConfirmCard;
                @ConfirmCard.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnConfirmCard;
            }
            m_Wrapper.m_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @Text.started += instance.OnText;
                @Text.performed += instance.OnText;
                @Text.canceled += instance.OnText;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @ChangeAnswer.started += instance.OnChangeAnswer;
                @ChangeAnswer.performed += instance.OnChangeAnswer;
                @ChangeAnswer.canceled += instance.OnChangeAnswer;
                @ConfirmAnswer.started += instance.OnConfirmAnswer;
                @ConfirmAnswer.performed += instance.OnConfirmAnswer;
                @ConfirmAnswer.canceled += instance.OnConfirmAnswer;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ChangeCard.started += instance.OnChangeCard;
                @ChangeCard.performed += instance.OnChangeCard;
                @ChangeCard.canceled += instance.OnChangeCard;
                @ConfirmCard.started += instance.OnConfirmCard;
                @ConfirmCard.performed += instance.OnConfirmCard;
                @ConfirmCard.canceled += instance.OnConfirmCard;
            }
        }
    }
    public MapActions @Map => new MapActions(this);
    private int m_NormalSchemeIndex = -1;
    public InputControlScheme NormalScheme
    {
        get
        {
            if (m_NormalSchemeIndex == -1) m_NormalSchemeIndex = asset.FindControlSchemeIndex("Normal");
            return asset.controlSchemes[m_NormalSchemeIndex];
        }
    }
    private int m_CombatSchemeIndex = -1;
    public InputControlScheme CombatScheme
    {
        get
        {
            if (m_CombatSchemeIndex == -1) m_CombatSchemeIndex = asset.FindControlSchemeIndex("Combat");
            return asset.controlSchemes[m_CombatSchemeIndex];
        }
    }
    public interface IMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnText(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnChangeAnswer(InputAction.CallbackContext context);
        void OnConfirmAnswer(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnChangeCard(InputAction.CallbackContext context);
        void OnConfirmCard(InputAction.CallbackContext context);
    }
}
