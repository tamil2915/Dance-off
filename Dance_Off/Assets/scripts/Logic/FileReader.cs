using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileReader : MonoBehaviour
{
    public MusicDataScriptableObject scriptableObj;

    // Start is called before the first frame update
    void Start()
    {
        string path = "./assets/fileinput/inp.csv";
        string fileData  = System.IO.File.ReadAllText(path);
        string[] lines  = fileData.Split("\n"[0]);
        
        MusicPair[] musicArray = new MusicPair[lines.Length];
        float[] timings = new float[lines.Length];
        
        for(int i = 0; i < lines.Length; i++)
        {
            string[] lineData = (lines[i].Trim()).Split(","[0]);

            float x;

            float.TryParse(lineData[0], out x);
            timings[i] = x;

            int y;
            int.TryParse(lineData[1], out y);
            musicArray[i].key = (InputKeyStates)y;

            int.TryParse(lineData[2], out y);
            musicArray[i].duration = (InputDurationStates)y;
        }

        scriptableObj.pairs = musicArray;
        scriptableObj.timing = timings;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
