using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FootstepNoiseScript : MonoBehaviour
{
    private CharacterController characterController;
    private AudioSource audioSource;
    public AudioClip[] footstepSounds;
    public float stepInterval = 0.5f;
    private float nextStepTime;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        if (footstepSounds.Length == 0)
        {
            Debug.LogError("No footstep sounds assigned to the FootstepSounds script!");
            enabled = false;
        }
    }
    private void Awake()
    {
       //SoundSystem.instance.PlaySound("Crunch");
    }
    private void Update()
    {
        PlayFootstepSounds();
    }

    private void PlayFootstepSounds()
    {
        if (!characterController.isGrounded)
            return;

        // Check if enough time has passed since the last footstep sound
        if (Time.time > nextStepTime)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            AudioClip randomFootstepSound = footstepSounds[randomIndex];

            // Play the footstep sound
            // audioSource.PlayOneShot(randomFootstepSound);
            SoundSystem.instance.PlaySound("Crunch");
            // Set the next time a footstep sound can be played
            nextStepTime = Time.time + stepInterval;
        }
    }
}