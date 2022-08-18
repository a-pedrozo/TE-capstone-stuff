using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IPotholeDAO
    {
        List<Pothole> GetAllPotholes();

        Pothole GetPothole(int potholeId);

        public bool DeletePothole(int potholeId);

        Pothole AddPothole(Pothole newPothole);

        public bool ScheduleInspection(int potholeId, DateTime? date);

        public bool UnScheduleInspection(int potholeId);

        public bool ScheduleRepair(int potholeId, Pothole pothole);

        public bool UnScheduleRepair(int potholeId);

        public bool MarkAsRepaired(int potholeId);

        public bool MarkAsUnrepaired(int potholeId);
    }
}
