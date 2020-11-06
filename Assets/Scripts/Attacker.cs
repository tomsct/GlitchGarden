using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float MovementSpeed { get; set; }
    private GameObject CurrentTarget { get; set; }

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * MovementSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().AttackerKilled();
    }

    public void SetMovementSpeed(float movementSpeed)
    {
        MovementSpeed = movementSpeed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        CurrentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!CurrentTarget) return;

        if (CurrentTarget.GetComponent<Health>())
            CurrentTarget.GetComponent<Health>().DealDamage(damage);
    }

    private void UpdateAnimationState()
    {
        if (!CurrentTarget)
            GetComponent<Animator>().SetBool("isAttacking", false);
    }
}
