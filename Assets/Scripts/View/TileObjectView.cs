using UnityEngine;

public class TileObjectView : GameObjectView
{
    [Range(0.1f,  1f)] public float WaveAmplitude;
    [Range(0.1f, 10f)] public float Frequency;
    [Range(-32f, 32f)] public float Elevation = 0;
    public float Phase;
    private bool elevated;
    private float elevationAmount;
    public bool Elevated 
    { 
        get { return elevated; } 
        set 
        {
            if (elevated == value) 
            {
                return;
            }
            else
            {
                elevationAmount = Parameters.GetRoot().CurrentStage.Level.GridSize;

                Elevation = value ? Elevation + elevationAmount : Elevation - elevationAmount;
                elevated = value;
            }
        } 
    }
    public Vector2Int Coordinates { get; set; }
    /// <summary>
    /// Animate tile in sin-wave.
    /// </summary>
    /// <param name="frequency"></param>
    /// <param name="amplitude"></param>
    /// <param name="offset"></param>
    /// <param name="phase"></param>
    public void AnimateTile(float offset)
    {
        float value = Mathf.Sin((offset + Phase) * Frequency) * WaveAmplitude;
        var newPos = new Vector3(Transform.position.x, Elevation + value, Transform.position.z);
        Transform.position = newPos;
    }
    public void ColorTile(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}
