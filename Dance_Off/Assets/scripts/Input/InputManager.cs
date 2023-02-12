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
            if (key == InputKeyStates.NONE || duration == InputDurationStates.NONE)
                return;

            isBusy = true;

            _currentKeyState = key;
            _currentDurationState = duration;
        
            if (inputMatcher.CheckInput(CurrentKey, CurrentDuration)){
                tileManager.UpdateTile(inputMatcher.CurrentTileIndex, TileStates.RIGHT);
            }
            else
            {
                tileManager.UpdateTile(inputMatcher.CurrentTileIndex, TileStates.WRONG);
            }
        }
        else
        {
            if(_currentDurationState == InputDurationStates.LONG_PRESS)
            {
                if (_currentKeyState == key && duration == InputDurationStates.NONE) // long press cancelled
                {
                    ResetKeys();
                }
            }
            if(_currentDurationState == InputDurationStates.TAP)
            {
                if(duration == InputDurationStates.NONE)
                {
                    StartCoroutine(ResetAfterSeconds(.1f));
                }
            }
        }

    }

    private void ResetKeys()
    {
        isBusy = false;

        _currentKeyState = InputKeyStates.NONE;
        _currentDurationState = InputDurationStates.NONE;
    }

    IEnumerator ResetAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ResetKeys();
    }
}
