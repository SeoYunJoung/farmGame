using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{

    [SerializeField]
    Vector3 cameraPosition;
    [SerializeField]
    float cameraMoveSpeed;

    [SerializeField]
    Vector2 minCameraBoundary;
    [SerializeField]
    Vector2 maxCameraBoundary;

    public GameObject player;

    private void Update()
    {
        CameraMove();
    }

    //카메라 플레이어 추적
    private void CameraMove()
    {
        
        if (player != null)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + cameraPosition,
                                  cameraMoveSpeed);

            transform.position = LimitCameraArea(transform.position);
        }

    }

    //카메라 범위 지정
    private Vector3 LimitCameraArea(Vector3 position)
    {
        return new Vector3(
        Mathf.Clamp(transform.position.x, minCameraBoundary.x, maxCameraBoundary.x),
        Mathf.Clamp(transform.position.y, minCameraBoundary.y, maxCameraBoundary.y),
        -10
        );
    }
}
