using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public FoodObject foodObject;

    private void OnCollisionEnter(Collision collision)
    {
        // Forward the collision event to FoodObject
        foodObject?.HandleCollisionEnter(collision);
    }

}
