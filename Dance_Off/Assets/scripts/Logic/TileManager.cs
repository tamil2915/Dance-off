using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public void UpdateTile(int index, TileStates tileState)
    {   
        if (index > transform.childCount - 1)
            return;

        // get the child of transform
        LetterTiles tile = transform.GetChild(index).GetComponent<LetterTiles>();

        if(tile)
        {
            tile.SetState(tileState);
        }
    }
}
