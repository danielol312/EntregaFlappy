using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FlappyBird
{
    public class RandomAnimationChanger : MonoBehaviour
    {
        [SerializeField] GameObject[] birds;
        void Start()
        {
            int index = UnityEngine.Random.RandomRange(0, 3);
            for (int i = 0; i < birds.Length; i++)
            {
                if (i != index)
                {
                    birds[i].SetActive(false);
                }
            }
        }
    }
}

