using System.Collections.Generic;
using Entitas;

public class FillSystem : IReactiveSystem, ISetPool {

    Pool _pool;

    public IMatcher trigger { get { return Matcher.AllOf(Matcher.GameBoardElement); } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityRemoved; } }

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(List<Entity> entities) {

        UnityEngine.Debug.Log("Fill");

        var gameBoard = _pool.gameBoard;
        var grid = _pool.gameBoardCache.grid;
        for (int column = 0; column < gameBoard.columns; column++) {
            var nextRowPos = grid.GetNextEmptyRow(column, gameBoard.rows);
            while (nextRowPos != gameBoard.rows) {
                var e = _pool.CreateRandomPiece(column, nextRowPos);
                grid[column, nextRowPos] = e;
                nextRowPos = grid.GetNextEmptyRow(column, gameBoard.rows);
            }
        }
    }
}

