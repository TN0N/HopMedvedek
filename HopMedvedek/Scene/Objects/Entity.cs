using Express.Graphics;
using Express.Scene.Objects.Composites;
using Express.Scene.Objects.Movement;
using Express.Scene.Objects.Physical_Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopMedvedek.Scene.Objects;

public class Entity : IMass, ITexture, IVelocity, IAcceleration
{

    protected float _mass;
    protected ITextureData _textureData;
    protected FacingEnum _facing;

    public float Mass { 
        get => _mass; 
        set => _mass = value; 
    }
    public enum FacingEnum
    {
        Left,
        Right
    }
}
