using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class ParalaxLayer : MonoBehaviour
    {
        public Transform Target;
        public float TargetWidth;

        public GameObject TilePrefab;
        public float TileWidth;

        public float SpeedCoef;

        private List<GameObject> _tiles = new List<GameObject>();


        Vector3 _oldTargetPosition;

        private void Start()
        {
            _oldTargetPosition = Target.transform.position;

            var tilesCount = TargetWidth / TileWidth + 2;
            for (int i = 0; i < tilesCount; i++)
            {
                var tile = Instantiate<GameObject>(TilePrefab, transform);
                tile.transform.position = new Vector3(Target.position.x - TargetWidth / 2 + TileWidth * i, transform.position.y, transform.position.z);
                _tiles.Add(tile);
            }
        }

        private void Update()
        {
            var targetDelta = Target.transform.position - _oldTargetPosition;
            transform.position += targetDelta * SpeedCoef;
            _oldTargetPosition = Target.transform.position;

            var firstTile = _tiles[0];
            var lastTile = _tiles[_tiles.Count - 1];

            if (targetDelta.x > 0)
            {
                if (firstTile.transform.position.x + TileWidth < Target.position.x - TargetWidth / 2)
                {
                    firstTile.transform.position = new Vector3(lastTile.transform.position.x + TileWidth, firstTile.transform.position.y, firstTile.transform.position.z);

                    _tiles.RemoveAt(0);
                    _tiles.Add(firstTile);
                }
            }
            else
            {
                if (lastTile.transform.position.x - TileWidth > Target.position.x + TargetWidth / 2)
                {
                    lastTile.transform.position = new Vector3(firstTile.transform.position.x - TileWidth, lastTile.transform.position.y, lastTile.transform.position.z);

                    _tiles.RemoveAt(_tiles.Count - 1);
                    _tiles.Insert(0, lastTile);
                }
            }
        }
    }
}
