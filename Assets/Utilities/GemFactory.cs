using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GemFactory : Singleton<GemFactory>
{

    [SerializeField] private Gem[] availableGems;
    [SerializeField] private Gem[] specialGems;
    [SerializeField] private Player player;
    //[SerializeField] private GameObject enemySceneGUI;
    [SerializeField] private float waitTime = 180.0f; //180.0f ... can be adjusted accordingly
    [SerializeField] private int startingGems = 5;
    [SerializeField] private float minRange = 5.0f;
    [SerializeField] private float maxRange = 50.0f;

    //public GameObject EnemySceneGUI {get => enemySceneGUI;}

    private void Awake()
    {
        Assert.IsNotNull(availableGems);
        Assert.IsNotNull(specialGems);
        Assert.IsNotNull(player);
    }
    void Start()
    {
        for(int i = 0; i< startingGems;i++)
        {
            InstantiateGems();
        }
        StartCoroutine(GenerateGems());

    }

    private void InstantiateGems()
    {
        int index = Random.Range(0, availableGems.Length);
        float x = player.transform.position.x + GenerateRange();
        float y = player.transform.position.y + 1.5f;
        float z = player.transform.position.z + GenerateRange();
        //Instantiate(availableGems[index], new Vector3(x, y, z), Quaternion.identity);
        Instantiate(availableGems[index], new Vector3(x, y, z), Quaternion.Euler(87.237f,0f,0f));
        print("new gem instantiated");

    }

    private void InstantiateSpecialGems()
    {
        int index = Random.Range(0, specialGems.Length);
        float x = player.transform.position.x + GenerateRange();
        float y = player.transform.position.y + 1.5f;
        float z = player.transform.position.z + GenerateRange();
        Instantiate(specialGems[index], new Vector3(x, y, z), Quaternion.identity);
        print("special gem instantiated");

        //Use the special gem as an enemy for now 
        //set active == true for game object with enemy encounter 
        //enemySceneGUI.SetActive(true);
        //SceneTransitionManager.Instance.GoToScene(BillingenGameConstants.SCENE_ENEMY);
        //calculate the distance the player has walked and instantiate gems with more xp regarding the distance the player has walked 
        //distance calculation is done in transform.position for testing purposes, but has to be based on GPS in the real game.
    }

    private float GenerateRange()
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPositive = Random.Range(0, 10) < 5;
        return randomNum * (isPositive ? 1 : -1);

    }

    private IEnumerator GenerateGems()
    {
        while(true)
        {
            //float distanceTravelled = player.GetComponent<GpsManager>().Distance;
            //print(string.Format("Distance travelled = {0}", distanceTravelled));
            print("before");
            if(player.GetComponent<GpsManager>().Distance > 300.0f)
            {
                InstantiateSpecialGems();
                player.GetComponent<GpsManager>().Distance = 0;
                //GameManager.Instance.CurrentPlayer.GetComponent<GpsManager>().Distance = 0;
            }
            InstantiateGems();
            yield return new WaitForSeconds(waitTime);
         
        }
    }

    



    
   
}
