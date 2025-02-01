using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _minFOV = 20f;
    [SerializeField] private float _maxFOV = 120f;
    [SerializeField] private float _zoomDuration = 1f;
    [SerializeField] private float _zoomSpeedModifer = 2f;
    
    private CinemachineCamera _cinemachineCamera;

    private void Awake()
    {
        _cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    public void ChangeCameraFOV(float speedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOV(speedAmount));
    }

    private IEnumerator ChangeFOV(float speedAmount)
    {
        float startFOV = _cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount * _zoomSpeedModifer, _minFOV, _maxFOV);
        
        float elapsedTime = 0f;
        
        while (elapsedTime < _zoomDuration)
        {
            float deltaFOV = elapsedTime / _zoomDuration;
            elapsedTime += Time.deltaTime;
            
            _cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, deltaFOV);
            yield return null;
        }
        
        _cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
}
