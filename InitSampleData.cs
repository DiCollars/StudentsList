using StudentsList.Models;
using System.Linq;

namespace StudentsList
{
    public class InitSampleData
    {
        public static void Initialization(StudentGroupContext _db)
        {
            Group radiophysics = new Group() { GroupName = "Radiophysics" };
            Group microelectronics = new Group() { GroupName = "Microelectronics" };
            Group generalPhysics = new Group() { GroupName = "General physics" };

            if ((_db.Groups.Any(p => p.GroupName == radiophysics.GroupName) &&
                        _db.Groups.Any(p => p.GroupName == microelectronics.GroupName) &&
                        _db.Groups.Any(p => p.GroupName == generalPhysics.GroupName)) != true)
            {
                _db.Groups.AddRange(radiophysics, microelectronics, generalPhysics);
                _db.SaveChanges();
            }
        }
    }
}
