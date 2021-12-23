using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    public WorldBuilder worldBuilder;

    public float minX = -1;

    public delegate void TryToDelAndAddPhone();
    public event TryToDelAndAddPhone OnPhoneMovement;

    public static PlatformController Instance;

    private void Awake()
    {
        if (PlatformController.Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        PlatformController.Instance = this;
    }

    private void OnDestroy()
    {
        PlatformController.Instance = null;
    }

    void Start()
    {
        StartCoroutine(OnPhoneMovementCorutine());
    }

    void Update()
    {
        if (Base.Death == false)
        {
            if (Base.Pause == false)
            {
                transform.position -= Vector3.right * speed * Base.Speed * Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// ���������� ����� ���������
    /// </summary>
    /// <returns></returns>
    IEnumerator OnPhoneMovementCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (OnPhoneMovement != null)
            {
                OnPhoneMovement();
            }
        }
    }
}
