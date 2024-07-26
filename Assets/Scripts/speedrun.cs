using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class speedrun : MonoBehaviour
{
    private TextMeshProUGUI myText;
    private int seconds = 0;
    private int minutes = 0;
    private bool stillGoing = true;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
        myText.text = "0:00";
        StartCoroutine("count");
    }

    // Update is called once per frame
    void Update()
    {
        if (seconds > 59)
        {
            seconds = 0;
            minutes++;
        }

        if(seconds < 10)
        {
            myText.text = minutes + ":0" + seconds;
        }
        else
        {
            myText.text = minutes + ":" + seconds;
        }
        
    }

    public void stop()
    {
        stillGoing = false;
    }

    IEnumerator count()
    {
        while (stillGoing)
        {
            yield return new WaitForSeconds(1f);
            seconds++;
        }
    }
}
