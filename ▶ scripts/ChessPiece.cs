using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public enum PieceColor { White, Black }
    public PieceColor color;

    public abstract bool IsValidMove(Vector3 targetPosition);

    protected bool IsWithinBounds(Vector3 position)
    {
        return position.x >= 0 && position.x < 8 && position.y >= 0 && position.y < 8;
    }
}