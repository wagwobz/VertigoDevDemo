using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UiLevelScrollViewContent : MonoBehaviour
{
    public List<UiLevelScrollViewLevelCard> levelCards = new List<UiLevelScrollViewLevelCard>();

    void Awake()
    {
        levelCards = GetComponentsInChildren<UiLevelScrollViewLevelCard>().ToList();
    }

    void Start()
    {
        for (int i = 0; i < levelCards.Count; i++)
        {
            levelCards[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
        }
    }
}

public class UiLevelScrollViewLevelCardManager : MonoBehaviour
{
    int _currentLevel = 0;

    int[] levelIndexes;

    [SerializeField] Sprite normalBackgroundSprite;
    [SerializeField] Sprite currentLevelBackgroundSprite;
    [SerializeField] Sprite safeZoneBackgroundSprite;
    [SerializeField] Sprite superZoneBackgroundSprite;

    public void Initialize(int currentLevel)
    {
        var startIndex = 1;
        if (currentLevel > 15) startIndex = currentLevel - 15;

        for (int i = startIndex; i < startIndex + 29; i++)
        {
            if (i == 1)
            {
                //safeZone
                continue;
            }

            if (i % 30 == 0)
            {
                //superZone
                continue;
            }

            if (i % 5 ==0)
            {
                //safeZone
                continue;
            }
            
            //regular
        }
    }
}