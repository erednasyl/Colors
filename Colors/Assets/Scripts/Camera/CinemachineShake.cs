using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance{get; private set;}

    private CinemachineVirtualCamera cvc;
    CinemachineBasicMultiChannelPerlin cbmp;
    float timer;

    void Awake(){
        Instance = this;
    }

    public void ShakeCamera(float intensity, float time){
        cvc = GetComponent<CinemachineVirtualCamera>();
        cbmp = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmp.m_AmplitudeGain = intensity;
        timer = time;
    }

    void Update(){
        if (timer > 0)
        {
            timer-=Time.deltaTime;
            if (timer <= 0f)
            {
                cbmp = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cbmp.m_AmplitudeGain = 0;
                timer = 10f;
            }
        }

    }
}
