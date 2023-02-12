using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool isBusy = false;

    InputKeyStates _currentKeyState;
    InputDurationStates _currentDurationState;

    public bool IsBusy { get { return isBusy;  } }
    
    public InputKeyStates CurrentKey { get { return _currentKeyState; } }
    public InputDurationStates CurrentDuration { get { return _currentDurationState; } }

    public InputMatcher inputMatcher;
    public TileManager tileManager;

    private void Start()
    {
        _currentKeyState = InputKeyStates.NONE;
        _currentDurationState = InputDurationStates.NONE;
    }

    public void SignalInput(InputKeyStates key, InputDurationStates duration)
    {
        if (!isBusy)
        {
            if (key == InputKeyStates.NONE)
                return;

            isBusy = true;

            _currentKeyState = key;
        }
    }

    public void SignalCancelInput(InputKeyStates key)
    {
        if (key == CurrentKey)
        {
            isBusy = false;
            ResetKeys();
        }
    }

    private void ResetKeys()
    {
        isBusy = false;

        _currentKeyState = InputKeyStates.NONE;
    }
}
