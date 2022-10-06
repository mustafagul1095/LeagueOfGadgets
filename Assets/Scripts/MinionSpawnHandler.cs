using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinionSpawnHandler : MonoBehaviour
{
    [SerializeField] private GameObject minionPrefab;
    [SerializeField] private float minionSpawnPeriod = 1.5f;
    [SerializeField] private Transform enemyNexus;
    [SerializeField] private float waveSpawnPeriod = 15f;
    [SerializeField] private int numberOfMinions = 6;

    private float _time = 0f;
    private SideHandler _sideHandler;
    private bool _minionSpawned;
    private int _minionCount = 0;

    private void Start()
    {
        _sideHandler = GetComponent<SideHandler>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= waveSpawnPeriod)
        {
            _time = 0;
            StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        while (!_minionSpawned && _minionCount < numberOfMinions)
        {
            SpawnMinion();
            _minionCount++;
            _minionSpawned = true;
            yield return new WaitForSeconds(minionSpawnPeriod);
            _minionSpawned = false;
        }
        if (_minionCount >= numberOfMinions)
        {
            _minionCount = 0;   
        }
    }

    private void SpawnMinion()
    {
        var go =Instantiate(minionPrefab, transform.position, Quaternion.identity);
        var minion = go.GetComponentInChildren<Minion>();
        var rangeHandler = go.GetComponentInChildren<MinionRangeHandler>();
        var minionController = go.GetComponentInChildren<MinionController>();
        minion.Init(enemyNexus);
        rangeHandler.Init(minion.gameObject);
        minionController.Init(rangeHandler);
        
        var sideHandler = go.GetComponentInChildren<SideHandler>();
        sideHandler.side = _sideHandler.side;
    }
}
