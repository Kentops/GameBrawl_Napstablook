using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSGFlipper : MonoBehaviour
{
    [SerializeField] private BoxCollider2D[] events;
    [SerializeField] private TextboxScript textBox;
    [SerializeField] private Napstablook ghosty;
    [SerializeField] private TheHat partyHat;
    [SerializeField] private End theEnd;
    [SerializeField] private speedrun dream;
    private BSGmovement bigGuy;
    private bool[] eventComplete = new bool[3];

    // Start is called before the first frame update
    void Start()
    {
        bigGuy = transform.parent.GetComponent<BSGmovement>();
        eventComplete[0] = false;
        eventComplete[1] = false;
        eventComplete[2] = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void flipRight()
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 1);
    }

    public void flipLeft()
    {
        transform.localScale = new Vector3(-0.2f, 0.2f, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == events[0])
        {
            //Napstablook needs help
            if (!eventComplete[0])
            {
                StartCoroutine(event1());
            }
           
        }
        else if (collision == events[1])
        {
            //You find the hat
            if (!eventComplete[1])
            {
                StartCoroutine(event2());
            }
        }
        else
        {
            //You win
            if(eventComplete[1] && !eventComplete[2])
            {
                StartCoroutine(event3());
            }
        }
    }

    private IEnumerator event1()
    {
        eventComplete[0] = true;
        bigGuy.freeze();
        textBox.speechStart("*hello there...", 2, false);
        yield return new WaitForSeconds(4);
        textBox.speechStart("*can you find my hat..?", 2, false);
        yield return new WaitForSeconds(4);
        textBox.speechStart("*...please?", 2, true);
        yield return new WaitForSeconds(3);
        bigGuy.thaw();
    }

    private IEnumerator event2()
    {
        partyHat.disappear();
        eventComplete[1] = true;
        bigGuy.freeze();
        textBox.speechStart("You got the hat!", 0, false);
        yield return new WaitForSeconds(4);
        textBox.speechStart("Go bring it back to Napstablook.", 0, true);
        bigGuy.thaw();
    }

    private IEnumerator event3()
    {
        ghosty.changeHat();
        eventComplete[2] = true;
        bigGuy.freeze();
        textBox.speechStart("*...thank you", 3, true);
        yield return new WaitForSeconds(4.5f);
        dream.stop();
        theEnd.undertale();

    }


}
