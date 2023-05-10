using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Oculus.Interaction.Input;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class QueenHandler : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;

    [SerializeField] private Transform _target;
    [SerializeField] private ParticleSystem _teleportParticle;
    
    // Hashes for animation
    private int _isRunningHash;
    private int _isDeadHash;

    // Audios
    [Header("Audio")]
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _foundTargetAudio;
    [SerializeField] private AudioClip _startTeleportAudio;
    [SerializeField] private AudioClip _endTeleportAudio;
    [SerializeField] private AudioClip _waitTeleportAudio;

    private bool isWaitTeleportAudioPlayed = false;
    private bool isFoundTargetAudioPlayed = false;
    
    // Timers for audio cooldown
    private ActionOnTimer _waitTeleportAudioTimer;
    private ActionOnTimer _foundTargetAudioTimer;
    private float timerCooldownSeconds = 10.0f;

    
    IEnumerator Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _teleportParticle.Stop();
        _isRunningHash = Animator.StringToHash("isRunning");
        _audioSource.loop = false;

        // Timers for audio cooldown
        _waitTeleportAudioTimer = gameObject.AddComponent<ActionOnTimer>();
        _foundTargetAudioTimer = gameObject.AddComponent<ActionOnTimer>();

        // Movement for crossing nav mesh link
        _agent.autoTraverseOffMeshLink = false;
        while (true)
        {
            if (_agent.isOnOffMeshLink)
            {
                if (!_audioSource.isPlaying && TargetOutsideMeshLink())
                {
                    yield return StartCoroutine(CrossAfterSeconds(_agent, 3.0f));
                }
                else
                {
                    if (!_audioSource.isPlaying && !isWaitTeleportAudioPlayed) {
                        _audioSource.PlayOneShot(_waitTeleportAudio);
                        isWaitTeleportAudioPlayed = true;
                        _waitTeleportAudioTimer.SetTimer(timerCooldownSeconds, () => { isWaitTeleportAudioPlayed = false; });
                    }
                }
            }
            yield return null;
        }
    }
    

    void Update()
    {
        // The target who the queen will chase
        _agent.SetDestination(_target.position);
        
        // Control the animations
        bool isRunning = _animator.GetBool(_isRunningHash);
        
        if (!isRunning && HasVelocity())
        {
            _animator.SetBool(_isRunningHash, true);
        }

        if (isRunning && !HasVelocity())
        {
            _animator.SetBool(_isRunningHash, false);

            if (!_audioSource.isPlaying && !isFoundTargetAudioPlayed) {
                _audioSource.PlayOneShot(_foundTargetAudio);
                isFoundTargetAudioPlayed = true;
                _foundTargetAudioTimer.SetTimer(timerCooldownSeconds, () => { isFoundTargetAudioPlayed = false; });
            }
        }
    }
    
    private bool HasVelocity()
    {
        return _agent.velocity.sqrMagnitude > Mathf.Epsilon;
    }


    private bool TargetOutsideMeshLink()
    {
        const float safeDistance = 5f;
        OffMeshLinkData data = _agent.currentOffMeshLinkData;
        Vector3 startPosition = _agent.transform.position;
        Vector3 endPosition = data.endPos;
        Vector3 targetPosition = _target.position;
        bool isOutsideStartPosition = Vector3.Distance(startPosition, targetPosition) > safeDistance;
        bool isOutsideEndPosition = Vector3.Distance(endPosition, targetPosition) > safeDistance;
        return isOutsideStartPosition && isOutsideEndPosition;
    }

    IEnumerator CrossAfterSeconds(NavMeshAgent agent, float delaySeconds)
    {
        if (!_teleportParticle.isPlaying) {
            _teleportParticle.Play();
        }
        if (!_audioSource.isPlaying) {
            _audioSource.PlayOneShot(_startTeleportAudio);
        }
        yield return new WaitForSeconds(delaySeconds);
        agent.CompleteOffMeshLink();
        if (!_audioSource.isPlaying) {
            _audioSource.PlayOneShot(_endTeleportAudio);
        }
        _teleportParticle.Stop();
    }
    
}
