using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myBLTemplate : BasicBehaviourLibrary {
    
    private Vector3 posA1 = new Vector3(-21.0f,0.0f,-18.5f);
    private Vector3 lookA2 = new Vector3(-12.5f,0.0f,-20.5f);
    private Vector3 posA2 = new Vector3(-18.5f,0.0f,-20.0f);
    private Vector3 lookA1 = new Vector3(-22.5f,0.0f,-15.0f);
    private Vector3 posB1 = new Vector3(21.0f,0.0f,18.5f);
    private Vector3 lookB2 = new Vector3(12.5f,0.0f,20.5f);
    private Vector3 posB2 = new Vector3(18.5f,0.0f,20.0f);
    private Vector3 lookB1 = new Vector3(22.5f,0.0f,15.0f);


     public float speed = 1.0f;
    public void MovetoFlag()
    {
        transform.LookAt(EnemyFlagInSight.GetLocation());
        MoveTowards(EnemyFlagInSight.GetLocation());
    }

    public void FlagInSightPurse(){
        ShootEnemiesInSight();
    }

    public bool FriendlyTeamFlagInSight()
    {
        return FriendlyFlagInSight != null;
    }

    public void GrabEnemyFlagMod(){
        GrabEnemyTeamFlag();
        if(HoldsFlag()){        
            ReturnToBase();
        }
    }

    public void LookTowardsDirection()
    {
        transform.LookAt(NavAgent.pathGenerated[0]);
    }

   public bool BaseRange(){
        if(Vector3.Distance(CurrentLocation, SpawnLocation) < 6){
            return true;
        }
        return false;
    }

    public void ReturnToBaseNotFound(){
        if(EnemyFlagNotInBase() && !BaseRange()){
            //ReturnToBase();
            Vector3 position = MoveInBase();
            NavAgent.TargetPosition = (position);
            //transform.LookAt(position);
            //MoveTowards(position);
        }
    }

    private Vector3 MoveInBase(){
        if(SpawnLocation[0]>0){
             return new Vector3(Random.Range(SpawnLocation[0], SpawnLocation[0] - 3.5f), 0, Random.Range(SpawnLocation[2] - 1.0f, SpawnLocation[2] + 1.0f));    
        }else{
            return new Vector3(Random.Range(SpawnLocation[0], SpawnLocation[0] + 3.5f), 0, Random.Range(SpawnLocation[2] + 1.0f, SpawnLocation[2] - 1.0f));    
        }
    }


    public void MovetoDefendPosition1(){
        if(SpawnLocation[0]>0){
            transform.LookAt(posB1);
            MoveTowards(posB1);
            transform.LookAt(lookB1);
            
        }else{
            transform.LookAt(posA1);
            MoveTowards(posA1);
            transform.LookAt(lookA1);
        }
    }

    public void MovetoDefendPosition2(){
        if(SpawnLocation[0]>0){
            transform.LookAt(posB2);
            MoveTowards(posB2);
            transform.LookAt(lookB2);
        }else{
            transform.LookAt(posA2);
            MoveTowards(posA2);
            transform.LookAt(lookA2);
        }
    }
    // defendBase possibly xml 
    // possible xml full re-write
    // rotate look around if static for too long

 
}
