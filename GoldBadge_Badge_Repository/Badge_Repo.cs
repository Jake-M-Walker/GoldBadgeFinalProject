using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldBadge_Badge_POCO;

namespace GoldBadge_Badge_Repository
{
    public class Badge_Repo
    {
        private Dictionary<int, Badge> _badges = new Dictionary<int, Badge>();

        //Create
        public bool CreateBadge(Badge badge)
        {
            if (_badges.ContainsKey(badge.ID))
            {
                return false;
            }
            else
            {
                _badges.Add(badge.ID, badge);
                return true;
            }
        }

        //Read
        public Dictionary<int, Badge> GetAllBadges()
        {
            return _badges;
        }

        public Badge GetBadgeByID(int id)
        {
            if (_badges.ContainsKey(id))
            {
                return _badges[id];

            }
            else return null;
        }

        //Update
        public bool UpdateBadge(Badge newBadge)
        {
            if (_badges.ContainsKey(newBadge.ID))
            {
                Badge oldBadge = _badges[newBadge.ID];
                oldBadge.Name = newBadge.Name;
                oldBadge.Doors = newBadge.Doors;
                return true;
            } else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteBadge(int id)
        {
            if (_badges.ContainsKey(id))
            {
                _badges.Remove(id);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
