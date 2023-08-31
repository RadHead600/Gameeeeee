using UnityEngine;

public class AudioListenerController : MonoBehaviour
{
    public void ChangeAuidoListener()
    {
        if (AudioListener.volume > 0)
            AudioListener.volume = 0;
        else
            AudioListener.volume = 1;
    }
}
