using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private TextMeshProUGUI _scoreTextMesh;
    [SerializeField] private TextMeshProUGUI _scoreDeathMesh;
    [SerializeField] private Text _scoreDeath;

    private float _giftCount = 0;
    private float _record = 0;
    private PlayerMovement _player;

    public bool death = false;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>();
        if (Base.Hard == false)
        {
            _record = PlayerPrefs.GetFloat("Record");
        }
        else
        {
            _record = PlayerPrefs.GetFloat("HardRecord");
        }

        if (_record / 1000 >= 1)
        {
            _scoreDeath.text = $"Your Record X {_record}";
            _scoreDeathMesh.text = $"Your Record X {_record}";
        }
        else if (_record / 100 >= 1)
        {
            _scoreDeath.text = $"Your Record X 0{_record}";
            _scoreDeathMesh.text = $"Your Record X 0{_record}";
        }
        else if (_record / 10 >= 1)
        {
            _scoreDeath.text = $"Your Record X 00{_record}";
            _scoreDeathMesh.text = $"Your Record X 00{_record}";
        }
        else if (_record / 10 >= 0)
        {
            _scoreDeath.text = $"Your Record X 000{_record}";
            _scoreDeathMesh.text = $"Your Record X 000{_record}";
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Gift"))
        {
            _giftCount++;
            string numer = "";
            if(_giftCount /1000 >= 1)
            {
                 numer = $"X{_giftCount}";
            }
            else if(_giftCount/100 >= 1)
            {
                 numer = $"X0{_giftCount}";
            }
            else if (_giftCount/10 >= 1)
            {
                 numer = $"X00{_giftCount}";
            }
            else if (_giftCount /10 > 0)
            {
                 numer = $"X000{_giftCount}";
            }
            _scoreText.text = numer;
            _scoreTextMesh.text = numer;
            collision.GetComponent<Desolve>().go = true;
        }
    }

    private void Update()
    {
        if(Base.Death == true)
        {
            if(_giftCount > _record)
            {
                if (Base.Hard == false)
                {
                    PlayerPrefs.SetFloat("Record", _giftCount);
                }
                else
                {
                    PlayerPrefs.SetFloat("HardRecord", _giftCount);
                }

                if (_giftCount / 1000 >= 1)
                {
                    _scoreDeath.text = $"New Record X {_giftCount}";
                    _scoreDeathMesh.text = $"New Record X {_giftCount}";
                }
                else if (_giftCount / 100 >= 1)
                {
                    _scoreDeath.text = $"New Record X 0{_giftCount}";
                    _scoreDeathMesh.text = $"New Record X 0{_giftCount}";
                }
                else if (_giftCount / 10 >= 1)
                {
                    _scoreDeath.text = $"New Record X 00{_giftCount}";
                    _scoreDeathMesh.text = $"New Record X 00{_giftCount}";
                }
                else if (_giftCount / 10 >= 0)
                {
                    _scoreDeath.text = $"New Record X 000{_giftCount}";
                    _scoreDeathMesh.text = $"New Record X 000{_giftCount}";
                }
            }
            else if (_giftCount == _record || _giftCount < _record)
            {
                if (_giftCount / 1000 >= 1)
                {
                    _scoreDeath.text = $"Your Score X {_giftCount}";
                    _scoreDeathMesh.text = $"Your Score X {_giftCount}";
                }
                else if (_giftCount / 100 >= 1)
                {
                    _scoreDeath.text = $"Your Score X 0{_giftCount}";
                    _scoreDeathMesh.text = $"Your Score X 0{_giftCount}";
                }
                else if (_giftCount / 10 >= 1)
                {
                    _scoreDeath.text = $"Your Score X 00{_giftCount}";
                    _scoreDeathMesh.text = $"Your Score X 00{_giftCount}";
                }
                else if (_giftCount / 10 >= 0)
                {
                    _scoreDeath.text = $"Your Score X 000{_giftCount}";
                    _scoreDeathMesh.text = $"Your Score X 000{_giftCount}";
                }
            }
        }
    }

    /// <summary>
    /// ���������� ������
    /// </summary>
    public void Death()
    {
        death = true;
    }

    /// <summary>
    /// ���������� ��������� �������� ������
    /// </summary>
    public void EndCrouch()
    {
        _player.EndCrouch();
    }

    /// <summary>
    /// ���������� ��������� ���������� �� ����� ������
    /// </summary>
    public void BigJumping()
    {
        _player.BigJumping();
    }
}
