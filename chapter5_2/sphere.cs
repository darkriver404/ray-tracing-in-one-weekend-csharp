using System;

namespace chapter5_2
{
    class sphere : hitable
    {
        public vec3 center;
        public float radius;

        public sphere()
        {
        }

        public sphere(vec3 cen, float rad)
        {
            center = cen;
            radius = rad;
        }

        public bool hit(ray r, float t_min, float t_max, hit_record rec)
        {
            vec3 oc = r.Origin - center;
            float a = vec3.dot(r.Direction, r.Direction);
            float b = vec3.dot(oc, r.Direction);
            float c = vec3.dot(oc, oc) - radius * radius;
            float discriminant = b * b - a * c;
            if(discriminant > 0)
            {
                float temp = (-b - (float)Math.Sqrt(discriminant)) / a;
                if(temp< t_max && temp>t_min)
                {
                    rec.t = temp;
                    rec.p = r.point_at_parameter(rec.t);
                    rec.normal = (rec.p - center) / radius;
                    return true;
                }
                temp = (-b + (float)Math.Sqrt(discriminant)) / a;
                if (temp < t_max && temp > t_min)
                {
                    rec.t = temp;
                    rec.p = r.point_at_parameter(rec.t);
                    rec.normal = (rec.p - center) / radius;
                    return true;
                }
            }
            return false;
        }

    }
}
