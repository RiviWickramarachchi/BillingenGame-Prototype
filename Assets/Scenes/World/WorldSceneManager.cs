using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : BillingenGameSceneManager
{
    public override void enemySpawned(GameObject enemy)
    {
        SceneManager.LoadScene(BillingenGameConstants.SCENE_ENEMY);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
