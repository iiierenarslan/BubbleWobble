using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Collider[] col;
    public FoodData foodData;
    public Transform player;
    public float moveSpeed;
    private bool isTriggered;

    void Start()
    {
        col = GetComponents<Collider>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        foreach (var c in col)
        {
            c.isTrigger = false;
        }

    }

    private void Update()
    {
        if (isTriggered)
        {
            MoveToPlayer();
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
                isTriggered = true;
                ExperienceSystem.instance.AddExperience(foodData.foodValue);
                Destroy(gameObject, 2);
            }
        }
    }
    void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, moveSpeed * Time.deltaTime);

    }



}
