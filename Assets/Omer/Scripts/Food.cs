using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Food : MonoBehaviour
{
    public Collider[] col;
    public FoodData foodData;
    public Transform player;
    public float moveSpeed;
    private bool isTriggered;
    public AudioSource audioSource;



    void Start()
    {
        moveSpeed = 8f;
        col = GetComponents<Collider>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource =  GameObject.Find("eat").GetComponent<AudioSource>();  
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
                audioSource.Play();
                Destroy(gameObject, 0.3f);
            }
        }
    }

    void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, moveSpeed * Time.deltaTime);

    }



}
