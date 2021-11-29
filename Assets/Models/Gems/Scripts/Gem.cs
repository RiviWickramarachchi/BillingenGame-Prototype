using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour

{

    [SerializeField] private float spawnRate = 0.1f;
    [SerializeField] private int gemXp = 10;
    
    public float SpawnRate { get => spawnRate;}
    public int GemXp { get => gemXp; }

    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnMouseDown()
    {
        GameManager.Instance.CurrentPlayer.addXp(gemXp);
        Destroy(gameObject);
    }

   
   
}
