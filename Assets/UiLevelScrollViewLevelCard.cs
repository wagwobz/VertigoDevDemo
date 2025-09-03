using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class UiLevelScrollViewLevelCard : MonoBehaviour
{
    [SerializeField] Image backgroundImage;
    [SerializeField] Image borderImage;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    public void Init(Sprite bgSprite, Sprite borderSprite, int levelIndex)
    {
        backgroundImage.sprite = bgSprite;
        borderImage.sprite = borderSprite;
        textMeshProUGUI.text = levelIndex.ToString();
    }
}
