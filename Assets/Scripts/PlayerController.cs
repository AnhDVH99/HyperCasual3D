using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float playerSpeed = 6f;
    private float xSpeed;
    private float maxX = 4.37f;
    private bool isPlayerMoving;
    [SerializeField] private GameObject headBoxGO;
    private ScaleCalculate scaleCalculate;
    private MeshRenderer headBoxRenderer;
    [SerializeField] private Material obstacleCollideMat;
    private Material currentHeadMat;
    private Animator playerAnim;
    public AudioSource playerAudioSource;
    public AudioClip gateClip, colorBoxClip, ObstacleClip, successClip;
    void Start()
    {
        scaleCalculate = new ScaleCalculate();
        headBoxRenderer = headBoxGO.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        currentHeadMat = headBoxRenderer.material;
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        float touchX = 0;
        float newXValue;
        if (isPlayerMoving == false)
        {
            return;
        }
        
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            xSpeed = 1000f;
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }

        else if (Input.GetMouseButton(0))
        {
            xSpeed = 1000f;
            touchX = Input.GetAxis("Mouse X");
        }
        newXValue = transform.position.x + xSpeed * touchX * Time.deltaTime;
        newXValue = Mathf.Clamp(newXValue, -maxX, maxX);
        Vector3 playerNewPostion = new Vector3(newXValue, transform.position.y, transform.position.z + playerSpeed * Time.deltaTime);
        transform.position = playerNewPostion;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FinishLine")
        {
            isPlayerMoving = false;
            idleAnim();
            GameManager.instance.ShowSuccessMenu();
            PlayAudio(successClip, 0.6f);
            StopBackgroundMusic();
        }
    }

    public void PassedGate(GateType gateType, int gateValue)
    {
        // change size of headbox according to Gate type and value
        headBoxGO.transform.localScale = scaleCalculate.CalculatePlayerHeadSize(gateType, gateValue, headBoxGO.transform);
        PlayAudio(gateClip, 0.6f);
    }

    public void TouchedToColorBox(Material boxMat)
    {
        // color ninja headbox 
        headBoxRenderer.material = boxMat;
        currentHeadMat = boxMat;
        PlayAudio(colorBoxClip, 0.6f);
    }

    public void TouchedToObstacle()
    {
        headBoxGO.transform.localScale = scaleCalculate.DecreasePlayerHeadSize(headBoxGO.transform);
        StartCoroutine(StartRedBlinkEffect());
        PlayAudio(ObstacleClip, 0.6f);
    }

    private IEnumerator StartRedBlinkEffect()
    {
        
        for (int i = 0; i < 2; i++)
        {
            // Blink to red
            headBoxRenderer.material = obstacleCollideMat;
            yield return new WaitForSeconds(0.2f);

            // Return to normal color
            headBoxRenderer.material = currentHeadMat;
            yield return new WaitForSeconds(0.2f); // Adjust this if needed for timing
        }
    }

    public void GameStarted()
    {
        isPlayerMoving = true;
        runningAnim();
    }

    private void runningAnim()
    {
        playerAnim.SetBool("isIdle", false);
        playerAnim.SetBool("isRunning", true);
    }

    private void idleAnim()
    {
        playerAnim.SetBool("isRunning", false);
        playerAnim.SetBool("isIdle", true);
    }

    private void PlayAudio(AudioClip audio, float volume)
    {
        playerAudioSource.PlayOneShot(audio, volume);
    }

    private void StopBackgroundMusic()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
    }
    
}
