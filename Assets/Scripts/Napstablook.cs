using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Napstablook : MonoBehaviour
{
    [SerializeField] private Sprite[] mySprite;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = mySprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeHat()
    {
        GetComponent<SpriteRenderer>().sprite = mySprite[1];
    }
}
