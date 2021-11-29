using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySceneManager : BillingenGameSceneManager
{

    private EnemySceneStatus status = EnemySceneStatus.Started;
    private float starting_time = 10f;
    private float current_time = 0f;
    [SerializeField] Text timerText;
    [SerializeField] private GameObject enemySceneGUI;
    

    public EnemySceneStatus Status
    {
        get { return status; }
    }




    public override void enemySpawned(GameObject enemy)
    {
        print("enemySpawn screen activated");
    }

    public void timerActions()
    {
        if(Status == EnemySceneStatus.Started)
        {
            current_time -= 1 * Time.deltaTime;
            timerText.text = (Mathf.Round(current_time)).ToString();
        }

        if(current_time <= 0)
        {
            status = EnemySceneStatus.Ended;
            
            if( GameManager.Instance.CurrentPlayer.GetComponent<GpsManager>().Distance > 50.0f)
            {
                print("success");
                status = EnemySceneStatus.SuccessfulEscape;
            }
            else
            {
                //print("fail");
                status = EnemySceneStatus.FailedEscape;
            }
            //print("ended");
        }
    }

    public void goToWorldScene()
    {
        //SceneTransitionManager.Instance.GoToScene(BillingenGameConstants.SCENE_WORLD);
        //set active == false for game object consisting this script
        enemySceneGUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        current_time = starting_time;
        GameManager.Instance.CurrentPlayer.GetComponent<GpsManager>().Distance = 0;

    }

    // Update is called once per frame
    void Update()
    {
        timerActions();
    }
}
