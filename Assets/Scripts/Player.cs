using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve _forwardCurve;

    [SerializeField]
    private AnimationCurve _sideCurve;

    [SerializeField]
    private GameRestarter _gameRestarer;
    
    [SerializeField]
    private ScoreCounter _scoreCounter;
    
    [SerializeField]
    private CameraFollow _cameraFollow;
    
    [SerializeField]
    private GameObject _particle;

    private bool _isFalling; //not to increment score when falling
    private Vector3 _currentStep;
    private Vector2 _startTouchPosition;
    private Vector2 _finalTouchPosition;

    void Start()
    {
        _currentStep = new Vector3(0,0.75f,-3);
    }

    void Update()
    {
        if (Input.touchCount > 0 && !_isFalling)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                _startTouchPosition = touch.position;
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                _finalTouchPosition = touch.position;
                ChooseJump();
            }
        }
        if (transform.position.z > 3f || transform.position.z < -3) //if player is out of stair bounds
        {
            _isFalling = true;
            StartCoroutine(DeathByFall());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Death();
        }
    }

    private void ChooseJump()
    {
        Vector2 deltaTouch;
        deltaTouch = _finalTouchPosition - _startTouchPosition;
        if (Mathf.Abs(deltaTouch.x) > 20)
        {
            if (_finalTouchPosition.x < _startTouchPosition.x)
                StartCoroutine(IJumpSide(true));
            else
                StartCoroutine(IJumpSide(false));
        }
        else
        {
            StartCoroutine(IJumpForward());
            FindObjectOfType<StairwaySpawner>().SpawnStairs();
        }
    }

    private IEnumerator IJumpForward()
    {
        Vector3 desiredPos = _currentStep + new Vector3(1, 1, 0);
        Vector3 startPos = _currentStep;
        _currentStep = desiredPos;
        for (int i = 0; i < 26; i++)
        {
            float deltaCurve = _forwardCurve.Evaluate(i * 0.04f) - _forwardCurve.Evaluate(i * 0.04f - 0.04f);
            Vector3 pos = Vector3.Lerp(startPos, desiredPos, i * 0.04f);
            Vector3 deltaX = pos - Vector3.Lerp(startPos, desiredPos, i * 0.04f - 0.04f);
            transform.position += new Vector3(deltaX.x, deltaCurve, 0);
            yield return new WaitForSeconds(0.01f);
        }
        _scoreCounter.IncreaseScore();
        yield return null;
    }

    private IEnumerator IJumpSide(bool rightSide)
    {
        Vector3 desiredPos;
        if (rightSide == true)
            desiredPos = _currentStep + new Vector3(0, 0, 1);
        else
            desiredPos = _currentStep + new Vector3(0, 0, -1);
        Vector3 startPos = _currentStep;
        _currentStep = desiredPos;
        for (int i = 0; i < 26; i++)
        {
            float deltaCurve = _sideCurve.Evaluate(i * 0.04f) - _sideCurve.Evaluate(i * 0.04f - 0.04f);
            Vector3 pos = Vector3.Lerp(startPos, desiredPos, i * 0.04f);
            Vector3 deltaZ = pos - Vector3.Lerp(startPos, desiredPos, i * 0.04f - 0.04f);
            transform.position += new Vector3(0, deltaCurve, deltaZ.z);
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }

    private void Death()
    {
        _particle.transform.position = transform.position;
        _particle.SetActive(true);
        _gameRestarer.RestartPanelAppear();
        gameObject.SetActive(false);
    }

    IEnumerator DeathByFall()
    {
        yield return new WaitForSeconds(0.15f);
        _cameraFollow.enabled = false;
        GetComponent<Rigidbody>().AddForce(new Vector3(0,-3,0), ForceMode.VelocityChange);
        yield return new WaitForSeconds(1);
        _gameRestarer.RestartPanelAppear();
        gameObject.SetActive(false);
        yield return null;
    }
}