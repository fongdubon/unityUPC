using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBulletsUI : MonoBehaviour
{
    Text text;

    [SerializeField]
    private PlayerShooting targetShooting;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "bullets: " + targetShooting.bulletsAmount;
    }
}
