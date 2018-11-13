using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private const float INTERVAL = 3f;

    [SerializeField]
    private WipeController wipeController;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Camera wipeCamera;

    private float timer = 0f;

    private void Start()
    {
        PlayWipe();
    }

    private void PlayWipe()
    {
        wipeController.Init(wipeCamera, target, null);
        wipeController.StartWipeAnimation();
    }

    private void MoveTargetLoop(float time)
    {
        Vector3 p = new Vector3(5f * Mathf.Sin(3f * time), 0f, 0f);
        target.transform.position = p;
    }

    private void Update()
    {
        if (timer > INTERVAL) {
            PlayWipe();
            timer = 0f;
        }
        MoveTargetLoop(timer);
        timer += Time.deltaTime;
    }
}
