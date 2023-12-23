using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class CameraSwitcher : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    public void StartCameraSwitch()
    {
        StartCoroutine(CameraSwitch());
    }

    public IEnumerator CameraSwitch()
    {
        // Camera 1'i devre dışı bırak
        cam1.gameObject.SetActive(false);

        // Camera 2'yi etkinleştir
        cam2.gameObject.SetActive(true);

        yield return null; // Bir frame bekle
    }
}
