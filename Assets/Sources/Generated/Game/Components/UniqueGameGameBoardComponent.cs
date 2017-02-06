//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public partial class GameContext {

    public GameEntity gameBoardEntity { get { return GetGroup(GameMatcher.GameBoard).GetSingleEntity(); } }
    public GameBoardComponent gameBoard { get { return gameBoardEntity.gameBoard; } }
    public bool hasGameBoard { get { return gameBoardEntity != null; } }

    public GameEntity SetGameBoard(int newColumns, int newRows) {
        if(hasGameBoard) {
            throw new EntitasException("Could not set gameBoard!\n" + this + " already has an entity with GameBoardComponent!",
                "You should check if the context already has a gameBoardEntity before setting it or use context.ReplaceGameBoard().");
        }
        var entity = CreateEntity();
        entity.AddGameBoard(newColumns, newRows);
        return entity;
    }

    public void ReplaceGameBoard(int newColumns, int newRows) {
        var entity = gameBoardEntity;
        if(entity == null) {
            entity = SetGameBoard(newColumns, newRows);
        } else {
            entity.ReplaceGameBoard(newColumns, newRows);
        }
    }

    public void RemoveGameBoard() {
        DestroyEntity(gameBoardEntity);
    }
}