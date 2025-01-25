using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private Collider[] col;
    public FoodData foodData;


    private void Start()
    {
        col = GetComponents<Collider>();
        foreach (var c in col)
        {
            c.isTrigger = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (ExperienceSystem.instance.currentLevel >= foodData.foodLevel)
            {
                foreach (var c in col)
                {
                    c.isTrigger = true;
                }
            }
        }
    }
}
