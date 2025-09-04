using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UiLevelScrollView : MonoBehaviour
{
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] RectTransform viewport;
    [SerializeField] RectTransform content;
    int _childObjectWidth = 100;
    HorizontalLayoutGroup _layout;
    float _currentAnchorPositionX = 1584.771f;
    [SerializeField] UiLevelScrollViewLevelCardManager levelCardManager;
    Vector2 _startingAnchorPosition;

    void Awake()
    {
        _layout = content.GetComponent<HorizontalLayoutGroup>();
    }

    public void Init(int currentLevel)
    {
        scrollRect.horizontalNormalizedPosition = 0f;
        _startingAnchorPosition = content.anchoredPosition;
        
        levelCardManager.Initialize(currentLevel);
    }

    public void SnapBackOnSpin()
    {
        content.DOAnchorPos(_startingAnchorPosition, 0.2f);
    }

    public void UpdateAnchorPosition(int level)
    {
        if (level == 1) return;
        scrollRect.enabled = false;
        content.DOAnchorPos(_startingAnchorPosition, 0.2f).OnComplete(() =>
        {
            var previousAnchorPosition = content.anchoredPosition;
            var nextAnchorPosition = content.anchoredPosition;
            nextAnchorPosition.x -= _childObjectWidth+_layout.spacing;
            content.DOAnchorPos(nextAnchorPosition, 0.8f).OnComplete(() =>
            {
                content.anchoredPosition = previousAnchorPosition;
                scrollRect.enabled = true;
                levelCardManager.Initialize(level);
            });
        });
        
    }
}