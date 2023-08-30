using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioListener _audioListener;

    public void ChangeAuidoListener()
    {
        _audioListener.enabled = !_audioListener.enabled;
    }
}
