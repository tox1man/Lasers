using UnityEngine;

public class TileObjectView : GameObjectView
{
    [Range(0.1f,  1f)] public float WaveAmplitude;
    [Range(0.1f, 10f)] public float Frequency;
    public float Phase;
    public Vector2Int Coordinates { get; set; }
}
