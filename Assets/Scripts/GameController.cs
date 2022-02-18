using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] Transform _playerPosition;
    [SerializeField] Text _playerText;
    [SerializeField] Transform _botPosition;
    [SerializeField] Text _botText;    
    static private int _playerCount, _botCount = 0;
    static private bool _death=false;
    Vector3 _startPlayerPosition, _startBotPosition;


    private void Start()
    {
        _startPlayerPosition =  _playerPosition.position;
        _startBotPosition = _botPosition.position;
        
    }
    private void Update()
    {
        if (_death)
        {
            NewRound();
        }
        if (_playerPosition.position.y <= -1)
        {
            ReturnPlayer();
        }
    }

    private void ReturnPlayer()
    {
        _playerPosition.position = _startPlayerPosition;
        _playerPosition.rotation = Quaternion.LookRotation(Vector3.forward);
    }

    private void NewRound()
    {
        _death = false;
        _playerText.text = _playerCount.ToString();
        _botText.text = _botCount.ToString();
        _playerPosition.position = _startPlayerPosition;
        _botPosition.position = _startBotPosition;
    }
    static public void Counts(string tag)
    {
        if (tag=="Player")
        {
            _playerCount++;
                      
        }

        if (tag == "Bot")
        {
            _botCount++;
        }
        _death = true;
        
    }
    
}
