using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class PotholeSqlDAO : IPotholeDAO
    {
        private string connectionString;

        public PotholeSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Pothole> GetAllPotholes()
        {

            List<Pothole> potholes = new List<Pothole>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // date reported moved to report table 
                string sql = "SELECT p.pothole_id, p.severity, p.latitude, p.longitude, p.address, p.city, r.report_date, r.is_Reviewed," +
                    " r.report_notes, i.inspection_date, i.is_Inspected, i.inspection_notes, re.repair_date, re.is_Repaired, re.repair_notes " +
                    "FROM potholes p LEFT OUTER JOIN reports r ON r.pothole_id = p.pothole_id LEFT OUTER JOIN inspections i ON i.pothole_id = p.pothole_id " +
                    "LEFT OUTER JOIN repairs re ON re.pothole_id = p.pothole_id"; 
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Pothole newPothole = new Pothole();
                    newPothole.Id = Convert.ToInt32(reader["pothole_id"]);
                    newPothole.Severity = Convert.ToInt32(reader["severity"]);
                    newPothole.Latitude = Convert.ToString(reader["latitude"]);
                    newPothole.Longitude = Convert.ToString(reader["longitude"]);
                    newPothole.Address = Convert.ToString(reader["address"]);
                    newPothole.City = Convert.ToString(reader["city"]);
                    newPothole.ReportDate = GetNullableDate(reader, "report_date");
                    newPothole.IsReviewed = GetNullableBool(reader,"is_Reviewed");
                    newPothole.ReportNotes = Convert.ToString(reader["report_notes"]);
                    newPothole.InspectionDate = GetNullableDate(reader, "inspection_date");
                    newPothole.IsInspected = GetNullableBool(reader, "is_Inspected");
                    newPothole.InspectionNotes = Convert.ToString(reader["inspection_notes"]);
                    newPothole.RepairDate = GetNullableDate(reader, "repair_date");
                    newPothole.IsRepaired = GetNullableBool(reader, "is_Repaired");
                    newPothole.RepairNotes = Convert.ToString(reader["repair_notes"]);

                    potholes.Add(newPothole);
                }

            }
            return potholes;
        }

        private static DateTime? GetNullableDate(SqlDataReader reader, string column)
        {
            if (reader[column] != DBNull.Value)
            {
                return Convert.ToDateTime(reader[column]);
            }
            else
            {
                return null;
            }
        }

        private static bool GetNullableBool(SqlDataReader reader, string column)
        {
            if (reader[column] != DBNull.Value)
            {
                return Convert.ToBoolean(reader[column]);
            }
            else
            {
                return default;
            }
        }

        public bool DeletePothole(int potholeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM reports WHERE pothole_id = @potholeId; DELETE FROM potholes WHERE pothole_id = @potholeId";

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@potholeId", potholeId);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }

        public Pothole GetPothole(int potholeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT p.pothole_id, p.severity, p.latitude, p.longitude, p.address, p.city, r.report_date, r.is_Reviewed," +
                    " r.report_notes, i.inspection_date, i.is_Inspected, i.inspection_notes, re.repair_date, re.is_Repaired, re.repair_notes " +
                    "FROM potholes p LEFT OUTER JOIN reports r ON r.pothole_id = p.pothole_id LEFT OUTER JOIN inspections i ON i.pothole_id = p.pothole_id " +
                    "LEFT OUTER JOIN repairs re ON re.pothole_id = p.pothole_id WHERE p.pothole_id = @potholeId";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@potholeId", potholeId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Pothole pothole = GetPotholeFromDataReader(reader);
                    return pothole;
                }
            }
            return null;
        }

        public Pothole GetPotholeFromDataReader(SqlDataReader reader)
        {
            return new Pothole()
            {
            Id = Convert.ToInt32(reader["pothole_id"]),
            Severity = Convert.ToInt32(reader["severity"]),
            Latitude = Convert.ToString(reader["latitude"]),
            Longitude = Convert.ToString(reader["longitude"]),
            Address = Convert.ToString(reader["address"]),
            City = Convert.ToString(reader["city"]),
            ReportDate = Convert.ToDateTime(reader["report_date"]),
            IsReviewed = GetNullableBool(reader, "is_Reviewed"),
            ReportNotes = Convert.ToString(reader["report_notes"]),
            InspectionDate = GetNullableDate(reader, "inspection_date"),
            IsInspected = GetNullableBool(reader, "is_Inspected"),
            InspectionNotes = Convert.ToString(reader["inspection_notes"]),
            RepairDate = GetNullableDate(reader, "repair_date"),
            IsRepaired = GetNullableBool(reader, "is_Repaired"),
            RepairNotes = Convert.ToString(reader["repair_notes"]),
            };
        }

        public Pothole AddPothole(Pothole newPothole)
        {
           
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO potholes (severity, latitude,longitude,address,city)" +
                    " VALUES(@severity,@latitude, @longitude, @address, @city);" +
                    " SELECT @@IDENTITY";
                SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@severity", newPothole.Severity);
                command.Parameters.AddWithValue("@latitude", newPothole.Latitude);
                command.Parameters.AddWithValue("@longitude", newPothole.Longitude);
                command.Parameters.AddWithValue("@address", newPothole.Address);
                command.Parameters.AddWithValue("@city", newPothole.City);

                int id = Convert.ToInt32(command.ExecuteScalar());
                newPothole.Id = id;

                string addReport = "INSERT INTO reports (pothole_id, report_date) VALUES(@id, @reportDate)";
                SqlCommand c = new SqlCommand(addReport, conn);
                c.Parameters.AddWithValue("@id", newPothole.Id);
                c.Parameters.AddWithValue("@reportDate", newPothole.ReportDate);
                c.ExecuteNonQuery();

            }
                return newPothole;
        }

        public bool ScheduleInspection(int potholeId, DateTime? date)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE reports SET reports.is_Reviewed = 1 WHERE pothole_id = @pothole_id; " +
                             "INSERT INTO inspections (pothole_id, inspection_date) VALUES(@pothole_id, @inspectionDate)";
                SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@pothole_id", potholeId);
                command.Parameters.AddWithValue("@inspectionDate", date);

                int rowsAffeced = command.ExecuteNonQuery();

                return rowsAffeced > 0;
            }
        }

        public bool UnScheduleInspection(int potholeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE reports SET reports.is_Reviewed = 0 WHERE pothole_id = @pothole_id; " +
                             "DELETE FROM inspections WHERE pothole_id = @pothole_id";
                SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@pothole_id", potholeId);

                int rowsAffeced = command.ExecuteNonQuery();

                return rowsAffeced > 0;
            }
        }

        public bool ScheduleRepair(int potholeId, Pothole pothole)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE inspections SET inspections.is_Inspected = 1 WHERE pothole_id = @pothole_id; " +
                             "UPDATE potholes SET severity = @severity WHERE pothole_id = @pothole_id; " +
                             "INSERT INTO repairs (pothole_id, repair_date) VALUES(@pothole_id, @repairDate)";
                SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@pothole_id", potholeId);
                command.Parameters.AddWithValue("@repairDate", pothole.RepairDate);
                command.Parameters.AddWithValue("@severity", pothole.Severity);

                int rowsAffeced = command.ExecuteNonQuery();

                return rowsAffeced > 0;
            }
        }

        public bool UnScheduleRepair(int potholeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE inspections SET inspections.is_Inspected = 0 WHERE pothole_id = @pothole_id; " +
                             "UPDATE potholes SET severity = 0 WHERE pothole_id = @pothole_id; " +
                             "DELETE from repairs WHERE pothole_id = @pothole_id;";
                SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@pothole_id", potholeId);

                int rowsAffeced = command.ExecuteNonQuery();

                return rowsAffeced > 0;
            }
        }

        public bool MarkAsRepaired(int potholeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE repairs SET repairs.is_Repaired = 1 WHERE pothole_id = @pothole_id; ";
                            
                SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@pothole_id", potholeId);

                int rowsAffeced = command.ExecuteNonQuery();

                return rowsAffeced > 0;
            }
        }

        public bool MarkAsUnrepaired(int potholeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE repairs SET repairs.is_Repaired = 0 WHERE pothole_id = @pothole_id; ";

                SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@pothole_id", potholeId);

                int rowsAffeced = command.ExecuteNonQuery();

                return rowsAffeced > 0;
            }
        }
    }   
}
