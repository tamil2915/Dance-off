using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMatcher : MonoBehaviour
{
    float elapsedTime;

    float currentWindowOpenTime;
    float currentWindowCloseTime;

    int currentTileIndex;

    public MusicDataScriptableObject musicObject;

    public int CurrentTileIndex {get {return currentTileIndex; } }

    public TileManager tileManager;
    public InputManager inputManager;
   
    private void Start()
    {
        currentTileIndex = 0;

        RefreshWindowIntervals();

        elapsedTime = 0;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        
        if (CheckInput(inputManager.CurrentKey))
        {
            tileManager.UpdateTile(currentTileIndex-1, TileStates.RIGHT);
        }
        else
        { }
        
        UpdateWindow();
    }

    public bool CheckInput(InputKeyStates key)
    {
        bool retVal = false;

        if (!CheckWindow())
            return false;

        if (!IsValidIndex())
            return false;

        MusicPair pair = musicObject.pairs[currentTileIndex];
        //check input here
        if (key == pair.key)
        {
            retVal = true;
        }
        else
        {
            return false;
        }

        IncrementTileIndex();

        if (!IsValidIndex())
        {
            Debug.Log("gameover");
            return false;
        }

        RefreshWindowIntervals();

        return retVal;
    }

    void RefreshWindowIntervals()
    {
        if (!IsValidIndex())
            return;
        float nextCheckpoint = musicObject.timing[currentTileIndex];

        currentWindowOpenTime = nextCheckpoint - .2f;
        currentWindowCloseTime = nextCheckpoint + .2f;
/*
        Debug.Log("current window open : " + currentWindowOpenTime);
        Debug.Log("current window close : " + currentWindowCloseTime);*/
    }


    bool CheckWindow()
    {
        if (elapsedTime >= currentWindowOpenTime && elapsedTime <= currentWindowCloseTime)
        {
            return true;
        }
        return false;
    }

    void UpdateWindow()
    {
        if (elapsedTime > currentWindowCloseTime && IsValidIndex())
        {
            tileManager.UpdateTile(CurrentTileIndex, TileStates.WRONG);

            IncrementTileIndex();
            RefreshWindowIntervals();

            Debug.Log("update the tile now");
        }
    }

    bool IsValidIndex()
    {
        if (currentTileIndex < musicObject.pairs.Length)
        {
            return true;
        }

        return false;
    }

    void IncrementTileIndex()
    {
        currentTileIndex += 1;
        Debug.Log("tileindex " + currentTileIndex);
    }
}
