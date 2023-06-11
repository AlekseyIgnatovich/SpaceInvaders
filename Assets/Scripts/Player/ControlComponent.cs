using System;
using UnityEngine;
using Zenject;

public class ControlComponent : MonoBehaviour
{
    private const float BorderOffset = 0.3f;
    
    public event Action OnShot;

    [SerializeField] private float speed = 1f;

    private LevelBorders _levelBorders;

    [Inject]
    private void Construct(LevelBorders levelBorders)
    {
        _levelBorders = levelBorders;
    }

    private void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        var step = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            x += step;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            x -= step;
        }

        if (Input.GetKey(KeyCode.W))
        {
            y += step;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            y -= step;
        }

        x = Mathf.Clamp(x, -_levelBorders.Width + BorderOffset, _levelBorders.Width - BorderOffset);
        y = Mathf.Clamp(y, -_levelBorders.Height + BorderOffset, _levelBorders.Height - BorderOffset);

        transform.position = new Vector3(x, y, 0);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            OnShot?.Invoke();
        }
    }
}
