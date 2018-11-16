using System.Collections.Generic;

namespace chapter5_2
{
    class hitable_list : hitable
    {
        public List<hitable_list> list;
        public int list_size;

        public hitable_list()
        {
        }

        public hitable_list(List<hitable_list> l, int n)
        {
            list = l;
            list_size = n;
        }

        public bool hit(ray r, float t_min, float t_max, hit_record rec)
        {
            hit_record temp_rec = new hit_record();
            bool hit_anything = false;
            double closest_so_far = t_max;
            for(int i = 0;i<list_size;i++)
            {
                if(list[i].hit(r, t_min, (float)closest_so_far, temp_rec))
                {
                    hit_anything = true;
                    closest_so_far = temp_rec.t;
                    rec = temp_rec;
                }
            }
            return hit_anything;
        }
    }
}
