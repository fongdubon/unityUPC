using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesUI : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        WavesManager.instance.onChanged.AddListener(RefreshText);
    }

    private void RefreshText()
    {
        text.text = "Olas: " + WavesManager.instance.waves.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
