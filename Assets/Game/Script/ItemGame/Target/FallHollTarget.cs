using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FallHollTarget : KillBall
{
    public override void Kill_Ball(BallControlScript ball)
    {
        
        CompleteGame();
    }
    private void CompleteGame()
    {
        GameManager.Ins.OpenWindown(TypeWindown.NextLevel);
        Debug.Log("CompleteGame");
    }
}
