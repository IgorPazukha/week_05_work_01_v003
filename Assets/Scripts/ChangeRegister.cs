using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRegister : MonoBehaviour
{
    [SerializeField] private ChangeVolumeAlarm _changeVolumeAlarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _changeVolumeAlarm.Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _changeVolumeAlarm.Deactivate();
        }
    }
}
