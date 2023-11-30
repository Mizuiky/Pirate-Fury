using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera _camera;

    public void SetCameraTarget(Transform player)
    {
        _camera.LookAt = player;
        _camera.Follow = player;

        _camera.m_Lens.OrthographicSize = 6.5f;
    }
}
