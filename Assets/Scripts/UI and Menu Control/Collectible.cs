using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] int m_ScoreValue;
    [SerializeField] AudioClip collectibleAudioClip;

    void Update()
    {
        transform.Rotate(Vector3.up, 60 * Time.fixedDeltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundManager.m_Instance.PlaySound3DOneShot(transform.position, collectibleAudioClip, 0.5f, false, 0);
            gameObject.SetActive(false);
        }
    }
}
