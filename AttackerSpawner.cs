using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabs;

    bool spawn = true;

    // Start is called before the first frame update


    public IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
           
            
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var index = UnityEngine.Random.Range(0, attackerPrefabs.Length);
        Spawn(attackerPrefabs[index]);
        
    }

    private void Spawn(Attacker attacker)
    {
        
        Attacker newAttacker = Instantiate
                    (attacker, transform.position, transform.rotation)
                    as Attacker;
        newAttacker.transform.parent = transform;
    }

    
}
