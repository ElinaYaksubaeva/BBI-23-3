using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;


namespace Variant_3
{
    public class Task1
    {
        public struct Dot
        {
            private double _x;
            private double _y;
            private double _z;

            public Dot(double[] coords)
            {
                if (coords.Length == 3)
                {
                    _x = coords[0];
                    _y = coords[1];
                    _z = coords[2];
                }
                else
                {
                    _x = 0;
                    _y = 0;
                    _z = 0;
                }
            }

            public double X { get { return _x; } }
            public double Y { get { return _y; } }
            public double Z { get { return _z; } }

            public override string ToString()
            {
                return $"x = {_x}, y = {_y}, z = {_z}";
            }
        }

        public struct Vector
        {
            private Dot _a;
            private Dot _b;

            public Vector(Dot a, Dot b)
            {
                _a = a;
                _b = b;
            }

            public Dot A { get { return _a; } }
            public Dot B { get { return _b; } }

            public double Length()
            {
                return Math.Sqrt(Math.Pow(_b.X - _a.X, 2) + Math.Pow(_b.Y - _a.Y, 2) + Math.Pow(_b.Z - _a.Z, 2));
            }

            public override string ToString()
            {
                return $"{_a.ToString()}\n{_b.ToString()}\nLength = {Length()}";
            }
        }

        private Vector[] _vectors;

        public Vector[] Vectors
        {
            get { return _vectors; }
        }

        public Task1(Vector[] vectors)
        {
            _vectors = vectors;
        }

        public void Sorting()
        {
            for (int i = 0; i < _vectors.Length - 1; i++)
            {
                for (int j = i + 1; j < _vectors.Length; j++)
                {
                    if (_vectors[i].Length() > _vectors[j].Length())
                    {
                        Vector temp = _vectors[i];
                        _vectors[i] = _vectors[j];
                        _vectors[j] = temp;
                    }
                }
            }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < _vectors.Length; i++)
            {
                result += _vectors[i].ToString() + "\n";
            }
            return result;
        }
    }
}
