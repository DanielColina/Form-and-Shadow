using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController m_Instance;
    public static bool m_Resetting;
    public static bool m_Paused;
    public static float m_MasterTimer;
    public AudioClip m_DeathCrushAudioClip;
    public AudioClip m_DeathDrownAudioClip;
    public AudioClip m_DeathSpikesAudioClip;

    GameObject shadowmeldResourceBar;
    GameObject pauseMenuPanel;

    void Start()
    {
        m_Instance = this;
        m_Resetting = false;
        m_Paused = false;
        m_MasterTimer = 0f;
        shadowmeldResourceBar = GameObject.Find("Shadowmeld_Resource_Bar");
        pauseMenuPanel = GameObject.Find("Pause_Menu_Panel");

        //DJC 11/12/2017 Made pause menu panel turn off only if there was a pause menu panel found (specific to Level 0)
        if(pauseMenuPanel)
            pauseMenuPanel.SetActive(false);
    }

    void Update()
    {
        UpdatePauseInput();
        if (!m_Paused && !m_Resetting)
        {
            m_MasterTimer += Time.deltaTime;
        }
        if (PlayerShadowInteraction.m_Instance.m_ShadowmeldAvailable)
            ShadowmeldUIControl();
    }

    #region UI Control
    void ShadowmeldUIControl()
    {
        shadowmeldResourceBar.GetComponent<Slider>().value = PlayerShadowInteraction.m_Instance.m_CurrentShadowmeldResource / PlayerShadowInteraction.m_Instance.m_MaxShadowmeldResource;
    }
    #endregion

    public void UpdatePauseInput()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!m_Paused)
                Pause();
            else
                Unpause();
        }
    }

    public void Pause()
    {
        m_Paused = true;
        Time.timeScale = 0f;
        pauseMenuPanel.SetActive(true);
        EventSystem es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(null);
        es.SetSelectedGameObject(es.firstSelectedGameObject);
    }

    public void Unpause()
    {
        m_Paused = false;
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
    }

    public void LoadLevelByName(string levelName)
    {
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }

    public void Respawn(string deathType)
    {
        StartCoroutine(HandleRespawn(deathType));
    }

    IEnumerator HandleRespawn(string deathType)
    {
        m_Resetting = true;
        if (m_Paused)
        {
            Unpause();
            m_Paused = false;
        }

        foreach (ConveyorBelt belt in FindObjectsOfType<ConveyorBelt>())
        {
            belt.m_PlayerColliding = false;
        }

        PlayerShadowInteraction.m_Instance.GetComponent<Rigidbody>().useGravity = false;
        PlayerShadowInteraction.m_Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //if(!PlayerController.m_Instance.m_IsGrounded)
        //    PlayerShadowInteraction.m_Instance.transform.position -= new Vector3(0, 1.2f, 0);

        HandleDeathVisualandAudio(deathType);

        yield return new WaitForSeconds(1f);
        // Check if the player is in 2D space or shadowmelded
        switch (PlayerShadowInteraction.m_CurrentPlayerState)
        {
            case PlayerShadowInteraction.PlayerState.Shadow:
                PlayerShadowInteraction.m_Instance.ShiftOutDeath();
                break;
            case PlayerShadowInteraction.PlayerState.Shadowmelded:
                PlayerShadowInteraction.m_Instance.ExitShadowmeld();
                break;
            case PlayerShadowInteraction.PlayerState.Grabbing:
                PlayerMotor.m_Instance.m_GrabbedObjectTransform.gameObject.transform.parent = null;
                PlayerMotor.m_Instance.m_GrabbedObjectTransform.gameObject.GetComponent<PushCube>().m_Grabbed = false;
                PlayerMotor.m_Instance.m_GrabbedObjectTransform = null;
                PlayerShadowInteraction.m_CurrentPlayerState = PlayerShadowInteraction.PlayerState.Form;
                break;
        }

        PlayerMotor.m_Instance.transform.parent = null;
        PlayerAnimator.m_Instance.anim.Rebind();
        PlayerShadowInteraction.m_Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        PlayerShadowInteraction.m_Instance.transform.position = PlayerShadowInteraction.m_Instance.m_PlayerRespawnPosition;
        PlayerShadowInteraction.m_Instance.m_CurrentShadowmeldResource = PlayerShadowInteraction.m_Instance.m_MaxShadowmeldResource;
        yield return new WaitForSeconds(0.5f);
        PlayerController.m_Instance.m_PlayerCollision.enabled = true;
        PlayerShadowInteraction.m_Instance.GetComponent<Rigidbody>().useGravity = true;
        m_Resetting = false;

    }

    void HandleDeathVisualandAudio(string deathType)
    {
        PlayerAnimator.m_Instance.anim.SetTrigger("Death");
        switch (deathType)
        {
            case "Crush":
                SoundManager.m_Instance.PlaySound2DOneShot(m_DeathCrushAudioClip, 0.5f, false, 1f);
                PlayerAnimator.m_Instance.anim.SetFloat("DeathType", 0);
                break;
            case "Drown":
                SoundManager.m_Instance.PlaySound2DOneShot(m_DeathDrownAudioClip, 0.5f, true, .9f);
                PlayerAnimator.m_Instance.anim.SetFloat("DeathType", 1);
                break;
            case "Spike":
                SoundManager.m_Instance.PlaySound2DOneShot(m_DeathSpikesAudioClip, 0.5f, false, 1f);
                PlayerAnimator.m_Instance.anim.SetFloat("DeathType", 1);
                break;
            default:
                break;
        }
    }
}
