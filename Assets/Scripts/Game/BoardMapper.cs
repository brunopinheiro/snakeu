using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace SnakeU.GameScene {
    public class BoardMapper {
        Dictionary<Vector2, GameObject> occupiedCoordinates = new Dictionary<Vector2, GameObject>();

        public void StartListeningEventsFrom(NotificationCenter notificationCenter) {
            notificationCenter.AddListener(GameEvents.coordinateOccupied, AddOccupiedCoordinate);
            notificationCenter.AddListener(GameEvents.coordinateDisoccupied, RemoveOccupiedCoordinate);
        }

        void AddOccupiedCoordinate(Hashtable args) {
            var occupier = args["occupier"] as GameObject;
            var coordinates = (Vector2)args["coordinates"];
            occupiedCoordinates[coordinates] = occupier;
        }

        void RemoveOccupiedCoordinate(Hashtable args) {
            var coordinate = (Vector2)args["coordinates"];
            occupiedCoordinates.Remove(coordinate);
        }

        public void StopListeningEventsFrom(NotificationCenter notificationCenter) {
            notificationCenter.RemoveListener(GameEvents.coordinateOccupied, AddOccupiedCoordinate);
            notificationCenter.RemoveListener(GameEvents.coordinateDisoccupied, RemoveOccupiedCoordinate);
        }

        public Vector2[] OccupiedCoordinates {
            get { return occupiedCoordinates.Keys.ToArray(); }
        }
    }
}