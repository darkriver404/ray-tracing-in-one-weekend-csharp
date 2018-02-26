using System.IO;

namespace chapter3
{
    class Program
    {
        static vec3 GetColor(ray r)
        {
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

            vec3 lower_left_corner = new vec3(-2,-1,-1); //offset
            vec3 horizontal = new vec3(4,0,0); //total width
            vec3 verticle = new vec3(0,2,0);  //total height
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
