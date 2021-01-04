using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    GameObject projectileParent;
    const string PROJECTILE_PARENT = "Projectiles";

    AttackerSpawner myLaneSpawner;
    Animator animator;


    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();

    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT);

        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT);
        }

    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }

        else
        {
            animator.SetBool("IsAttacking", false);

        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y)
                <= Mathf.Epsilon);

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }


    private bool IsAttackerInLane()
    {
        if (myLaneSpawner != null)
        {
            if (myLaneSpawner.transform.childCount <= 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
        else { return false; }
    }
    

    public void Fire()
    {
       GameObject newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
