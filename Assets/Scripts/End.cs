using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject canada;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        canada.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void undertale()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().enabled = true;
        canada.SetActive(true);
    }
}
