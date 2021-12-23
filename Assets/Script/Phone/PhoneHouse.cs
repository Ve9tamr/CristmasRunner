using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneHouse : MonoBehaviour
{
    public Transform EndPoint;

    void Start()
    {
        PhoneHouseController.Instance.OnPhoneMovement += TryDelAndAddPhone;
    }

    /// <summary>
    /// �������� � �������� ��������� ��� ����� �� ������������ ����
    /// </summary>
    private void TryDelAndAddPhone()
    {
        if (transform.position.x < PhoneHouseController.Instance.minX)
        {
            PhoneHouseController.Instance.phoneHouseBuilder.CreatPhone();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (PhoneHouseController.Instance != null)
        {
            PhoneHouseController.Instance.OnPhoneMovement -= TryDelAndAddPhone;
        }
    }
}
