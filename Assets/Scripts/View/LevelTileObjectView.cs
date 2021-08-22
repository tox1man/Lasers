using UnityEngine;

public class LevelTileObjectView : GameObjectView
{
    [Range(0.1f,  1f)] public float WaveAmplitude;
    [Range(0.1f, 10f)] public float Frequency;
    public WaveMode Mode;
    private float _timeOffset = 0;
    private float _waveOffset;
    public Vector2Int Coordinates { get; set; }

    public enum WaveMode
    {
       Horizontal,
       Vertical,
       Diagonal,
       Fall,
       Random
    }

    public void Start()
    {
        _waveOffset = CalculateOffset(Mode);
    }

    public void Update()
    {
        if (DoAnimate)
        {
            _timeOffset += Time.deltaTime;
            WaveAnimate(Frequency, WaveAmplitude, _waveOffset);
        }
    }
    public void WaveAnimate(float frequency, float amplitude, float offset)
    {
        float value = Mathf.Sin((_timeOffset + offset) * frequency) * amplitude;
        var newPos = new Vector3(transform.position.x, value - Parameters.LEVEL_TILE_HEIGHT / 2, transform.position.z);
        transform.position = newPos;
    }

    private float CalculateOffset(WaveMode mode)
    {
        float offset;
        switch (mode)
        {
            case WaveMode.Horizontal:
                offset = Coordinates.x;
                break;
            case WaveMode.Vertical:
                offset = Coordinates.y;
                break;
            case WaveMode.Diagonal:
                offset = Coordinates.x + Coordinates.y;
                break;
            case WaveMode.Fall:
                offset = transform.position.sqrMagnitude / 10;
                WaveAmplitude = 0.1f;
                Frequency = 2;
                break;
            case WaveMode.Random:
                offset = Random.Range(0f, 1f) * 10f;
                break;
            default:
                offset = 0f;
                break;
        }
        return offset;
    }
}
