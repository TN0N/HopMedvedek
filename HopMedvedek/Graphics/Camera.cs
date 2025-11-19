using Microsoft.Xna.Framework;

namespace HopMedvedek.Graphics;

public class Camera
{
    protected float _position;
    protected float _zoom;
    protected float _aspectRatio;

    public Matrix View => Matrix.CreateTranslation(-160, -_position, 0);

    public Matrix Projection => Matrix.CreateOrthographic(280 / _zoom, -280 / _aspectRatio / _zoom, 0, 1);

    public Camera()
    {
        _zoom = 1;
        _aspectRatio = 1.0f / 1.0f;
    }

    public float Position
    {
        get => _position;
        set => _position = value;
    }
    public float Zoom
    {
        get => _zoom;
        set => _zoom = value;
    }
    public float AspectRatio
    {
        get => _aspectRatio;
        set => _aspectRatio = value;
    }
}
