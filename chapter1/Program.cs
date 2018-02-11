using System.IO;

namespace chapter1
{
    class Program
    {
        static void Main(string[] args)
        {
            int nx = 200;
            int ny = 100;

            float r, g, b;
            int nr, ng, nb;

            string dir = Directory.GetCurrentDirectory();
            string fileName = @"\out.ppm";
            StreamWriter sw = File.CreateText(dir + fileName);

            sw.WriteLine("P3");
            sw.WriteLine(nx.ToString()+" "+ ny.ToString());
            sw.WriteLine("255");
            for (int j = ny - 1; j >= 0; j--)
            {
                for (int i = 0; i < nx; i++)
                {
                    r = (i * 1.0f)/ nx;
                    g = (j * 1.0f)/ ny;
                    b = 0.2f;

                    nr = (int)(255.99 * r);
                    ng = (int)(255.99 * g);
                    nb = (int)(255.99 * b);

                    sw.WriteLine(nr.ToString() + " " + ng.ToString() + " " + nb.ToString());
                }
            }
            sw.Flush();
            sw.Close();
        }
    }
}
