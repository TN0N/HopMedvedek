using Microsoft.Xna.Framework.Graphics;

namespace Express.Graphics;

public interface ITexture
{
    public SpriteSortMode SpriteSortMode { get; set; }
    public BlendState BlendState { get; set; }
    public SamplerState SamplerState { get; set; }
    public DepthStencilState DepthStencilState { get; set; }
    public RasterizerState RasterizerState { get; set; }
    public Effect Effect { get; set; }
}
