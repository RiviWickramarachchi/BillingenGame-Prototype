using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{

    [SerializeField] private int xp = 0;
    [SerializeField] private int requiredXP = 100;
    [SerializeField] private int levelBase = 100;
    [SerializeField] private List<GameObject> gems = new List<GameObject>();
    [SerializeField] private CinemachineVirtualCamera playerVcam;
    [SerializeField] private GameObject playerLookAtObj;
    [SerializeField] private GameObject enemyFocusPoint;
    private int lvl = 1;

    public int Xp
    {
        get { return xp; }
    }
    public int RequiredXP 
    { 
        get { return requiredXP; } 
    }
    public int LevelBase { get => levelBase;  }
    public List<GameObject> Gems { get => gems;  }
    public int Lvl { get => lvl; }
    public CinemachineVirtualCamera PlayerVcam { get => playerVcam; }
    public GameObject PlayerLookAtObj { get => playerLookAtObj;  }
    public GameObject EnemyFocusPoint { get => enemyFocusPoint; }

    public void addXp(int xp)
    {
        this.xp += Mathf.Max(0, xp);

    }

    public void addGems(GameObject gem)
    {
        gems.Add(gem);
    }

    private void initLevelData()
    {
        // initiallizing level data is done here 
        lvl = (xp / levelBase) + 1;
        requiredXP = levelBase * lvl;

    }
    // Start is called before the first frame update
    void Start()
    {
        initLevelData();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
