using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Gravestone>())
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        else if (collision.gameObject.GetComponent<Defender>())
            GetComponent<Attacker>().Attack(collision.gameObject);
    }
}
