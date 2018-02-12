using System;
using System.Text;

namespace chapter2
{
    class vec3
    {
        private float[] e = new float[3];

        public vec3()
        {
        }

        public vec3(vec3 v)
        {
            e[0] = v.e[0];
            e[1] = v.e[1];
            e[2] = v.e[2];
        }

        public vec3(float e0, float e1, float e2)
        {
            e[0] = e0;
            e[1] = e1;
            e[2] = e2;
        }

        public void set(float e0, float e1, float e2)
        {
            e[0] = e0;
            e[1] = e1;
            e[2] = e2;
        }


        public float x
        {
            get { return e[0]; }
            set { e[0] = value; }
        }
        public float y
        {
            get { return e[1]; }
            set { e[1] = value; }
        }
        public float z
        {
            get { return e[2]; }
            set { e[2] = value; }
        }

        public float r
        {
            get { return e[0]; }
            set { e[0] = value; }
        }
        public float g
        {
            get { return e[1]; }
            set { e[1] = value; }
        }
        public float b
        {
            get { return e[2]; }
            set { e[2] = value; }
        }

        public float this[int i]
        {
            get { return e[i]; }
            set { e[i] = value; }
        }

        public static vec3 operator +(vec3 a, vec3 b)
        {
            return new vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static vec3 operator -(vec3 a, vec3 b)
        {
            return new vec3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static vec3 operator *(vec3 a, vec3 b)
        {
            return new vec3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static vec3 operator /(vec3 a, vec3 b)
        {
            return new vec3(a.x / b.x, a.y / b.y, a.z / b.z);
        }

        public static bool operator ==(vec3 a, vec3 b)
        {
            return (a.x == b.x && a.y == b.y && a.z == b.z);
        }

        public static bool operator !=(vec3 a, vec3 b)
        {
            return (a.x != b.x || a.y != b.y || a.z != b.z);
        }

        public static vec3 operator +(vec3 a, float b)
        {
            return new vec3(a.x + b, a.y + b, a.z + b);
        }

        public static vec3 operator -(vec3 a, float b)
        {
            return new vec3(a.x - b, a.y - b, a.z - b);
        }

        public static vec3 operator *(vec3 a, float b)
        {
            return new vec3(a.x * b, a.y * b, a.z * b);
        }

        public static vec3 operator /(vec3 a, float b)
        {
            return new vec3(a.x / b, a.y / b, a.z / b);
        }

        public readonly int dimension = 3;

        public float magnitude
        {
            get { return (float)Math.Sqrt(sqr_magnitude); }
        }

        public double sqr_magnitude
        {
            get { return (x * x + y * y + z * z); }
        }

        public void normalized()
        {
            float length = magnitude;
            e[0] /= length;
            e[1] /= length;
            e[2] /= length;
        }

        public vec3 GetIntVec()
        {
            return new vec3((int)x, (int)y, (int)z);
        }

        public vec3 Normalize()
        {
            return this / magnitude;
        }

        public float dot(vec3 a, vec3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.y;
        }
        public vec3 cross(vec3 a, vec3 b)
        {
            return new vec3(
                a.y * b.z - a.z * b.y,
                a.z * b.x - a.x * b.z,
                a.x * b.y - a.y * b.x);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(r).Append(" ").Append(g).Append(" ").Append(b);
            return builder.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            //判断与之比较的类型是否为null。这样不会造成递归的情况
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;
            vec3 v = (vec3)obj;
            if (this == v)
                return true;
            return false;
        }

    }
}
