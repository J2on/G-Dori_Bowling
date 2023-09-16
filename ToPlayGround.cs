using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToPlayGround : MonoBehaviour
{
    public void ToPlayGroundFunc()
    {
        SceneManager.LoadScene("PlayGround");
    }
}
