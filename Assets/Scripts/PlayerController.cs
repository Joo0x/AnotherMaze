using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public PlayerActionsInput _input;
    [SerializeField] private float _pitchSpeed = 60.0f;
    [SerializeField] private float _rotateSpeed = 60.0f;
    [SerializeField] private float _lerpSpeed = 0.25f;
    [SerializeField] private float _movespeed = 30.0f;

    public Transform CameerChaser;

    private float _cameraPitch = 0.0f;
    private Rigidbody _rigidbody;
    
    //private CharacterController _characterController;

     Vector3 _playerMoveInput;
     Vector3 _playerLookInput;
     Vector3 _previousPlayerLookInput;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //_characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {

        _playerLookInput = GetLookInput();
        _playerMoveInput = GetMoveInput();

        PlayerLook();
        PitchCamera();
        PlayerMove();

        _rigidbody.AddRelativeForce(_playerMoveInput,ForceMode.Force);
    }

    private void PitchCamera()
    {
        Vector3 rotateValues = CameerChaser.rotation.eulerAngles;
        _cameraPitch += _playerLookInput.y * _pitchSpeed;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -89.9f, 89.9f);

        CameerChaser.rotation = Quaternion.Euler(_cameraPitch, rotateValues.y, rotateValues.z);

    }

    private void PlayerLook()
    {
        _rigidbody.rotation = Quaternion.Euler(0.0f,_rigidbody.rotation.eulerAngles.y + (_playerLookInput.x * _rotateSpeed),0.0f);
    }

    Vector3 GetMoveInput()
    {
        return new Vector3(_input.MoveInput.x,0.0f ,_input.MoveInput.y);
    }
    Vector3 GetLookInput()
    {
        _previousPlayerLookInput = _playerLookInput;
        _playerLookInput = new Vector3(_input.LookInput.x,
            (_input.InvertedY ? -_input.LookInput.y : _input.LookInput.y), 0.0f);
        return Vector3.Lerp(_previousPlayerLookInput,_playerLookInput * Time.deltaTime ,_lerpSpeed);
    }

    void PlayerMove()
    {
        _playerMoveInput = (new Vector3(_playerMoveInput.x * _movespeed * _rigidbody.mass,_playerMoveInput.y
            ,_playerMoveInput.z * _movespeed * _rigidbody.mass
        ));
    }
}
