using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAnimation : MonoBehaviour
{
    [SerializeField] private Health _health;

    /// <summary>
    /// ���������� ����������� �� � ������ ����
    /// </summary>
    public void Begin()
    {
        _health.Begin();
    }

    /// <summary>
    /// ���������� ���������� �� � ������ ����
    /// </summary>
    public void OpenHeart()
    {
        _health.OpenHeart();
    }
}
