using System;

namespace RawEngine
{
    public partial struct Vector
    {
        #region Fields
        public static Vector Zero = new Vector();
        public static Vector One = new Vector(1, 1);

        public static Vector Up = new Vector(0, 1);
        public static Vector Down = new Vector(0, -1);
        public static Vector Right = new Vector(1, 0);
        public static Vector Left = new Vector(-1, 0);

        public static Vector UpRight = new Vector(1, 1);
        public static Vector UpLeft = new Vector(-1, 1);
        public static Vector DownRight = new Vector(1, -1);
        public static Vector DownLeft = new Vector(-1, -1);
        #endregion

        #region Methods
        public static double GetMagnitude(Vector vector)
        {
            return Math.Sqrt(GetSqrtMagnitude(vector));
        }
        public static double GetSqrtMagnitude(Vector vector)
        {
            return Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2);
        }
        public static Vector Normalize(Vector vector)
        {
            return new Vector(
                vector.X == 0 ? 0 : 1,
                vector.Y == 0 ? 0 : 1
            );
        }
        
        public static double GetDistance(Vector vector1, Vector vector2)
        {
            return Math.Sqrt(GetSqrtDistance(vector1, vector2));
        }
        public static double GetSqrtDistance(Vector vector1, Vector vector2)
        {
            return (vector2 - vector1).SqrtMagnitude;
        }
        #endregion

        #region Operators
        #region Unary operators
        public static Vector operator +(Vector vector)
        {
            return new Vector(vector);
        }
        public static Vector operator -(Vector vector)
        {
            return new Vector(
                -vector.X,
                -vector.Y
            );
        }
        public static bool operator !(Vector vector)
        {
            return vector.X == 0 && vector.Y == 0;
        }
        public static Vector operator ~(Vector vector)
        {
            return new Vector(
                ~vector.X,
                ~vector.Y
            );
        }
        #endregion

        #region Basic math operators
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(
                vector1.X + vector2.X,
                vector1.Y + vector2.Y
            );
        }
        public static Vector operator +(Vector vector, int number)
        {
            return new Vector(
                vector.X + number,
                vector.Y + number
            );
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return new Vector(
                vector1.X - vector2.X,
                vector1.Y - vector2.Y
            );
        }
        public static Vector operator -(Vector vector, int number)
        {
            return new Vector(
                vector.X - number,
                vector.Y - number
            );
        }

        public static Vector operator *(Vector vector1, Vector vector2)
        {
            return new Vector(
                vector1.X * vector2.X,
                vector1.Y * vector2.Y
            );
        }
        public static Vector operator *(Vector vector, int number)
        {
            return new Vector(
                vector.X * number,
                vector.Y * number
            );
        }

        public static Vector operator /(Vector vector1, Vector vector2)
        {
            return new Vector(
                vector1.X / vector2.X,
                vector1.Y / vector2.Y
            );
        }
        public static Vector operator /(Vector vector, int number)
        {
            return new Vector(
                vector.X / number,
                vector.Y / number
            );
        }

        public static Vector operator %(Vector vector1, Vector vector2)
        {
            return new Vector(
                vector1.X % vector2.X,
                vector1.Y % vector2.Y
            );
        }
        public static Vector operator %(Vector vector, int number)
        {
            return new Vector(
                vector.X % number,
                vector.Y % number
            );
        }
        #endregion

        #region Bitwise operators
        public static Vector operator >>(Vector vector, int number)
        {
            return new Vector(
                vector.X >> number,
                vector.Y >> number
            );
        }
        public static Vector operator <<(Vector vector, int number)
        {
            return new Vector(
                vector.X << number,
                vector.Y << number
            );
        }

        public static Vector operator &(Vector vector1, Vector vector2)
        {
            return new Vector(
                vector1.X & vector2.X,
                vector1.Y & vector2.Y
            );
        }
        public static Vector operator &(Vector vector, int number)
        {
            return new Vector(
                vector.X & number,
                vector.Y & number
            );
        }

        public static Vector operator |(Vector vector1, Vector vector2)
        {
            return new Vector(
                vector1.X | vector2.X,
                vector1.Y | vector2.Y
            );
        }
        public static Vector operator |(Vector vector, int number)
        {
            return new Vector(
                vector.X | number,
                vector.Y | number
            );
        }

        public static Vector operator ^(Vector vector1, Vector vector2)
        {
            return new Vector(
                vector1.X ^ vector2.X,
                vector1.Y ^ vector2.Y
            );
        }
        public static Vector operator ^(Vector vector, int number)
        {
            return new Vector(
                vector.X ^ number,
                vector.Y ^ number
            );
        }
        #endregion

        #region Equalality operators
        public static bool operator ==(Vector vector1, Vector vector2)
        {
            return vector1.Equals(vector2);
        }
        public static bool operator ==(Vector vector, int number)
        {
            return vector.Equals(number);
        }

        public static bool operator !=(Vector vector1, Vector vector2)
        {
            return !vector1.Equals(vector2);
        }
        public static bool operator !=(Vector vector, int number)
        {
            return !vector.Equals(number);
        }

        public static bool operator >(Vector vector1, Vector vector2)
        {
            return vector1.SqrtMagnitude > vector2.SqrtMagnitude;
        }
        public static bool operator >(Vector vector, int number)
        {
            return vector.Magnitude > number;
        }

        public static bool operator <(Vector vector1, Vector vector2)
        {
            return vector1.SqrtMagnitude < vector2.SqrtMagnitude;
        }
        public static bool operator <(Vector vector, int number)
        {
            return vector.Magnitude < number;
        }

        public static bool operator >=(Vector vector1, Vector vector2)
        {
            return vector1.SqrtMagnitude >= vector2.SqrtMagnitude;
        }
        public static bool operator >=(Vector vector, int number)
        {
            return vector.Magnitude >= number;
        }

        public static bool operator <=(Vector vector1, Vector vector2)
        {
            return vector1.SqrtMagnitude <= vector2.SqrtMagnitude;
        }
        public static bool operator <=(Vector vector, int number)
        {
            return vector.Magnitude <= number;
        }
        #endregion

        #region Casting
        public static implicit operator bool(Vector vector)
        {
            return !vector;
        }

        public static implicit operator byte(Vector vector)
        {
            return (byte) vector.Magnitude;
        }
        public static implicit operator short(Vector vector)
        {
            return (short) vector.Magnitude;
        }
        public static implicit operator ushort(Vector vector)
        {
            return (ushort) vector.Magnitude;
        }
        public static implicit operator int(Vector vector)
        {
            return (int) vector.Magnitude;
        }
        public static implicit operator uint(Vector vector)
        {
            return (uint) vector.Magnitude;
        }
        public static implicit operator long(Vector vector)
        {
            return (long) vector.Magnitude;
        }
        public static implicit operator ulong(Vector vector)
        {
            return (ulong) vector.Magnitude;
        }
        
        public static implicit operator float(Vector vector)
        {
            return (float) vector.Magnitude;
        }
        public static implicit operator double(Vector vector)
        {
            return vector.Magnitude;
        }
        public static implicit operator decimal(Vector vector)
        {
            return (decimal) vector.Magnitude;
        }
        
        public static implicit operator string(Vector vector)
        {
            return vector.ToString();
        }
        #endregion
        #endregion
    }
}