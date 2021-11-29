using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyGenerator : Singleton<EnemyGenerator>
{
    
    [SerializeField] private Player player;
    [SerializeField] private Enemy[] availableEnemies;
    [SerializeField] private GameObject enemySceneGUI;
    [SerializeField] private float waitTime = 300.0f; 
    [SerializeField] private float minRange = 5.0f;
    [SerializeField] private float maxRange = 50.0f;

    public GameObject EnemySceneGUI { get => enemySceneGUI;}

    private void Awake()
    {
        Assert.IsNotNull(availableEnemies);
        Assert.IsNotNull(player);
        Assert.IsNotNull(enemySceneGUI);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(generateEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiateEnemy()
    {
        int index = Random.Range(0, availableEnemies.Length);
        float x = player.transform.position.x + GenerateRange();
        float y = player.transform.position.y;
        float z = player.transform.position.z + GenerateRange();
        Instantiate(availableEnemies[index], new Vector3(x, y, z), Quaternion.identity);

    }


    private float GenerateRange()
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPositive = Random.Range(0, 10) < 5;
        return randomNum * (isPositive ? 1 : -1);

    }

    private IEnumerator generateEnemies()
    {
        while(true)
        {
            
            yield return new WaitForSeconds(waitTime);
            InstantiateEnemy();
            
        }
    }


}
