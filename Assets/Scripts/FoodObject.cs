using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObject : MonoBehaviour
{
    public GameObject parent;
    public Collider[] col;
    public FoodData foodData;
    public GameObject childObject;

    void Start()
    {
        parent = transform.parent.gameObject;
        
        if(parent != null)
        {
            childObject = parent.transform.GetChild(1).gameObject;
            col = childObject.GetComponents<Collider>();
        }
        foreach (var c in col)
        {
            c.isTrigger = false;
        }
    }
    public void HandleCollisionEnter(Collision other)
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ExperienceSystem.instance.AddExperience(foodData.foodValue);
            Destroy(parent);
        }
    }
}
