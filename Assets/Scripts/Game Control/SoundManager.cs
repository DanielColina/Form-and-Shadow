using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager m_Instance;
    public AudioClip m_CurrentLevelMusic;
    [System.Serializable]
    public struct AmbientObjectAudio
    {
        public GameObject ambientObject;
        public AudioClip ambientAudioClip;
        public bool ambienceIs2D;
        public float ambientPriority;
        public float ambientVolume;
        public float ambientMinDistance;
        public float ambientMaxDistance;
    }
    public AmbientObjectAudio[] m_AmbientAudioObjects;

    public ObjectPooler audio2DPool;
    public ObjectPooler audio3DPool;
    public ObjectPooler audioAmbientPool;

	void Awake ()
    {
        m_Instance = this;
        PlaySoundAmbient(true, Vector3.zero, m_CurrentLevelMusic, 127, 0.15f, 1, 500);
        foreach (AmbientObjectAudio ambientAudioObject in m_AmbientAudioObjects)
        {
            PlaySoundAmbient(ambientAudioObject.ambienceIs2D, ambientAudioObject.ambientObject.transform.position, ambientAudioObject.ambientAudioClip, ambientAudioObject.ambientPriority,
                ambientAudioObject.ambientVolume, ambientAudioObject.ambientMinDistance, ambientAudioObject.ambientMaxDistance);
        }
	}
	
    public void PlaySound2DOneShot(AudioClip newClip, float newVolume, bool manualPitch, float newPitch)
    {
        GameObject audioObject = audio2DPool.GetPooledObject();
        AudioSource audioSource = audioObject.GetComponent<AudioSource>();

        audioObject.SetActive(true);
        audioSource.clip = newClip;
        audioSource.volume = newVolume;
        if (manualPitch)
            audioSource.pitch = newPitch;
        else
            audioSource.pitch = 1;

        audioSource.Play();
        StartCoroutine(DisableSoundOnEnd(audioObject, audioSource));
    }

    public void PlaySound3DOneShot(Vector3 playLocation, AudioClip newClip, float newVolume, bool manualPitch, float newPitch)
    {
        GameObject audioObject = audio3DPool.GetPooledObject();
        AudioSource audioSource = audioObject.GetComponent<AudioSource>();

        audioObject.SetActive(true);
        audioObject.transform.position = playLocation;
        audioSource.clip = newClip;
        audioSource.volume = newVolume;
        if (manualPitch)
            audioSource.pitch = newPitch;
        else
            audioSource.pitch = 1;
        audioSource.Play();
        StartCoroutine(DisableSoundOnEnd(audioObject, audioSource));
    }

    public void PlaySoundAmbient(bool audioIs2D, Vector3 playLocation, AudioClip newClip, float newPriority, float newVolume, float newMinDistance, float newMaxDistance)
    {
        GameObject audioObject = audioAmbientPool.GetPooledObject();
        AudioSource audioSource = audioObject.GetComponent<AudioSource>();

        audioObject.SetActive(true);
        audioObject.transform.position = playLocation;
        audioSource.clip = newClip;
        audioSource.volume = newVolume;
        if (audioIs2D)
            audioSource.spatialBlend = 0f;
        else
            audioSource.spatialBlend = 1f;
        audioSource.minDistance = newMinDistance;
        audioSource.maxDistance = newMaxDistance;

        audioSource.Play();
    }

    IEnumerator DisableSoundOnEnd(GameObject audioObject, AudioSource audioSource)
    {
        if(audioSource.clip != null)
        {
            yield return new WaitForSeconds(audioSource.clip.length);
            audioObject.SetActive(false);
        }
        else
        {
            audioObject.SetActive(false);
        }
    }
}
