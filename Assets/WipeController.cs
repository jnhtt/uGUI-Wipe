using System;
using UnityEngine;
using UnityEngine.UI;

public class WipeController : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private WipeEffect wipeEffect;

    private Action onFinish;
    private bool isFinish;
    private bool ready;

    private void Awake()
    {
        GetComponent<Canvas>().sortingOrder = 10000;
    }

    public void Init(Camera cam, Transform target, Action onFinish)
    {
        ready = false;
        isFinish = false;
        canvasGroup.alpha = 0f;
        this.onFinish = onFinish;
        wipeEffect.Init(cam, target, 2f);
    }

    public void StartWipeAnimation()
    {
        ready = true;
        canvasGroup.alpha = 0f;
    }

    public void SetOnFinish(Action onFinish)
    {
        this.onFinish = onFinish;
    }

    private void Update()
    {
        if (!ready) {
            return;
        }

        if (0f <= wipeEffect.Radius) {
            float delta = Time.deltaTime;
            canvasGroup.alpha += delta;
            wipeEffect.Radius -= delta;
            wipeEffect.UpdateMaterial();
        } else {
            if (onFinish != null && !isFinish) {
                onFinish();
                isFinish = true;
            }
        }
    }
}
