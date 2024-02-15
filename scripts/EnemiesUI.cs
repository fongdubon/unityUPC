using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesUI : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        EnemyManager.instance.onChanged.AddListener(RefreshText);
    }

    private void RefreshText()
    {
        text.text = "Enemigos: " + EnemyManager.instance.enemies.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
