using Artificial.Artificial.Mirage;
using Artificial.Artificial.Utils;
using Express.Scene;
using HopMedvedek.AI;
using HopMedvedek.Data;
using HopMedvedek.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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
    protected bool _branchDirection = false;
    private double _lastCrowSpawnTime = 0;

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
    private void RemoveBranches()
    {
        List<TreeMid> treeMidsToBeRemoved = new List<TreeMid>();
        List<Branch> branchesToBeRemoved = new List<Branch>();
        foreach (TreeMid treemid in _treeMids)
            if (_level.Bear.Position.Y < treemid.Position.Y && MathF.Abs(_level.Bear.Position.Y - treemid.Position.Y) >= 700)
                treeMidsToBeRemoved.Add(treemid);
        foreach (Branch branch in _branches)
            if (_level.Bear.Position.Y < branch.Leaves.Position.Y && MathF.Abs(_level.Bear.Position.Y - branch.Leaves.Position.Y) >= 350)
                branchesToBeRemoved.Add(branch);


        foreach (TreeMid treemid in treeMidsToBeRemoved)
        { 
            _level.Scene.Remove(treemid);
            _treeMids.Remove(treemid);
        }
        foreach (Branch branch in branchesToBeRemoved)
        {
            branch.RemoveBranch();
            _branches.Remove(branch);
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

        if (lastTreeMid.Position.Y > -_level.Scene.CameraMatrix.Translation.Y - HopMedvedekConstants.screenHeight / 2)
        {
            TreeMid treeMid = new TreeMid();
            treeMid.Position = new Vector2(lastTreeMid.Position.X, lastTreeMid.Position.Y - treeMid.Height);


            int branchLength = SRandom.Int(180);


            Branch branch = new Branch(Game, _level.Scene, treeMid.Position, (_branchDirection == true) ? branchLength : -branchLength);
            _branchDirection = !_branchDirection;
            _branches.Add(branch);
            _treeMids.Add(treeMid);
            _level.Scene.Add(treeMid);

            if (lastTreeMid.Position.Y < - 300 && SRandom.Int(100) <= 10 && gameTime.TotalGameTime.TotalMilliseconds - _lastCrowSpawnTime >= 700)
            {
                _lastCrowSpawnTime = gameTime.TotalGameTime.TotalMilliseconds;
                Crow crow = new Crow(Game, _level);
                crow.Position = treeMid.Position;
                crow.Behaviour = new CrowBehaviour(Game, crow, _level);
                _level.Scene.Add(crow);
            }
        }
        RemoveBranches();
        foreach (var branch in _branches)
        {
            branch.Update(gameTime);
        }
    }
    public List<Branch> Branches
    {
        get => _branches;
    }
}
