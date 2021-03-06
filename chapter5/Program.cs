﻿using System;
using System.IO;

namespace chapter5
{
    class Program
    {
        static bool HitSphere(vec3 sphereCenter, float sphereRadius, ray r, out float value)//r = A+B*t
        {
            vec3 oc = r.Origin - sphereCenter;
            float a = vec3.dot(r.Direction, r.Direction); //dot(B,B)
            float b = 2.0f * vec3.dot(oc, r.Direction);   //2*dot(A-C,B)
            float c = vec3.dot(sphereCenter, sphereCenter) - sphereRadius * sphereRadius; //dot(C,C)-R*R
            float discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                value = -1;
                return false;
            }
            value = (-b - (float)Math.Sqrt(discriminant)) / (2.0f * a);//closest(smallest) hit point
            return true;
        }
        
        static vec3 GetColor(ray r)
        {
            float value = -1;
            bool hit = HitSphere(new vec3(0, 0, -1), 0.5f, r, out value);
            if (hit)
            {
                vec3 Normal = (r.point_at_parameter(value) - new vec3(0, 0, -1)).Normalize();//normal:[-1,1]
                return (new vec3(1 + Normal.x, 1 + Normal.y, 1 + Normal.z) * 0.5f);//[-1,1]-->[0,2]-->[0,1]
            }

            vec3 normalizedDir = r.Direction.Normalize();
            float y = normalizedDir.y + 1;   //[-1,1]-->[0,2]
            float t = 0.5f * y;              //[0,2]-->[0,1]
            vec3 color_start = new vec3(1, 1, 1);     //white
            vec3 color_end = new vec3(0.5f, 0.7f, 1); //light blue
            return color_start * (1 - t) + color_end * t;     //linear interpolate
        }

        static void Main(string[] args)
        {
            int nx = 200;
            int ny = 100;

            float u, v;
            ray r;
            vec3 color;
            int nr, ng, nb;

            string dir = Directory.GetCurrentDirectory();
            string fileName = @"\out.ppm";
            StreamWriter sw = File.CreateText(dir + fileName);

            sw.WriteLine("P3");
            sw.WriteLine(nx.ToString() + " " + ny.ToString());
            sw.WriteLine("255");

            vec3 lower_left_corner = new vec3(-2, -1, -1); //offset
            vec3 horizontal = new vec3(4, 0, 0); //total width
            vec3 verticle = new vec3(0, 2, 0);  //total height
            vec3 origin = new vec3(0, 0, 0); //camera position
            for (int j = ny - 1; j >= 0; j--)
            {
                for (int i = 0; i < nx; i++)
                {
                    u = (i * 1.0f) / nx;
                    v = (j * 1.0f) / ny;

                    r = new ray(origin, lower_left_corner + horizontal * u + verticle * v);
                    color = GetColor(r);

                    nr = (int)(255.99 * color.r);
                    ng = (int)(255.99 * color.g);
                    nb = (int)(255.99 * color.b);

                    sw.WriteLine(nr.ToString() + " " + ng.ToString() + " " + nb.ToString());
                }
            }
            sw.Flush();
            sw.Close();
        }
    }
}
