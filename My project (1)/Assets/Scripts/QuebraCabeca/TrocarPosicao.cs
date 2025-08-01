using System.Collections.Generic;
using UnityEngine;

public class TrocarPosicao : ICommand
{
    public List<PecaClicavel> puzzlePieces;
    public PecaClicavel _pecaSelecionada;
    public PecaClicavel pieceActually;
    
    public TrocarPosicao(List<PecaClicavel> puzzlePieces, PecaClicavel _pecaSelecionada, PecaClicavel pieceActually)
    {
        this.puzzlePieces = puzzlePieces;
        this._pecaSelecionada = _pecaSelecionada;
        this.pieceActually = pieceActually;
    }
    public void Execute()
    {
        TrocaPosicao();
    }
    public void Undo()
    {
        TrocaPosicao();
    }
    private void TrocaPosicao()
    {
        int k = puzzlePieces.IndexOf(_pecaSelecionada);
        int n = puzzlePieces.IndexOf(pieceActually);
        
        PecaClicavel temp = puzzlePieces[k];
        puzzlePieces[k] = puzzlePieces[n];
        puzzlePieces[n] = temp;
        puzzlePieces[n].transform.SetSiblingIndex(n);
        puzzlePieces[k].transform.SetSiblingIndex(k);
    }

    
}
