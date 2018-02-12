using System.IO;

namespace chapter2
{
    class Program
    {
        static void Main(string[] args)
        {
            int nx = 200;
            int ny = 100;

            vec3 v = new vec3();
            StreamWriter sw = File.CreateText(Directory.GetCurrentDirectory() + "\\out.ppm");

            sw.WriteLine("P3");
            sw.WriteLine(nx.ToString() + " " + ny.ToString());
            sw.WriteLine("255");
            for (int j = ny - 1; j >= 0; j--)
            {
                for (int i = 0; i < nx; i++)
                {
                    v.set((i * 1.0f) / nx, (j * 1.0f) / ny, 0.2f);
                    v *= 255.99f;
                    v = v.GetIntVec();
                    sw.WriteLine(v.ToString());
                }
            }
            sw.Flush();
            sw.Close();
        }
    }
}
