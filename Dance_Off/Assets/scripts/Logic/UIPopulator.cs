using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopulator : MonoBehaviour
{
    public MusicDataScriptableObject musicalObject;
    public Transform parentTransform;

    public GameObject aShortPrefab;
    public GameObject aLongPrefab;
    public GameObject dShortPrefab;
    public GameObject dLongPrefab;
    public GameObject leftShortPrefab;
    public GameObject leftLongPrefab;
    public GameObject rightShortPrefab;
    public GameObject rightLongPrefab;

    Vector3 startingPosition = Vector3.zero;

    bool isFirstTime = true;

    TileType previousTileType;

    public TileAnimator tileAnimator;

    private void Start()
    {
        startingPosition = parentTransform.position;
        PopulateUI();
    }

    void PopulateUI()
    {
        // read from the musical object
        for (int i = 0; i < musicalObject.pairs.Length; i++)
        {
            AddImageToList(GetMusicTile(musicalObject.pairs[i].key, musicalObject.pairs[i].duration), musicalObject.timing[i]);
        }
    }

    void AddImageToList(GameObject prefab, float positionInSeconds)
    {

        //calculate position by using time and speed
        Vector3 pos = startingPosition;

        pos.x -= positionInSeconds * tileAnimator.speed * 10;

        GameObject obj = Instantiate(prefab, pos, Quaternion.identity, parentTransform);

        /*//read musicalObject and create corresponding prefab instances

        LetterTiles tile = obj.GetComponent<LetterTiles>();

        float biasValue = 0f;

        if(isFirstTime)
        {
            previousTileType = tile.tileType;
            isFirstTime = false;
            obj.transform.position = previousSpawnedPosition;

            return;
        }
        
        if (previousTileType == TileType.SHORT && tile.tileType == TileType.SHORT) {
            biasValue = 150f;
        }
        else if (previousTileType == TileType.SHORT && tile.tileType == TileType.LONG) {
            biasValue = 210f;
        }
        else if (previousTileType == TileType.LONG && tile.tileType == TileType.SHORT) {
            biasValue = 210f;
        }

        else if (previousTileType == TileType.LONG && tile.tileType == TileType.LONG) {
            biasValue = 270f;
        }

        Debug.Log(biasValue);
        previousSpawnedPosition.x -= biasValue;
        previousTileType = tile.tileType;
        obj.transform.position = previousSpawnedPosition;*/
    }

    GameObject GetMusicTile(InputKeyStates key, InputDurationStates duration)
    {
        if (key == InputKeyStates.A)
        {
            if (duration == InputDurationStates.TAP)
                return aShortPrefab;
            else
                return aLongPrefab;
        }
        if (key == InputKeyStates.D)
        {
            if (duration == InputDurationStates.TAP)
                return dShortPrefab;
            else
                return dLongPrefab;
        }
        if (key == InputKeyStates.LEFT_ARROW)
        {
            if (duration == InputDurationStates.TAP)
                return leftShortPrefab;
            else
                return leftLongPrefab;
        }
        if (key == InputKeyStates.RIGHT_ARROW)
        {
            if (duration == InputDurationStates.TAP)
                return rightShortPrefab;
            else
                return rightLongPrefab;
        }
        return null;
    }
}
