using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextboxScript : MonoBehaviour
{
    private SpriteRenderer myImage;
    [SerializeField] private TextMeshProUGUI myText;
    [SerializeField] private AudioSource[] mySpeech = new AudioSource[2];
    [SerializeField] private Sprite[] myIcon;

    // Start is called before the first frame update
    void Start()
    {
        myImage = gameObject.GetComponent<SpriteRenderer>();

        StartCoroutine(writeSpeech("*WASD to move." + "\n Good Luck!", 1,true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show()
    {
        myImage.enabled = true;
    }

    public void hide()
    {
        myImage.enabled = false;
        myText.text = "";
    }

    public void speechStart(string speech, int index, bool isDone)
    {
        StartCoroutine(writeSpeech(speech, index, isDone));
    }

    public IEnumerator writeSpeech(string speech, int index, bool isDone)
    {
        myImage.enabled = true;
        myText.text = "";
        myImage.sprite = myIcon[index];
        Debug.Log(speech);

        for (int i = 0; i <= speech.Length; i++)
        {
            myText.text = speech.Substring(0, i);
            if(index != 0 && i %5 == 0)
            {
                mySpeech[index].Play();
            }
            yield return new WaitForSeconds(0.1f);
        }

        if (isDone)
        {
            yield return new WaitForSeconds(3);
            hide();
        }
    }
}
