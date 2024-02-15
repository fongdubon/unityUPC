using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float startTime;
    [SerializeField]
    private float endTime;
    [SerializeField]
    private float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        WavesManager.instance.AddWave(this);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
    }

   void Spawn()
    {
        GameObject clone = Instantiate(prefab);
        clone.transform.position = transform.position;
        clone.transform.rotation = transform.rotation;
    }
    void EndSpawner()
    {
        WavesManager.instance.RemoveWave(this);
        CancelInvoke();
    }
}
