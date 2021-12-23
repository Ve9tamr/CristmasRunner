using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private Animator _anima;
    private bool _restart = false;

    private void Awake()
    {
        _anima = GetComponent<Animator>();
    }

    private void Start()
    {
        Base.Speed = 0;
    }

    /// <summary>
    /// ���������� ������ ����� ����� ��� ��������� ���
    /// </summary>
    /// <param name="var"></param>
    public void StartCrossfade(bool var)
    {
        _anima.SetTrigger("End");
        _restart = var;
    }

    /// <summary>
    /// ���������� �������� �� ����� �����
    /// </summary>
    public void EndScene()
    {
        if(_restart == false)
        {
            if(Base.Game == false)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /// <summary>
    /// ���������� �������� �������������� 
    /// </summary>
    public void EndCrossfade()
    {
        Base.Speed = PlayerPrefs.GetFloat("HardLevel");
    }
}
