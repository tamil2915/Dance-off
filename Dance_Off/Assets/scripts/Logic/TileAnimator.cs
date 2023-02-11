using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAnimator : MonoBehaviour
{
    public float speed = 1f;

    public Transform tilesParent;

    private void Update()
    {
        Vector3 newPos = tilesParent.position;
        newPos.x += speed * 10 * Time.deltaTime;

        tilesParent.position = newPos;
    }
}
