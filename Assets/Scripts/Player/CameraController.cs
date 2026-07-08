using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] ParticleSystem speedUpParticleSystem;
    [SerializeField] float minFOV = 35f;
    [SerializeField] float maxFOV = 85f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeed = 5f;

    CinemachineCamera cinemachineCamera;

    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    public void changeCameraFOV(float speedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(changeFOVRoutine(speedAmount));

        if(speedAmount > 0)
        {
            speedUpParticleSystem.Play();
        }
    }

    IEnumerator changeFOVRoutine(float speedAmount)
    {
        float startFOV = cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount * zoomSpeed,minFOV,maxFOV);

        float elapsedTime = 0f;
        while (elapsedTime < zoomDuration)
        {
            float t = elapsedTime / zoomDuration;
            elapsedTime += Time.deltaTime;

            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV,targetFOV,t);
            yield return null;
        }

        cinemachineCamera.Lens.FieldOfView = targetFOV; // very important code for lerping between two numbers.
    
    }
}
