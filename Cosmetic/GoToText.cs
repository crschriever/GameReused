using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Text))]
public class GoToText : MonoBehaviour
{
    public GameObject TARGET;
    public float SPEED;
    public bool SHRINK;
    public float SHRINK_SPEED;
    public bool FADE;
    public float FADE_SPEED;
    public bool DESTROY_ON_END = true;
    public Action ON_DONE;

    private bool moving = false;

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            float referenceResolutionWidth = Screen.width;
            float secondsThisFrame = Time.deltaTime;

            float distanceThisFrame = (referenceResolutionWidth * SPEED) * secondsThisFrame;

            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, TARGET.transform.position, distanceThisFrame);

            if (SHRINK)
            {

                gameObject.transform.localScale = Vector2.MoveTowards(gameObject.transform.localScale, Vector2.zero, SHRINK_SPEED * Time.deltaTime);
            }

            if (FADE)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.MoveTowards(text.color.a, 0, FADE_SPEED * Time.deltaTime));
            }

            if (gameObject.transform.position == TARGET.transform.position)
            {
                moving = false;
                End();
            }
        }
    }

    public void End()
    {
        if (DESTROY_ON_END)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
        ON_DONE.Invoke();
    }

    public void GoToTarget()
    {
        moving = true;
        gameObject.SetActive(true);
    }

    public void GoToTarget(GameObject target)
    {
        TARGET = target;
        GoToTarget();
    }
}
