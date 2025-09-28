using UnityEngine;
using UnityEngine.UI;

namespace styleFLASHES;

public class SFGroup : MonoSingleton<SFGroup>
{
    public CanvasGroup group;

    protected override void Awake()
    {
        GameObject canvas = GameObject.Find("/Canvas");
        group = new GameObject("SFGroup", typeof(RectTransform)).AddComponent<CanvasGroup>();
        RectTransform trans = group.gameObject.GetComponent<RectTransform>();
        trans.SetParent(canvas.transform);

        group.interactable = false;
        group.blocksRaycasts = false;

        trans.localScale = Vector3.one;
        trans.anchoredPosition = new Vector2(0f, 0f);
    }
}