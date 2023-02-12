using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMatcher : MonoBehaviour
{
    float elapsedTime;

    float nextWindowOpenTime;
    float nextWindowCloseTime;

    int currentTileIndex;

    public MusicDataScriptableObject musicObject;

    public int CurrentTileIndex {get {return currentTileIndex; } }

    public TileManager tileManager;
    private void Start()
    {
        currentTileIndex = 0;

        RefreshWindowIntervals();

        elapsedTime = 0;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateWindow();
    }

    public bool CheckInput(InputKeyStates key, InputDurationStates duration)
    {
        bool retVal = false;

        if (!CheckWindow())
            return false;

        if (currentTileIndex > musicObject.timing.Length - 1)
            return false;

        MusicPair pair = musicObject.pairs[currentTileIndex];
        //check input here
        if (key == pair.key && duration == pair.duration)
        {
            retVal = true;
        }
        else
        {
            retVal = false;
        }

        currentTileIndex += 1;

        if (currentTileIndex > musicObject.timing.Length)
        {
            Debug.Log("gameover");
            return false;
        }

        RefreshWindowIntervals();

        return retVal;
    }

    void UpdateWindow()
    {
        if (elapsedTime > nextWindowCloseTime)
        {
            tileManager.UpdateTile(CurrentTileIndex, TileStates.WRONG);

            currentTileIndex += 1;
            RefreshWindowIntervals();
        }
    }

    void RefreshWindowIntervals()
    {
        if (currentTileIndex > musicObject.timing.Length - 1)
            return;
        float firstTiming = musicObject.timing[currentTileIndex];

        nextWindowOpenTime = firstTiming - .2f;
        nextWindowCloseTime = firstTiming + .2f;

        Debug.Log(nextWindowOpenTime + " ----- " + nextWindowCloseTime);
    }

    bool CheckWindow()
    {
        if (elapsedTime >= nextWindowOpenTime && elapsedTime <= nextWindowCloseTime)
        {
            return true;
        }
        return false;
    }
}
