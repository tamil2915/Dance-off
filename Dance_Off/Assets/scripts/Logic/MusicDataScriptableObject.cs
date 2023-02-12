using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MusicDataScriptableObject", order = 1)]
public class MusicDataScriptableObject : ScriptableObject
{
    public string songName;

    public float[] timing;

    public MusicPair[] pairs;

    public void RandomizeKeys()
    {
        for (int i = 0; i < pairs.Length; i++)
        {
            pairs[i].key = (InputKeyStates)Mathf.FloorToInt(UnityEngine.Random.Range(0, 4));
        }
    }
}

[Serializable]
public struct MusicPair
{
    public InputKeyStates key;
    public InputDurationStates duration;
}