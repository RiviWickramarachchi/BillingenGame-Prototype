using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemySceneUIManager : MonoBehaviour
{
    [SerializeField] private EnemySceneManager manager;
    [SerializeField] private GameObject successScreen;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject failScreen;

    private void Awake()
    {
        Assert.IsNotNull(manager);
        Assert.IsNotNull(successScreen);
        Assert.IsNotNull(failScreen);
        Assert.IsNotNull(gameScreen);

    }

    // Update is called once per frame
    void Update()
    {
        switch(manager.Status)
        {
            case EnemySceneStatus.Started:
                HandleStartedUI();
                break;
            case EnemySceneStatus.SuccessfulEscape:
                HandleSuccessUI();
                break;
            case EnemySceneStatus.FailedEscape:
                HandleFailUI();
                break;
            default:
                break;
        }
    }

    private void HandleStartedUI()
    {
        HandleEnemyScreenUI();
    }
    private void HandleSuccessUI()
    {
        HandleEnemyScreenUI();
    }
    private void HandleFailUI()
    {
        HandleEnemyScreenUI();
    }
    private void HandleEnemyScreenUI()
    {
        successScreen.SetActive(manager.Status == EnemySceneStatus.SuccessfulEscape);
        failScreen.SetActive(manager.Status == EnemySceneStatus.FailedEscape);
        gameScreen.SetActive(manager.Status == EnemySceneStatus.Started);
   
    }
}
