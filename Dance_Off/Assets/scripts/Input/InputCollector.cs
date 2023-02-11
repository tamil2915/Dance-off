using UnityEngine;
using UnityEngine.InputSystem;

public class InputCollector : MonoBehaviour
{
    private ControlInput inputControls;

    public InputManager inputManager;

    private void OnEnable()
    {
        inputControls.Enable();
    }

    private void OnDisable()
    {
        inputControls.Disable();
    }

    private void Awake()
    {
        inputControls = new ControlInput();

        //for a key
        inputControls.InputStreamActionMap.aKeyShortPress.performed += ctx => ShortPress(InputKeyStates.A);
        
        inputControls.InputStreamActionMap.aKeyLongPress.performed += ctx => LongPress(InputKeyStates.A);
        inputControls.InputStreamActionMap.aKeyLongPress.canceled += ctx => LongPressEnded(InputKeyStates.A);
        
        //for d key
        inputControls.InputStreamActionMap.dKeyShortPress.performed += ctx => ShortPress(InputKeyStates.D);
                                  
        inputControls.InputStreamActionMap.dKeyLongPress.performed += ctx => LongPress(InputKeyStates.D);
        inputControls.InputStreamActionMap.dKeyLongPress.canceled += ctx => LongPressEnded(InputKeyStates.D);

        //for left arrow
        inputControls.InputStreamActionMap.leftArrowShortPress.performed += ctx => ShortPress(InputKeyStates.LEFT_ARROW);
        inputControls.InputStreamActionMap.leftArrowLongPress.performed += ctx => LongPress(InputKeyStates.LEFT_ARROW);
        inputControls.InputStreamActionMap.leftArrowLongPress.canceled += ctx => LongPressEnded(InputKeyStates.LEFT_ARROW);

        //for right arrow
        inputControls.InputStreamActionMap.rightArrowShortPress.performed += ctx => ShortPress(InputKeyStates.RIGHT_ARROW);
        inputControls.InputStreamActionMap.rightArrowLongPress.performed += ctx => LongPress(InputKeyStates.RIGHT_ARROW);
        inputControls.InputStreamActionMap.rightArrowLongPress.canceled += ctx => LongPressEnded(InputKeyStates.RIGHT_ARROW);
    }

    void ShortPress(InputKeyStates key)
    {
        inputManager.SignalInput(key, InputDurationStates.TAP);
    }

    void LongPress(InputKeyStates key) 
    {
        inputManager.SignalInput(key, InputDurationStates.LONG_PRESS);
    }

    void LongPressEnded(InputKeyStates key)
    {
        inputManager.SignalInput(key, InputDurationStates.NONE);
    }
}
