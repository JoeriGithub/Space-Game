using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    // Arrays voor verschillende kamertypen
    public Room[] classicRooms;
    public Room[] treasureRooms;
    //unique rooms
    public Room[] bossRooms;
    public Room[] startRooms;
    //unique rooms
    public Room[] puzzleRooms;
    //unique rooms
    public Room[] storyRooms;
    public Room[] shopRooms;
    public Room[] combatRooms;

    public int numberOfClassicRooms;
    public int numberOfTreasureRooms;
    public int numberOfBossRooms;
    public int numberOfStartRooms;
    public int numberOfPuzzleRooms;
    public int numberOfStoryRooms;
    public int numberOfShopRooms;
    public int numberOfCombatRooms;

    public bool classicRoomsIsUnique = false;
    public bool treasureRoomsIsUnique = false;
    public bool bossRoomsIsUnique = false;
    public bool startRoomsIsUnique = false;
    public bool puzzleRoomsIsUnique = false;
    public bool storyRoomsIsUnique = false;
    public bool shopRoomsIsUnique = false;
    public bool combatRoomsIsUnique = false;
    
    public int seed;
    private List<GameObject> spawnedRooms = new List<GameObject>();
    void Start()
    {
        GenerateRooms();
        // Creating a Random object with a seed value of 123
        Random.InitState(seed);
    }

    // Genereren van kamers op basis van kamertypen
    private void GenerateRooms()
    {
        // Lijsten om kamertypes bij te houden
        List<Room>[] roomLists = new List<Room>[]
        {
            new List<Room>(classicRooms),
            new List<Room>(treasureRooms),
            new List<Room>(bossRooms),
            new List<Room>(startRooms),
            new List<Room>(puzzleRooms),
            new List<Room>(storyRooms),
            new List<Room>(shopRooms),
            new List<Room>(combatRooms)
        };
        int[] numberOfRooms = new int[]
        {
            numberOfClassicRooms,
            numberOfTreasureRooms,
            numberOfBossRooms,
            numberOfStartRooms,
            numberOfPuzzleRooms,
            numberOfStoryRooms,
            numberOfShopRooms,
            numberOfCombatRooms
        };

        bool[] isUnique = new bool[]
        {
            classicRoomsIsUnique,
            treasureRoomsIsUnique,
            bossRoomsIsUnique,
            startRoomsIsUnique,
            puzzleRoomsIsUnique,
            storyRoomsIsUnique,
            shopRoomsIsUnique,
            combatRoomsIsUnique
        };

        // Lijst om bij te houden welke kamers al zijn gekozen
        List<Room>[] chosenRooms = new List<Room>[]
        {
            new List<Room>(),
            new List<Room>(),
            new List<Room>(),
            new List<Room>(),
            new List<Room>(),
            new List<Room>(),
            new List<Room>(),
            new List<Room>()
        };

        // Loop door elk kamertype
        for (int i = 0; i < roomLists.Length; i++)
        {
            // Controleer of de kamers uniek moeten zijn en er voldoende kamers zijn om unieke kamers te kiezen
            if (isUnique[i] && numberOfRooms[i] > roomLists[i].Count)
            {
                Debug.LogError("Not enough rooms to choose from for unique rooms");
                return;
            }
            // maximaal aantal pogingen
            int k = 0;
            // Ga door zolang er nog kamers moeten worden gekozen en er nog kamers zijn om uit te kiezen
            while (((isUnique[i] && chosenRooms[i].Count < numberOfRooms[i]) || (!isUnique[i] && chosenRooms[i].Count < numberOfRooms[i])) &&  k < 100){
                k++;
                // Schud de lijst van kamertypes op basis van de seed
                Shuffle(roomLists[i]);

                // Kies willekeurig kamers uit de lijst en voeg deze toe aan de spawnedRooms-lijst
                for (int j = 0; j < roomLists[i].Count; j++)
                {
                    Room room = roomLists[i][j];
                    if (chosenRooms[i].Count >= numberOfRooms[i])
                        break;
                    // Als de kamer nog niet is gekozen, voeg deze toe aan de spawnedRooms-lijst en de set van gekozen kamers
                    if (!chosenRooms[i].Contains(room) || !isUnique[i])
                    {
                        spawnedRooms.Add(room.gameObject);
                        chosenRooms[i].Add(room);
                    }
                }
            }
        }
    }

    // Methode om een lijst op te schudden (shuffle)
    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
