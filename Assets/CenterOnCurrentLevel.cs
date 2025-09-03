using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CenterOnCurrentLevel : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform content;
    public int currentLevel = 12;
    public float snapSpeed = 10f;

    private bool dragging;

    void Start()
    {
        if (content.childCount == 0) return;
        SnapImmediatelyToLevel(currentLevel);
    }

    void Update()
    {
       
    }

    void OnMouseDown()
    {
        content.DOKill();
    }

    // // public void OnBeginDrag() => dragging = true;
    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     SnapBackToCurrent();
    // }

    public void OnMouseUp()
    {
        SnapBackToCurrent();
    }


    void SnapBackToCurrent()
    {
        RectTransform target = GetChildForLevel(currentLevel);
        if (target == null) return;

        Vector2 targetPos = GetCenteredPos(target);
        content.DOAnchorPos(targetPos, 0.2f);
        // content.anchoredPosition = Vector2.Lerp(content.anchoredPosition, targetPos, Time.deltaTime * snapSpeed);
    }

    void SnapImmediatelyToLevel(int level)
    {
        RectTransform target = GetChildForLevel(level);
        if (target == null) return;

        content.anchoredPosition = GetCenteredPos(target);
    }

    RectTransform GetChildForLevel(int level)
    {
        if (level < 1 || level > content.childCount) return null;
        return content.GetChild(level - 1) as RectTransform;
    }

    Vector2 GetCenteredPos(RectTransform target)
    {
        // World position of the child center
        Vector3 worldCenter = target.position + new Vector3(target.rect.width * 0.5f, 0, 0);

        // Convert to local position relative to content
        Vector3 localCenter = content.InverseTransformPoint(worldCenter);

        // Negate so it scrolls correctly
        float childCenter = -localCenter.x;
        return new Vector2(childCenter, content.anchoredPosition.y);
    }

}