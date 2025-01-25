using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    private int experience;
    private int experienceToNextLevel = 100;
    public int currentLevel = 1;


    public static ExperienceSystem instance;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        experience = 0;
    }

    public void AddExperience(int exp)
    {
        experience += exp;
        PlayerController.instance.playerScale += new Vector3(2f, 2f, 2f); // degiscek  
        PlayerController.instance.transform.localScale = PlayerController.instance.playerScale;
        print("Experience: " + experience);
        if (experience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        print("Level Up!");
        currentLevel++;
        experience -= experienceToNextLevel;
        experienceToNextLevel *= 2; // degiscek 
        print("Current Level: " + currentLevel);
        print("Experience to next level: " + experienceToNextLevel);
        
    }


}
