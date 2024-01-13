using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    //spawn de enemigos en mapa
    public float spawnInterval = 8.0f; // El intervalo de tiempo entre cada generación de enemigos
                                       
    public GameObject[] enemyNave;

    public Vector3[] spawnPositionNave;


    bool spawnerActive = true; //spawner activo
    float delay = 8f; //retraso del spawner




    private void Start()
    {
        delay = 10f;
        spawnerActive = true;
        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        while (spawnerActive)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnEnemy()
    {
      
        {
           
            int randomIndex = Random.Range(0, enemyNave.Length);
            int randomPosition = Random.Range(0, spawnPositionNave.Length);

            GameObject randomEnemy = enemyNave[randomIndex];

            Instantiate(randomEnemy, spawnPositionNave[randomPosition], randomEnemy.transform.rotation);



        }
    }
