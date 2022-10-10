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
    

    public void LoadTheBoss()
    {
        Instantiate(theBossPrefab, initPosition, Quaternion.identity, parentObj);
        Destroy(gameObject);
    }

    public void LoadNinjaBoy()
    {
        Instantiate(ninjaBoyPrefab, initPosition, Quaternion.identity, parentObj);
        Destroy(gameObject);
    }
    
    public void LoadFlamer()
    {
        Instantiate(flamerPrefab, initPosition, Quaternion.identity, parentObj);
        Destroy(gameObject);
    }
    
    public void LoadZombie()
    {
        Instantiate(zombiePrefab, initPosition, Quaternion.identity, parentObj);
        Destroy(gameObject);
    }
    
    public void LoadVampire()
    {
        Instantiate(vampirePrefab, initPosition, Quaternion.identity, parentObj);
        Destroy(gameObject);
    }
}
