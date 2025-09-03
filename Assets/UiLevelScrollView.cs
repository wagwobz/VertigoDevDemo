using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HorizontalLayoutGroup))]
public class UiLevelScrollView : MonoBehaviour
{
    public RectTransform viewport;
    [SerializeField] int _currentLevel = 12;
    float _childObjectWidth = 100f;
    HorizontalLayoutGroup _layout;

    void Awake()
    {
        _layout = GetComponent<HorizontalLayoutGroup>();
    }

    void Start()
    {
        AddPadding();
    }

    void AddPadding()
    {
        var paddingLeft = (_childObjectWidth * (_currentLevel - 1) + _currentLevel * _layout.spacing);
        if (_currentLevel > 10)
        {
            _layout.padding.left = 0;
            return;
        }
        float halfViewport = viewport.rect.width / 2;
        _layout.padding.left = Mathf.RoundToInt(halfViewport - paddingLeft);
        LayoutRebuilder.ForceRebuildLayoutImmediate(viewport);
    }
    
}