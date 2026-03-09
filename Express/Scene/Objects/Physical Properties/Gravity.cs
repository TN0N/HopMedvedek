namespace Express.Scene.Objects.Physical_Properties;

public class Gravity: IGravity
{
    private float _gravitationalAcceleration = 981f;

    public float GravitationalAcceleration
    {
        get => _gravitationalAcceleration;
        set => _gravitationalAcceleration = value;
    }
}
