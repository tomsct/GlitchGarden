using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] GameObject gun;

    private AttackerSpawner MyLaneSpawner { get; set; }
    private Animator Animator { get; set; }
    private void Start()
    {
        SetLaneSpawner();
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInLane())
            Animator.SetBool("isAttacking", true);
        else
            Animator.SetBool("isAttacking", false);
    }

    private bool IsAttackerInLane()
    {
        if (MyLaneSpawner.transform.childCount <= 0) 
            return false;
        else
            return true;
    } 

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            if (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon)
                MyLaneSpawner = spawner;
        }
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }
}
