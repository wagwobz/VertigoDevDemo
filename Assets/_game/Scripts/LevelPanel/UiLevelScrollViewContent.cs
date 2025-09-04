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