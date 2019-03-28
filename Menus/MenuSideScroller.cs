using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSideScroller : MonoBehaviour
{

    public Button LEFT_BUTTON;
    public Button RIGHT_BUTTON;
    public RectTransform CONTAINER;
    public float MOVE_DISTANCE;
    public float MOVE_TIME;
    public int NUM_TILES;

    private int desiredIndex = 0;

    void Start()
    {
        CheckArrows();
    }

    // Update is called once per frame
    void Update()
    {
        CONTAINER.anchoredPosition = Vector3.MoveTowards(CONTAINER.anchoredPosition, new Vector3(desiredIndex * -MOVE_DISTANCE, 0, 0), (MOVE_DISTANCE / MOVE_TIME) * Time.deltaTime);
    }

    public void GoLeft()
    {
        desiredIndex = Mathf.Max(desiredIndex - 1, 0);
        CheckArrows();
    }

    public void GoRight()
    {
        desiredIndex = Mathf.Min(desiredIndex + 1, NUM_TILES - 1);
        CheckArrows();
    }

    private void CheckArrows()
    {

        LEFT_BUTTON.interactable = desiredIndex != 0;
        RIGHT_BUTTON.interactable = desiredIndex != NUM_TILES - 1;

        if (PlayerPrefs.GetInt("Level 0-15_finished") != 1)
        {
            RIGHT_BUTTON.interactable = false;
        }

    }
}
