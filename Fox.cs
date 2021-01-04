using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        Animator animator = GetComponent<Animator>();

        if (otherObject.GetComponent<Gravestone>())
        {
            animator.SetTrigger("Jump Trigger");

        }

        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
           
        
    }
}
