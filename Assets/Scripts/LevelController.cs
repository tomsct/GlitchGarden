using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] float waitToLoad = 4f;
    private int NumberOfAttackers { get; set; }
    private bool LevelTimerFinished { get; set; }

    private void Start()
    {
        winLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        NumberOfAttackers++;
    }

    public void AttackerKilled()
    {
        NumberOfAttackers--;
        if (NumberOfAttackers <= 0 && LevelTimerFinished)
            StartCoroutine(HandleWinCondition());
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void TimerFinished()
    {
        LevelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in attackerSpawners)
            spawner.StopSpawning();
    }
}
