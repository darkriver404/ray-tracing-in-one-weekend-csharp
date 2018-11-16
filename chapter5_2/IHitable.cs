namespace chapter5_2
{
    struct hit_record
    {
        public float t;
        public vec3 p;
        public vec3 normal;
    }

    interface hitable
    {
        bool hit(ray r, float t_min, float t_max, hit_record rec);
    }
}
