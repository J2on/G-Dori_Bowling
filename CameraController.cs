using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    private GameObject _lineCamera;
    private GameObject _characterCamera;
    private GameObject _scoreBoardCamera;




    void Start()
    {
        _lineCamera = GameObject.Find("LineCamera");
        _characterCamera = GameObject.Find("CharacterCamera");
        _scoreBoardCamera = GameObject.Find("ScoreBoardCamera");
    }

    public void ChangeTopViewCamera()
    {
        _lineCamera.GetComponent<CinemachineVirtualCamera>().Priority = 11;
        _characterCamera.GetComponent<CinemachineVirtualCamera>().Priority = 10;
        _scoreBoardCamera.GetComponent<CinemachineVirtualCamera>().Priority = 10;
    }

    public void ChangeCharacterCamera()
    {
        _characterCamera.GetComponent<CinemachineVirtualCamera>().Priority = 11;
        _lineCamera.GetComponent<CinemachineVirtualCamera>().Priority = 10;
        _scoreBoardCamera.GetComponent<CinemachineVirtualCamera>().Priority = 10;
    }

    public void ChangeScoreBoardCamera()
    {
        _characterCamera.GetComponent<CinemachineVirtualCamera>().Priority = 10;
        _lineCamera.GetComponent<CinemachineVirtualCamera>().Priority = 10;
        _scoreBoardCamera.GetComponent<CinemachineVirtualCamera>().Priority = 11;
    }
}
