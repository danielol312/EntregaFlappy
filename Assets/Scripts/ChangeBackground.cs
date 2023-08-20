using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    [SerializeField] GameObject pipesPrefab;
    [SerializeField] GameObject[] grounds;
    [SerializeField] GameObject background;
    [SerializeField] Sprite[] pipesUp;
    [SerializeField] Sprite[] pipesDown;
    [SerializeField] Sprite[] groundSprites;
    [SerializeField] Sprite[] backgroundSprites;
    void Awake()
    {
        int randomIndex = UnityEngine.Random.Range(0, 2);
        SpriteRenderer[] pipesSprites = pipesPrefab.GetComponentsInChildren<SpriteRenderer>();
        pipesSprites[0].sprite = pipesUp[randomIndex];
        pipesSprites[1].sprite = pipesDown[randomIndex];
        foreach (GameObject ground in grounds)
        {
            ground.GetComponent<SpriteRenderer>().sprite = groundSprites[randomIndex];
        }
        background.GetComponent<SpriteRenderer>().sprite = backgroundSprites[randomIndex];
    }
}
