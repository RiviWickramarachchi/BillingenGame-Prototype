using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Enemy : MonoBehaviour
{

    [SerializeField] private float minDistanceBetweenPlayerAndEnemy = 10.0f;
    private CinemachineVirtualCamera vCam;
    private GameObject enemyFocusPoint;
    private GameObject enemySceneGUI;
    private GameObject playerLookAtObj;
    private float waitTime = 4.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        enemySceneGUI  = GameManager.Instance.CurrentPlayer.GetComponent<EnemyGenerator>().EnemySceneGUI;
        vCam = GameManager.Instance.CurrentPlayer.PlayerVcam;
        playerLookAtObj = GameManager.Instance.CurrentPlayer.PlayerLookAtObj;
        enemyFocusPoint = GameManager.Instance.CurrentPlayer.EnemyFocusPoint;
        
    }

    // Update is called once per frame
    void Update()
    {
        checkDistanceToPlayer();
    }

    private void checkDistanceToPlayer()
    {
        Transform playerTransform = GameManager.Instance.CurrentPlayer.GetComponent<Transform>();
        if(Vector3.Distance(transform.position, playerTransform.position) < minDistanceBetweenPlayerAndEnemy)
        {
            setEnemyFocusPointCoordinates();
            vCam.Follow = enemyFocusPoint.transform;
            //vCam.LookAt = enemyFocusPoint.transform;
            Invoke("triggerEnemyScreen",waitTime);
           
        }
    }

    private void triggerEnemyScreen()
    {
        enemySceneGUI.SetActive(true);
        vCam.Follow = playerLookAtObj.transform;
        Destroy(gameObject);
    }

    private void setEnemyFocusPointCoordinates()
    {
        float enemyFPx = gameObject.transform.position.x;
        float enemyFPy = gameObject.transform.position.y + 3.5f;
        float enemyFPz = gameObject.transform.position.z - 10.0f;
        enemyFocusPoint.transform.position = new Vector3(enemyFPx, enemyFPy, enemyFPz);
    }

   


}
