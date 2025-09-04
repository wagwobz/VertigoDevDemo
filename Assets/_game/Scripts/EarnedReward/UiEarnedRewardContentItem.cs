using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiEarnedRewardContentItem: MonoBehaviour
{
    public uint id = 9999;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] Image image;
    int _currentAmount;
    public void Init(Sprite sprite, int amount, uint id)
    {
        this.id = id;
        _currentAmount = amount;
        image.sprite = sprite;
        UpdateText();
    }

    public void AddAmount(int amount)
    {
        _currentAmount += amount;
        UpdateText();
    }

    public void UpdateText()
    {
        textMeshProUGUI.text  = _currentAmount.ToString();
    }
}