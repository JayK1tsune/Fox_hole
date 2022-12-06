using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource _volume;

    private static MusicManager musicManagerInstance;
    private void Awake() {
        DontDestroyOnLoad(this);
        _volume = GetComponent<AudioSource>();
        if (musicManagerInstance == null){
            musicManagerInstance = this;
        }
        else{
            Destroy(gameObject);
        }
    }


}
