using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform Dash;
    [SerializeField] private Transform Jump;
    [SerializeField] private Transform JumpDash;
    [SerializeField] private Transform Crouch;
    private void Awake()
    {
        int randNum;
        //spacing for for dash and jump
        int spacing = 6;
        //spacing for jumpdash and crouch
        //spacing for crouches
        int longSpacing = 10;
        //spacing for jump dashes
        int mediumSpacing = 8;
        //position obstacles start spawning
        int currentPosition = 0;
        int nextPosition;
        int obsGenerated = 160;
        //varibable to ensure that enough spacing is given between long obstacles
        bool isLong = false;
        bool isMedium = false;
        for(int i = 0; i < obsGenerated; i++)
        {
            if (isLong)
            {
                spacing = 8;
            }
            else if (isMedium)
            {
                spacing = 8;
            }
            else
            {
                spacing = 4;
            }
            //1/4 no block is placed
            randNum = Random.Range(0, 8);
            //dash
            if (randNum == 0)
            {
                nextPosition = currentPosition + spacing;
                currentPosition = nextPosition;
                SpawnLevelObsDash(new Vector3(currentPosition, -3));
                isLong = false;
            }
            //jump
            else if (randNum == 1)
            {
                nextPosition = currentPosition + spacing;
                currentPosition = nextPosition;
                SpawnLevelObsJump(new Vector3(currentPosition, -3.6f));
                isLong = false;
            }
            //jumpdash
            //double the chance
            else if (randNum == 2 || randNum == 3)
            {
                nextPosition = currentPosition + mediumSpacing;
                currentPosition = nextPosition;
                SpawnLevelObsJumpDash(new Vector3(currentPosition, -3.5f));
                isMedium = true;
                isLong = false;
            }
            //crouch
            //double the chance
            else if (randNum == 4 || randNum == 5)
            {
                //if statement to make crouches next to each other form into one
                if(isLong)
                {
                    longSpacing = 5;
                }
                    nextPosition = currentPosition + longSpacing;
                    currentPosition = nextPosition;
                    SpawnLevelObsCrouch(new Vector3(currentPosition, -3));
                    isLong = true;
                    longSpacing = 10;
            }
    }
    }
    private Transform SpawnLevelObsDash(Vector3 spawnPosition)
    {
        Transform levelObsTransform = Instantiate(Dash, spawnPosition, Quaternion.identity);
        return levelObsTransform;
    }
    private Transform SpawnLevelObsJump(Vector3 spawnPosition)
    {
        Transform levelObsTransform = Instantiate(Jump, spawnPosition, Quaternion.identity);
        return levelObsTransform;
    }
    private Transform SpawnLevelObsJumpDash(Vector3 spawnPosition)
    {
        Transform levelObsTransform = Instantiate(JumpDash, spawnPosition, Quaternion.identity);
        return levelObsTransform;
    }
    private Transform SpawnLevelObsCrouch(Vector3 spawnPosition)
    {
        Transform levelObsTransform = Instantiate(Crouch, spawnPosition, Quaternion.identity);
        return levelObsTransform;
    }
}
