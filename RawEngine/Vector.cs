using System;

namespace RawEngine
{
    public partial struct Vector : IEquatable<Vector>, IEquatable<int>, IComparable<Vector>
    {
        public readonly int X;
        public readonly int Y;

        public double Magnitude
        {
            get { return Vector.GetMagnitude(this); }
        }
        public double SqrtMagnitude
        {
            get { return Vector.GetSqrtMagnitude(this); }
        }
        public Vector Normalized
        {
            get { return Vector.Normalize(this); }
        }

        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Vector(Vector vector) : this(vector.X, vector.Y) { }


        public int CompareTo(Vector vector)
        {
            if (SqrtMagnitude > vector.SqrtMagnitude)
                return 1;
            else if (SqrtMagnitude < vector.SqrtMagnitude)
                return -1;
            else return 0;
        }

        public bool Equals(Vector vector)
        {
            return X == vector.X &&
                Y == vector.Y;
        }
        public bool Equals(int number)
        {
            return X == number && Y == number;
        }

        public override bool Equals(object obj)
        {
            return obj is Vector ?
                Equals((Vector)obj) : false;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            unchecked
            {
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
            }
            return hash;
        }
        public override string ToString()
        {
            return string.Format("[{0}, {1}]", X, Y);
        }
    }
}