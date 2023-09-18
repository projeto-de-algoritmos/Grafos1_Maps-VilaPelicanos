using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab1;
    public GameObject cloudPrefab2; 
    public float spawnRate = 6f; 

    private float spawnTimer;

    void Start()
    {
        spawnTimer = spawnRate;

        for (int i = 0; i < 10; i++)
        {
            SpawnCloud(-1100 + (i*210));
        }
    }

    void Update()
    {
        // Atualiza o temporizador de spawn
        spawnTimer -= Time.deltaTime;

        // Se o temporizador atingir zero, gere uma nuvem
        if (spawnTimer <= 0)
        {
            SpawnCloud();
            SpawnCloud();
            spawnTimer = spawnRate;
        }
    }

    void SpawnCloud()
    {
        // Escolha aleatoriamente entre os prefabs de nuvem
        GameObject cloudPrefab = Random.Range(0, 2) == 0 ? cloudPrefab1 : cloudPrefab2;

        // Crie uma nova nuvem na posição de spawn
        GameObject cloud = Instantiate(cloudPrefab, transform.position, Quaternion.identity);

        // Configure a escala e a hierarquia da nuvem
        cloud.transform.SetParent(transform);
        cloud.transform.localScale = Vector3.one;

        StartCoroutine(MoveClouds(cloud));
    }

    void SpawnCloud(float start)
    {
        // Escolha aleatoriamente entre os prefabs de nuvem
        GameObject cloudPrefab = Random.Range(0, 2) == 0 ? cloudPrefab1 : cloudPrefab2;

        // Crie uma nova nuvem na posição de spawn
        GameObject cloud = Instantiate(cloudPrefab, transform.position, Quaternion.identity);

        // Configure a escala e a hierarquia da nuvem
        cloud.transform.SetParent(transform);
        cloud.transform.localScale = Vector3.one;

        StartCoroutine(MoveClouds(cloud, start));
    }

    IEnumerator MoveClouds(GameObject cloud)
    {
        float startX = -1200f;
        float endX = 1200f;
        float distance = endX - startX;

        float startY = Random.Range(-400f, 400f);

        float timeFrame = 1f/120f;

        float prox = Random.Range(0.5f, 1.5f);

        float currentTime = 0;
        float totalTime = 40f;

        totalTime /= prox;
        cloud.transform.localScale = new Vector3(prox, prox, prox);

        cloud.transform.localPosition = new Vector3(startX, startY, 0);

        while (currentTime <= totalTime)
        {
            float progress = currentTime / totalTime;

            float currentDistance = (distance * progress) + startX;

            cloud.transform.localPosition = new Vector3(currentDistance, startY, 0);

            currentTime += timeFrame;
            yield return new WaitForSeconds(timeFrame);
        }

        Destroy(cloud);
    }


    IEnumerator MoveClouds(GameObject cloud, float start)
    {
        float startX = start;
        float endX = 1200f;
        float distance = endX - startX;
        float originalDistance = 1200 + 1200;


        float startY = Random.Range(-300f, 300f);

        float timeFrame = 1f / 120f;

        float prox = Random.Range(0.5f, 1.5f);

        float currentTime = 0;
        float totalTime = (40 * distance)/originalDistance;

        totalTime /= prox;
        cloud.transform.localScale = new Vector3(prox, prox, prox);

        cloud.transform.localPosition = new Vector3(startX, startY, 0);

        while (currentTime <= totalTime)
        {
            float progress = currentTime / totalTime;

            float currentDistance = (distance * progress) + startX;

            cloud.transform.localPosition = new Vector3(currentDistance, startY, 0);

            currentTime += timeFrame;
            yield return new WaitForSeconds(timeFrame);
        }

        Destroy(cloud);
    }

}
