using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TheGameOfBlobs
{
    class BlobPopulation
    {
        internal List<Blob> Blobs { get; set; } = new List<Blob>();

        internal void PopulateBlobs (int[,] blobArray)
        {
            BlobNameGenerator nameGenerator = new BlobNameGenerator();

            for (int row = 0; row < blobArray.GetLength(0); row ++)
            {
                var blob = new Blob
                (
                    blobArray[row, 0], 
                    blobArray[row, 1], 
                    blobArray[row, 2]
                );

                blob.Name = nameGenerator.GenerateName();
                Blobs.Add(blob);
            }
        }

        internal void SurvivalOfTheFattest()
        {
            List<int> blobSizes = GetSizes(Blobs);

            while (blobSizes.Distinct().Count() != 1)
            {
                foreach (Blob blob in Blobs)
                {
                    FindNearestPrey(blob);
                    blob.MoveToPrey(blob.NearestPreyDirection);
                }

                FeastTime();

                blobSizes = GetSizes(Blobs);
            }            
        }

        private List<int> GetSizes(List<Blob> blobs)
        {
            var sizes = new List<int>();

            foreach (Blob blob in blobs)
            {
                sizes.Add(blob.Size);
            }

            return sizes;
        }

        private void FindNearestPrey(Blob blob)
        {
                List<Blob> closestSmallerBlobs = GetClosestSmallerBlobs(blob);

                if (closestSmallerBlobs == null)
                {
                    blob.NearestPreyDirection = Blob.Direction.NoMovement;
                    return;
                }

                Blob closestSmallerBlob = closestSmallerBlobs.Count == 1 ? closestSmallerBlobs[0] : ClockwiseRule(blob, closestSmallerBlobs);

                SetDirection(blob, closestSmallerBlob.Position);
        }        

        private List<Blob> GetClosestSmallerBlobs(Blob blob)
        {
            var smallerBlobs = GetSmallerBlobs(blob);

            if (smallerBlobs.Count == 0)
            {
                return null;
            }

            var distances = new int[smallerBlobs.Count];            

            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = GetDistance(smallerBlobs[i], blob);
            }

            int min = distances.Min();
            return GetMinimumIndexes(smallerBlobs, blob, min).ToList();
        }

        private List<Blob> GetSmallerBlobs(Blob currentBlob)
        {
            var smallerBlobs = new List<Blob>();

            foreach (Blob blob in Blobs)
            {
                if (blob.Size < currentBlob.Size)
                {
                    smallerBlobs.Add(blob);
                }
            }

            return smallerBlobs;
        }

        private int GetDistance(Blob currentBlob, Blob smallerBlob)
        {
            return Math.Max
            (
                Math.Abs(smallerBlob.Position.X - currentBlob.Position.X), 
                Math.Abs(smallerBlob.Position.Y - currentBlob.Position.Y)
            );
        }

        private IEnumerable<Blob> GetMinimumIndexes(List<Blob> blobs, Blob currentBlob, int min)
        {
            foreach (Blob blob in blobs)
            {
                if (GetDistance(currentBlob, blob) == min)
                {
                    yield return blob;
                }
            }
        }

        private Blob ClockwiseRule(Blob currentBlob, List<Blob> closestBlobs)
        {
            int radius = GetDistance(currentBlob, closestBlobs[0]);
            List<Point> radialPoints = GetRadialPoints(radius);

            var blobRadialPointIndexes = new List<int>();

            foreach (Blob blob in closestBlobs)
            {
                int blobRadialPointIndex = radialPoints.IndexOf(blob.Position);
                blobRadialPointIndexes.Add(blobRadialPointIndex);
            }

            int closestBlobIndex = blobRadialPointIndexes.IndexOf(blobRadialPointIndexes.Min());

            return closestBlobs[closestBlobIndex];
        }

        private List<Point> GetRadialPoints(int radius)
        {
            var radialPoints = new List<Point>();

            for (int x = 0; x < radius; x++)
            {
                radialPoints.Add(new Point(x, radius));
            }

            for (int y = radius; y > -radius; y--)
            {
                radialPoints.Add(new Point(radius, y));
            }

            for (int x = radius; x > -radius; x--)
            {
                radialPoints.Add(new Point(x, -radius));
            }

            for (int y = -radius; y < radius; y++)
            {
                radialPoints.Add(new Point(-radius, y));
            }

            for (int x = -radius; x < 0; x++)
            {
                radialPoints.Add(new Point(x, radius));
            }

            return radialPoints;
        }

        private void SetDirection(Blob blob, Point nearestPreyLocation)
        {
            if (blob.Position.X == nearestPreyLocation.X && 
                blob.Position.Y < nearestPreyLocation.Y)
            {
                blob.NearestPreyDirection = Blob.Direction.N;
            }

            if (blob.Position.X < nearestPreyLocation.X &&
                blob.Position.Y < nearestPreyLocation.Y)
            {
                blob.NearestPreyDirection = Blob.Direction.NE;
            }

            if (blob.Position.X < nearestPreyLocation.X &&
                blob.Position.Y == nearestPreyLocation.Y)
            {
                blob.NearestPreyDirection = Blob.Direction.E;
            }

            if (blob.Position.X < nearestPreyLocation.X &&
                blob.Position.Y > nearestPreyLocation.Y)
            {
                blob.NearestPreyDirection = Blob.Direction.SE;
            }

            if (blob.Position.X == nearestPreyLocation.X &&
                blob.Position.Y > nearestPreyLocation.Y)
            {
                blob.NearestPreyDirection = Blob.Direction.S;
            }

            if (blob.Position.X > nearestPreyLocation.X &&
                blob.Position.Y > nearestPreyLocation.Y)
            {
                blob.NearestPreyDirection = Blob.Direction.SW;
            }

            if (blob.Position.X > nearestPreyLocation.X &&
                blob.Position.Y == nearestPreyLocation.Y)
            {
                blob.NearestPreyDirection = Blob.Direction.W;
            }

            if (blob.Position.X > nearestPreyLocation.X &&
                blob.Position.Y < nearestPreyLocation.Y)
            {
                blob.NearestPreyDirection = Blob.Direction.NW;
            }
        }
        
        private void FeastTime()
        {
            var culledBlobs = new List<Blob>(Blobs);
            for (int i = 0; i < Blobs.Count; i++)
            {        
                for (int j = 0; j < Blobs.Count; j++)
                {
                    if (Blobs[j].Position == Blobs[i].Position && i != j)
                    {
                        if (Blobs[j].Size < Blobs[i].Size)
                        {
                            culledBlobs[i].Engulf(Blobs[j]);
                            culledBlobs.RemoveAt(j);
                        }
                    }
                }
            }

            Blobs = culledBlobs;
        }

        internal void ClearBlobs()
        {
            Blobs.Clear();
        }
    }
}
