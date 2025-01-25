using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public FoodObject foodObject;

    private void Start()
    {
        GameObject parent = transform.parent.gameObject;
        GameObject childObject = parent.transform.GetChild(0).gameObject;
        foodObject = childObject.GetComponent<FoodObject>();

    }



    private void OnCollisionEnter(Collision collision)
    {
        // Forward the collision event to FoodObject
        foodObject?.HandleCollisionEnter(collision);
    }

}
