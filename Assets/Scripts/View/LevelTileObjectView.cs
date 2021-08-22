using System.Collections;
using UnityEngine;

public class LevelTileObjectView : GameObjectView
{
    [Range(0f,1f)] public float WaveSize;
    private float _creationTime;
    public Vector2Int Coordinates { get; private set; }

    public void Awake()
    {
    }

    public void Update()
    {
        if(DoAnimate)
        {
            _creationTime = Time.realtimeSinceStartup;
            AnimateLocal(-0.5f, 0.5f, Coordinates.x);
        }
    }
    public void AnimateLocal(float min, float max, float timeOffset)
    {
        float offset =  _creationTime;
        //Debug.Log(_creationTime);
        float value = Mathf.Sin(_creationTime * 10) > 0 ? WaveSize : -WaveSize;
        //Debug.Log(value);
        transform.position += Vector3.up * value;
        //Debug.Log(Time.time);
    }
}
