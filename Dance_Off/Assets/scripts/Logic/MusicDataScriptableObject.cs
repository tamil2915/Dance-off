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
}

[Serializable]
public struct MusicPair
{
    public InputKeyStates key;
    public InputDurationStates duration;
}