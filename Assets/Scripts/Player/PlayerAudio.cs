using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public static PlayerAudio m_Instance;
    public AudioClip[] m_JumpAudioClips;
    public AudioClip[] m_LandAudioClips;
    public AudioClip[] m_StepAudioClips;
    public AudioClip m_DeathAudioClip;

    float currentFrameFootstepLeft;
    float currentFrameFootstepRight;
    float lastFrameFootstepLeft;
    float lastFrameFootstepRight;

    AudioSource audioSource;
    Animator animator;

	void Start ()
    {
        m_Instance = this;
        audioSource = GetComponentInParent<AudioSource>();
        animator = GetComponent<Animator>();
	}

    void Update()
    {
        if(PlayerController.m_Instance.m_IsGrounded)
            UpdateFootstepAudio();
    }

    void UpdateFootstepAudio()
    {
        currentFrameFootstepLeft = animator.GetFloat("FootstepLeft");
        if (currentFrameFootstepLeft > 0 && lastFrameFootstepLeft < 0)
        {
            PlayStepAudioClip();
        }
        lastFrameFootstepLeft = animator.GetFloat("FootstepLeft");


        currentFrameFootstepRight = animator.GetFloat("FootstepRight");
        if (currentFrameFootstepRight < 0 && lastFrameFootstepRight > 0)
        {
            PlayStepAudioClip();
        }
        lastFrameFootstepRight = animator.GetFloat("FootstepRight");
    }

    public void PlayStepAudioClip()
    {
        audioSource.PlayOneShot(m_StepAudioClips[Random.Range(0, m_StepAudioClips.Length)], 0.2f);
    }

    public void PlayJumpAudioClip()
    {
        audioSource.PlayOneShot(m_JumpAudioClips[Random.Range(0, m_JumpAudioClips.Length)], 0.2f);
    }

    public void PlayLandAudioClip()
    {
        audioSource.PlayOneShot(m_LandAudioClips[Random.Range(0, m_LandAudioClips.Length)], 0.2f);
    }
}
