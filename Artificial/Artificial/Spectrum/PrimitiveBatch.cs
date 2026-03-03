using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Artificial.Artificial.Spectrum;
/// <summary>
/// Definies the basic help <see langword="class"/> for drawing basic geometric primitives like lines, points, rectangles... directly with the GPU.
/// </summary>
public class PrimitiveBatch
{
    private BlendState _blendState;
    /* Controls how new pixels are drawn on on the screen:
     *  Opaque           - no blending, completly replace previous pixel
     *  AlphaBlend       - transparency
     *  Additive         - colors are added together
     *  NonPremultiplied - the color channels are not multiplied by alpha beforehand */

    private DepthStencilState _depthStencilState;
    /* Controls how the depth buffer and stencil buffer are used:
     *  - None      - no depth testing and no depth writing
     *  - Default   - depth testing and depth writing enabled
     *  - DepthRead - depth testing enabled and depth writing disabled
     * 
     * Depth buffer   - stores floating-point depth data for each pixel
     * Stencil buffer - stores integer data for each pixel
     * 
     * The depth of a pixel controls which pixel is drawn on top.
     * A pixel may contain stencil data.
     * 
     * A stencil buffer containes per pixel integer data which is used to add more control over which pixels are rendered. 
     * It can also be used in combination with a depth buffer to do more complex rendering such as simple shadows or outlines.
     * Stencil data can be used as a more general purpose per-pixel mask for saving or discarding pixels.
    */

    private RasterizerState _rasterizerState;
    /* Determines how to render 3D data such as position, color and texture onto a 2D surface. 
     *  CullMode: CullClockwiseFace - Cull faces with clockwise order, CullCounterClockwiseFace - CullCounterClockwiseFace, None - do not cull faces
     *  FillMode: Solid - Draw solid faces for each primitive, WireFrame - draw lines for each primitive
     *  ScissorTestEnable: Boolean - Determines whether or not to check if a pixel is outside a defined rectangular area of the screen and if not skips rendering
     *  MultiSampleAntiAlias: Boolean - Determines whether multisample AA is enabled
     *  DepthBias: Float - gets or sets the depth bias for polygons, which is the amount of bias to apply to the depth of a primitive to alleviate depth testing problems for primitives of similar depth. 
     *  SlopScaleDepthBias: Float - gets or sets a bias value that takes into account the slope of a polygon. This bias value is applied to coplanar primitives to reduce aliasing and other rendering artifacts casued by z-fighting
     */

    private Effect _effect;
    /* Used to set and query shader effects and to choose techniques */

    private BasicEffect _basicEffect;
    /* A built-in effect that supports optional texturing, vertex colorin, fog and lighting. */

    private bool _beginCalled;
    private List<VertexPositionColor> _vertexArray = new List<VertexPositionColor>(256);
    private readonly GraphicsDevice _graphicsDevice;

