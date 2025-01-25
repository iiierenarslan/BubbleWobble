using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObject : MonoBehaviour
{
    public GameObject parent;
    private Collider[] col;
    public FoodData foodData;


    void Start()
    {
        parent = transform.parent.gameObject;
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
            if(ExperienceSystem.instance.currentLevel >= foodData.foodLevel)
            {
                foreach (var c in col)
                {
                    c.isTrigger = true;
                }
            }
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ExperienceSystem.instance.AddExperience(foodData.foodValue);
            PlayerController.instance.foodcount++;
            Destroy(parent);
        }
    }
}
