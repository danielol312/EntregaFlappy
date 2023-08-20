using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace FlappyBird
{
    public class PipeSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject pipePrefab;
        [SerializeField]
        private Transform spawnPoint;

        [Space, SerializeField, Range(-1, 1)]
        private float minHeight;
        [SerializeField, Range(-1, 1)]
        private float maxHeight;

        [Space, SerializeField]
        private float timeToSpawnFirstPipe;
        [SerializeField]
        private float timeToSpawnPipe;

        private Queue<GameObject> pipePool = new Queue<GameObject>();

        private void Start()
        {
            StartCoroutine(SpawnPipes());
        }

        private GameObject GetPooledPipe()
        {
            if (pipePool.Count > 0)
            {
                GameObject pooledPipe = pipePool.Dequeue();
                pooledPipe.SetActive(true);
                return pooledPipe;
            }
            else
            {
                return Instantiate(pipePrefab);
            }
        }

        private IEnumerator SpawnPipes()
        {
            yield return new WaitForSeconds(timeToSpawnFirstPipe);

            while (true)
            {
                GameObject newPipe = GetPooledPipe();
                newPipe.transform.position = GetSpawnPosition();
                yield return new WaitForSeconds(timeToSpawnPipe);
            }
        }

        private Vector3 GetSpawnPosition()
        {
            return new Vector3(spawnPoint.position.x, Random.Range(minHeight, maxHeight), spawnPoint.position.z);
        }

        public void ReturnPipeToPool(GameObject pipeToReturn)
        {
            pipeToReturn.SetActive(false);
            pipePool.Enqueue(pipeToReturn);
        }

        public void Stop()
        {
            StopAllCoroutines();
        }
    }
}




