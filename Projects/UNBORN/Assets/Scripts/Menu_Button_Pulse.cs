using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Button_Pulse : MonoBehaviour {

    public Sprite Circle;
    public Sprite Cross;

    public bool inRange;

    public GameObject Player;
    public float PlayerDistance;
    public float maxDistance;

    public float maxScale;
    float increase;


	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        increase = maxScale / 150;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Player.transform);
        PlayerDistance = Vector3.Distance(gameObject.transform.position, Player.transform.position);


        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, (1 / (gameObject.transform.localScale.x * 2)));
        if (gameObject.transform.localScale.x > maxScale)
        {
            gameObject.transform.localScale = new Vector3(increase / 2, increase / 2, increase / 2);
        }
        else
        {
            gameObject.transform.localScale += new Vector3(increase , increase, increase);
        }

    if (PlayerDistance > maxDistance || ReplaceSubtitles.instance.play == true)
    {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            inRange = false;
        }
    else
    {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, (1 / (gameObject.transform.localScale.x * 2)));
            inRange = true;
        }
  

        /*  transform.LookAt(Player.transform);

          PlayerDistance = Vector3.Distance(gameObject.transform.position, Player.transform.position);


              gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, (1 / (gameObject.transform.localScale.x * 2)));
              if (gameObject.transform.localScale.x > 3)
              {
                  gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
              }
              else
              {
                  gameObject.transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
              }

          if (PlayerDistance > 3)
          {
              gameObject.GetComponent<SpriteRenderer>().sprite = Circle;
          }
          else
          {
              gameObject.GetComponent<SpriteRenderer>().sprite = Cross;
          }
          */
    }
}
