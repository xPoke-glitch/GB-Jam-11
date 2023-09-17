using System;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : Singleton<PeopleManager>
{
    public static event Action OnPersonRescued;

    public int PeopleCount =>  _people.Count;
    public int PeopleRescued => _peopleRescued;

    private List<Person> _people;
    private int _peopleRescued;

    protected override void Awake()
    {
        base.Awake();
        _peopleRescued = 0;
        _people = new List<Person>(FindObjectsOfType<Person>());
    }

    public void RescuePerson()
    {
        OnPersonRescued?.Invoke();

        if (++_peopleRescued >= PeopleCount)
        {
            // TODO WIN THE GAME
            Debug.Log("YOU WON!");
        }
    }
}
