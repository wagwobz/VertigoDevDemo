using System;
using UnityEngine;

public class UiLevelScrollViewLevelCardManager : MonoBehaviour
{
    int[] levelIndexes;

    [SerializeField] Sprite normalBackgroundSprite;
    [SerializeField] Sprite currentLevelBackgroundSprite;
    [SerializeField] Sprite safeZoneBackgroundSprite;
    [SerializeField] Sprite superZoneBackgroundSprite;
    [SerializeField] UiLevelScrollViewLevelCard[]  levelCards;
    void Awake()
    {
        levelCards =  GetComponentsInChildren<UiLevelScrollViewLevelCard>();
    }

    public void Initialize(int currentLevel)
    {
        var startIndex = currentLevel;
        // if (currentLevel > 15) startIndex = currentLevel - 15;

        for (int i = startIndex; i < startIndex + 30; i++)
        {
            if (i == 1)
            {
                levelCards[i-startIndex].UpdateCard(safeZoneBackgroundSprite,i);
                continue;
            }

            if (i % 30 == 0)
            {
                levelCards[i-startIndex].UpdateCard(superZoneBackgroundSprite,i);
                continue;
            }

            if (i % 5 ==0)
            {
                levelCards[i-startIndex].UpdateCard(safeZoneBackgroundSprite,i);
                continue;
            }
            
            //regular
            levelCards[i-startIndex].UpdateCard(normalBackgroundSprite,i);
        }
    }
}