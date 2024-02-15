using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    [SerializeField]
    private int amount;
    // Start is called before the first frame update
    private void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeath.AddListener(GivePoints);
    }
    private void GivePoints()
    {
        ScoreManager.instance.amount += amount;
    }
}
