using Artificial.Artificial.Mirage;
using Artificial.Artificial.Utils;
using Express.Scene;
using HopMedvedek.AI;
using HopMedvedek.Data;
using HopMedvedek.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace HopMedvedek.Scene.Objects;

public class Tree: GameComponent
{
    protected Vector2 _position;

    protected TreeBase _treeBase;
    protected List<TreeMid> _treeMids;
    protected LevelBase _level;
    protected List<Branch> _branches;
    protected Branch _correctLeaf, _wrongLeaf;
    protected string _playerAnswer;
    


    public Tree(Game game, LevelBase level): base(game)
    {
        // Generate base
        _treeBase = new TreeBase();
        _treeBase.Position = _position;

        // Generate mid part of the tree
        _treeMids = new List<TreeMid>();
        _branches = new List<Branch>();
        _level = level;

        

        _level.Scene.Add(_treeBase);
        Game.Components.Add(this);
    }
    public Vector2 Position
    {
        get => _position;
        set { 
            _position = value;
            _treeBase.Position = _position;
        }
    }
    public Branch CorrectAnswer
    {
        get => _correctLeaf;
        set => _correctLeaf = value;
    }
    public Branch WrongAnswer
    {
        get => _wrongLeaf;
        set => _wrongLeaf = value;
    }
    public void AddQuestionsToLeaves(string correctAnswerText, string wrongAnswerText)
    {
        if (SRandom.Int() >= 0.5)
        { 
            _correctLeaf = _branches[_branches.Count - 1];
            _wrongLeaf = _branches[_branches.Count - 2];

            _correctLeaf.
        }
        else
        {
            _wrongLeaf = _branches[_branches.Count - 1];
            _correctLeaf = _branches[_branches.Count - 2];
        }
    }
    public override void Update(GameTime gameTime)
    {
        if (_treeMids.Count < 1)
        {
            TreeMid treeMid = new TreeMid();
            treeMid.Position = new Vector2(_position.X, _treeBase.Position.Y - _treeBase.Height - 3);

            _treeMids.Add(treeMid);
            _level.Scene.Add(treeMid);
        }

        TreeMid lastTreeMid = _treeMids.Last();

        if (lastTreeMid.Position.Y > -_level.Scene.CameraMatrix.Translation.Y - Game.Window.ClientBounds.Height / 2)
        {
            TreeMid treeMid = new TreeMid();
            treeMid.Position = new Vector2(lastTreeMid.Position.X, lastTreeMid.Position.Y - treeMid.Height);


            int branchLength = SRandom.Int(180);


            Branch branch = new Branch(Game, _level.Scene, treeMid.Position, (_treeMids.Count % 2 == 0) ? branchLength : -branchLength);
            _branches.Add(branch);
            _treeMids.Add(treeMid);
            _level.Scene.Add(treeMid);

            if (lastTreeMid.Position.Y < - 300 && SRandom.Int(100) <= 20)
            {
                Crow crow = new Crow(Game, _level);
                crow.Position = treeMid.Position;
                crow.Behaviour = new CrowBehaviour(Game, crow, _level);
                _level.Scene.Add(crow);
            }
        }
        foreach (var branch in _branches)
        {
            branch.Update(gameTime);
        }
    }
}
