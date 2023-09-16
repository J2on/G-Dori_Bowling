using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    
    private bool _isPinSet;
    private bool _isBallSet;

    private GameObject _ball;
    private GameObject _character;
    private GameObject _cameraController;
    private GameObject _scoreBoard;

    public enum state
    {
        play,
        animation,
        set,
        end
    }
    public enum cameraState
    {
        top,
        character,
        scoreBoard
    }

    private state _gameState;

    private GameObject _pin;

    private cameraState _camState;
   

    bool isBallThrown = false;
    

    private float _time;
    public GameObject ballPrefab;
    private GameObject _ballSocket;

    private float _animationTime;

    private int _attempt;

    private int _frame;
    private int _currentScore;
    private int _preScore = 0;


    private GameObject _actionButton;

    void Start()
    {
        _gameState = state.set;

        _isPinSet = false;
        _isBallSet = false;

        //_ball = Instantiate(ballPrefab);
        _character = GameObject.Find("Mouse");

        _pin = GameObject.Find("pinManager");

        _cameraController = GameObject.Find("CameraController");

        _scoreBoard = GameObject.Find("ScoreBoardCanvas");

        
        _actionButton = GameObject.Find("ActionButton");


        _camState = cameraState.character;

        _attempt = 1;
        _frame = 1;
    }


    void Update()
    {

        if(_gameState == state.set)
        {
            
            if (!_isPinSet)
            {
                
                _pin.GetComponent<Pin>().SetPinList1();
                _pin.GetComponent<Pin>().SetPinList2();
                
                _isPinSet = true;
            }

            if (!_isBallSet)
            {
                _ball = Instantiate(ballPrefab);
                _isBallSet = true;
            }


            if (Input.GetKeyDown(KeyCode.Space) || _actionButton.GetComponent<ButtonScript>().isButtonDown())
            {
                _character.GetComponent<CharacterMover>().ThrowBallAnimation();
                _gameState = state.animation;
                _animationTime = 0f;
            }
            else
            {
                _ball.GetComponent<Ball>().BallStayAtPlayerHand(_ball);
            }
        }
        else if(_gameState == state.animation)
        {
            if(_animationTime > 0.97f)
            {
                _gameState = state.play;
            }
            else
            {
                _ball.GetComponent<Ball>().BallStayAtPlayerHand(_ball);
                _animationTime += Time.deltaTime;
            }
        }
        else if(_gameState == state.play)
        {
            _animationTime += Time.deltaTime;
            if(isBallThrown == false)
            {
                
                _ball.GetComponent<Ball>().ThrowBall();
                isBallThrown = true;
                _time = 0f;
            }
            else
            {
                _time += Time.deltaTime;
            }

            if(_time > 1f && _camState == cameraState.character)
            {
                _cameraController.GetComponent<CameraController>().ChangeTopViewCamera();
                _camState = cameraState.top;
            }
            else if (_time > 8f)
            {
                if(_camState == cameraState.top)
                {
                    _preScore = _currentScore;
                    _currentScore = _pin.GetComponent<Pin>().HowManyGetScore();


                    _scoreBoard.GetComponent<ScoreBoard>().ScoreBoardUpdate(_frame, _attempt, _currentScore, _preScore);
                    _cameraController.GetComponent<CameraController>().ChangeScoreBoardCamera();
                    _camState = cameraState.scoreBoard;
                }
                else if(_time > 11f)
                {
                    _gameState = state.set;

                    isBallThrown = false;
                    _isBallSet = false;

                    if (_attempt == 1)
                    {
                        _attempt += 1;
                    }
                    else
                    {

                        _isPinSet = false;
                        _pin.GetComponent<Pin>().DeletePinList1();
                        _pin.GetComponent<Pin>().DeletePinList2();
                        _attempt = 1;
                        _frame += 1;

                        if (_frame == 6)
                        {
                            print("GameEnd");
                            _scoreBoard.GetComponent<ScoreBoard>().GameEndUI();
                            _gameState = state.end;
                        }
                    }
                    _character.transform.position = new Vector3(55f, 3f, 12.5f);
                    _ball.GetComponent<Ball>().DeleteBall(_ball);

                    _cameraController.GetComponent<CameraController>().ChangeCharacterCamera();
                    _camState = cameraState.character;
                }
                

                
            }
        }
       

    }
}
