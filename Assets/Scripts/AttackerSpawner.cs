using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [Header("Spawn Properties")]
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackers;
    private bool Spawn { get; set; }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        Spawn = true;
        while (Spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker(Random.Range(0, attackers.Length));
        }
    }

    public void StopSpawning()
    {
        Spawn = false;
    }

    private void SpawnAttacker(int index)
    {
        Attacker newAttacker = Instantiate(attackers[index], transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

}
