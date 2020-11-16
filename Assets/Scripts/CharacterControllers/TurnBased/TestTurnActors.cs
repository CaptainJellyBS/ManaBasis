using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTurnActors : TurnActor
{
    Rigidbody rb;
    public int amountOfTurnsTilDeath;

    protected override void Start()
    {
        rb = GetComponent<Rigidbody>();
        base.Start();

    }
    public override IEnumerator Act()
    {
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        initiative = TurnManager.Instance.GetLastActorInitiative() + 1;
        amountOfTurnsTilDeath -= 1;
        if(amountOfTurnsTilDeath < 1) { Destroy(gameObject); yield break; }

        yield return new WaitForSeconds(3.0f);
    }
}
