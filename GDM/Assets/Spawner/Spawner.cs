using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pillowPrefab; // Prefab ของเสา
    public float gapSize = 3.0f; // ระยะห่างช่องว่างของเสา
    public float spawnInterval = 2.0f; // เวลาในการสปอนเสา
    public float destroyDistance = 10.0f; // ระยะในการทำลายเสา

    private void Start()
    {
        StartCoroutine(SpawnPillows());
    }

    private IEnumerator SpawnPillows()
    {
        while (true)
        {
            float randomY = Random.Range(-3f, 3.5f);//จะต๋ำและสูงสุดที่เสาจะสปอนได้
            Vector3 bottomPillowPosition = transform.position + new Vector3(0, -gapSize + randomY, 0);
            Instantiate(pillowPrefab, bottomPillowPosition, Quaternion.identity);
            GameObject topPillow = Instantiate(pillowPrefab, transform.position + new Vector3(0, gapSize + randomY, 0), Quaternion.identity);
            topPillow.transform.localScale = new Vector3(1f, -1f, 1f);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Update()
    {
        // คำสั่งทำลายเสา
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obstacle in obstacles)
        {
            if (obstacle.transform.position.x < transform.position.x - destroyDistance)
            {
                Destroy(obstacle);
            }
        }
    }
}