    /// <summary>
    /// Defines a new <see cref="PrimitiveBatch"/>.
    /// </summary>
    /// <param name="graphicsDevice">The graphics device the <see cref="PrimitiveBatch"/> is being used on. </param>
    public PrimitiveBatch(GraphicsDevice graphicsDevice)
    {
        _graphicsDevice = graphicsDevice;
        
        _basicEffect = new BasicEffect(graphicsDevice); // Create a new BasicEffect
        _basicEffect.VertexColorEnabled = true; // Enable vertex coloring
        _basicEffect.TextureEnabled = false; // Disable texturing
        
        SetProjection(); // Set the projects
        graphicsDevice.DeviceReset += SetProjection; // When the DeviceReset Event happens, call the SetProjection event to trigger too
    }
    /// <summary>
    /// Sets the projection to an offcenter orthographic projection.
    /// </summary>
    /// <param name="o"></param>
    /// <param name="args"></param>
    public void SetProjection(object o = null, EventArgs args = null)
    {
        _basicEffect.Projection = Matrix.CreateOrthographicOffCenter(-0.5f, _graphicsDevice.Viewport.Width - 0.5f, _graphicsDevice.Viewport.Height - 0.5f, -0.5f, 0, -1);
    }
    /// <summary>
    /// Sets the attributes of the <see cref="PrimitiveBatch"/>. Sets <see cref="_beginCalled"/> to <see langword="true"/>.
    /// </summary>
    /// <param name="theBlendState">The <see cref="PrimitiveBatch"/>'s <see cref="BlendState"/>.</param>
    /// <param name="theDepthStencilState">The <see cref="PrimitiveBatch"/>'s <see cref="DepthStencilState"/>.</param>
    /// <param name="theRasterizerState"><see cref="PrimitiveBatch"/>'s <see cref="RasterizerState"/>.</param>
    /// <param name="theEffect"><see cref="PrimitiveBatch"/>'s <see cref="Effect"/>.</param>
    /// <param name="theTransformMatrix"><see cref="PrimitiveBatch"/>'s transform <see cref="Matrix"/>.</param>
    public void Begin(
        BlendState theBlendState = null, 
        DepthStencilState theDepthStencilState = null, 
        RasterizerState theRasterizerState = null, 
        Effect theEffect = null, 
        Matrix? theTransformMatrix = null)
    {
        theBlendState ??= BlendState.AlphaBlend;
        theDepthStencilState ??= DepthStencilState.None;
        theRasterizerState ??= RasterizerState.CullCounterClockwise;
        theEffect ??= _basicEffect;
        // Matrix theTransformMatrix = theTransformMatrix0 ?? Matrix.Identity;

         _blendState = theBlendState;
        _depthStencilState = theDepthStencilState;
        _rasterizerState = theRasterizerState;
        _effect = theEffect;
        
        // If a transform matrix is given along with a basic effect then the effect's world is to be set to the transform matrix.
        if (theTransformMatrix is not null && _effect is BasicEffect effect1)
        {
            effect1.World = theTransformMatrix.Value;
        }

        _beginCalled = true;
    }
    /// <summary>
    /// Draws a point.
    /// </summary>
    /// <param name="position">The position coordinates of the point.</param>
    /// <param name="color">The color of the point.</param>
    /// <param name="layerDepth">The layer depth of the point.</param>
    public void DrawPoint(Vector2 position, Color color, float layerDepth = 0f)
    {
        DrawLine(new Vector2(position.X - 0.5f, position.Y - 0.5f), new Vector2(position.X + 0.5f, position.Y + 0.5f), color, layerDepth);
    }
    /// <summary>
    /// Draws a line from <see cref="Vector2"/> <paramref name="start"/> to <see cref="Vector2"/> <paramref name="end"/>.
    /// </summary>
    /// <param name="start">The starting <see cref="Vector2"/> coordinates.</param>
    /// <param name="end">The end <see cref="Vector2"/> coordinates.</param>
    /// <param name="color">The line's color.</param>
    /// <param name="layerDepth">The line's layerDepth.</param>
    public void DrawLine(Vector2 start, Vector2 end, Color color, float layerDepth = 0f)
    {
        VertexPositionColor vertex = new VertexPositionColor(new Vector3(start, layerDepth), color);
        _vertexArray.Add(vertex);
        vertex.Position.X = end.X;
        vertex.Position.Y = end.Y;
        _vertexArray.Add(vertex);
    }
    /// <summary>
    /// Draws a circle at <see cref="Vector2"/> <paramref name="center"/>.
    /// </summary>
    /// <param name="center">The position of the center of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="divisions">The number of divisions of the circle to draw.</param>
    /// <param name="color">The color of the circle.</param>
    /// <param name="layerDepth">The layerDepth of the circle.</param>
    public void DrawCircle(Vector2 center, float radius, int divisions, Color color, float layerDepth = 0)
    {
        Vector2 start = new Vector2(center.X + radius, center.Y);
        Vector2 end = Vector2.Zero;
        for (int i = 1; i <= divisions; i++)
        {
            float angle = i / (float)divisions * (float)Math.PI * 2;
            end.X = center.X + radius * (float)Math.Cos(angle);
            end.Y = center.Y + radius * (float)Math.Sin(angle);
            DrawLine(start, end, color, layerDepth);
            start = end;
        }

    }
    /// <summary>
    /// Draws a rectanle to the screen.
    /// </summary>
    /// <param name="center">The position of the center of the rectangle.</param>
    /// <param name="width">The rectangle's width.</param>
    /// <param name="height">The rectangle's height.</param>
    /// <param name="color">The rectangle's color.</param>
    /// <param name="layerDepth">The rectangle's layerDepth.</param>
    public void DrawRectangle(Vector2 center, float width, float height, Color color, float layerDepth = 0)
    {
        VertexPositionColor vertex = new VertexPositionColor(
            new Vector3( center.X - width / 2, center.Y - height / 2, layerDepth), color
            );
        _vertexArray.Add(vertex);
        vertex.Position.X += width;
        _vertexArray.Add(vertex);
        _vertexArray.Add(vertex);
        vertex.Position.Y += height;
        _vertexArray.Add(vertex);
        _vertexArray.Add(vertex);
        vertex.Position.X -= width;
        _vertexArray.Add(vertex);
        _vertexArray.Add(vertex);
        vertex.Position.Y -= height;
        _vertexArray.Add(vertex);
    }
    /// <summary>
    /// Applies all settings to the graphicsDevice, then draws the <see cref="PrimitiveBatch"/>.
    /// </summary>
    /// <exception cref="Exception"><see cref="Begin"/> must be called before <see cref="End"/></exception>
    public void End()
    {
        if (!_beginCalled)
        {
            throw new Exception("InvalidOperationException End was called before begin.");
        }

        Apply();
        Draw();
        _beginCalled = false;
    }
    /// <summary>
    /// Applies the <see cref="PrimitiveBatch"/>'s attributes to the <see cref="GraphicsDevice"/>.
    /// </summary>
    public void Apply()
    {
        _graphicsDevice.BlendState = _blendState;
        _graphicsDevice.DepthStencilState = _depthStencilState;
        _graphicsDevice.RasterizerState = _rasterizerState;
        _effect.CurrentTechnique.Passes[0].Apply();
    }
    /// <summary>
    /// Draws the <see cref="PrimitiveBatch"/>.
    /// </summary>
    public void Draw()
    {
        int lineCount = _vertexArray.Count() / 2;
        if (lineCount < 1)
        {
            return;
        }
        
        _graphicsDevice.DrawUserPrimitives(PrimitiveType.LineList, _vertexArray.ToArray(), 0, lineCount);
        _vertexArray.Clear();
    }
}