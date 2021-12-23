using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemyShadow : MonoBehaviour
{
    [SerializeField] private Material[] _mats;
    [SerializeField] private MeshRenderer _mesh;
    private int _currentMat = 0;
    private int _maxMat;
    private void Awake()
    {
        _maxMat = _mats.Length;
    }

    /// <summary>
    /// �������� ���� � ��������
    /// </summary>
    public void ShadowMat()
    {
        _mesh.material = _mats[_currentMat];
        _currentMat++;
        if (_currentMat == _maxMat)
        {
            _currentMat = 0;
        }
    }
}
