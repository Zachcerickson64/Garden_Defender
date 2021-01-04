using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    [SerializeField] float waitTime = 2f;
    [SerializeField] GameObject loseLabel;
    






    private void Start()
    {

        winLabel.SetActive(false);
        loseLabel.SetActive(false);
     
        

    }



    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackersKilled()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition()) ;
        }
    }

    public IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
      
        yield return new WaitForSeconds(waitTime);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
      
    }

   

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

}
