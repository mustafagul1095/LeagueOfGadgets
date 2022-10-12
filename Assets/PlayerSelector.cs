using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] private GameObject theBossPrefab;
    [SerializeField] private GameObject ninjaBoyPrefab;
    [SerializeField] private GameObject flamerPrefab;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject vampirePrefab;
    [SerializeField] private Transform parentObj;
    [SerializeField] private Vector3 initPosition;
    [SerializeField] private GameObject playerSelection;


    public void LoadTheBoss()
    {
        LoadPlayer(theBossPrefab);
    }
    
    public void LoadNinjaBoy()
    {
        LoadPlayer(ninjaBoyPrefab);
    }
    
    public void LoadFlamer()
    {
        LoadPlayer(flamerPrefab);
    }
    
    public void LoadZombie()
    {
        LoadPlayer(zombiePrefab);
    }
    
    public void LoadVampire()
    {
        LoadPlayer(vampirePrefab);
    }
    
    private void LoadPlayer(GameObject prefab)
    {
        Instantiate(prefab, initPosition, Quaternion.identity, parentObj);
        BroadcastMessage("OnPlayerSelected", SendMessageOptions.DontRequireReceiver);
        Destroy(playerSelection);
    }
}
