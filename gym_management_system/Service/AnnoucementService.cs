using gym_management_system.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace gym_management_system.Service
{
    public class AnnoucementService
    {
        public List<AnnoucementModl> GetAllAnnouncements(bool includePicture = false)
        {
            try
            {
                List<AnnoucementModl> announcements = new List<AnnoucementModl>();
                string query = $"SELECT {GetSelectColumns(includePicture)} FROM [pulseup_gym_management_system].[announcement]";
                SqlDataReader reader = Global.sqlService.SqlSelect(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AnnoucementModl announcement = new AnnoucementModl(
                            id: Convert.ToInt32(reader["id"]),
                            title: reader["title"].ToString(),
                            content: reader["content"].ToString(),
                            date: Convert.ToDateTime(reader["date"]),
                            base64Image: reader["image"].ToString(),
                            picture: Global.mangeImage.ConvertBase64ToImage(reader["image"].ToString()),
                            employeeModel: new EmployeeModel(id: Convert.ToInt32(reader["employeeID"]))
                        );

                        if (includePicture)
                        {
                            announcement.Picture = Global.mangeImage.ConvertBase64ToImage(reader["image"].ToString());
                        }

                        announcements.Add(announcement);
                    }

                    return announcements;
                }
                else
                {
                    Console.WriteLine("Error getting from GetAllAnnouncements: No records found");
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error getting from SQL Server GetAllAnnouncements: {ex.Message}");
                return null;
            }
        }

        public bool AddAnnouncement(AnnoucementModl announcementModel)
        {
            try
            {
                string query = $"INSERT INTO [pulseup_gym_management_system].[announcement] (title, content, date, image, employeeID) VALUES " +
                               $"( '{announcementModel.Title}', '{announcementModel.Content}', '{announcementModel.Date.ToString("yyyy-MM-dd")}', " +
                               $"'{announcementModel.Base64Image}', '{announcementModel.EmployeeModel?.Id}')";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Announcement created successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding Announcement: No rows affected");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error adding Announcement in SQL Server: {ex.Message}");
                return false;
            }
        }

        public bool UpdateAnnouncementAttributes(AnnoucementModl announcementModel, bool title = false, bool content = false, bool date = false, bool image = false, bool employeeId = false)
        {
            try
            {
                string query = "UPDATE [pulseup_gym_management_system].[announcement] SET";
                if (title)
                {
                    query += $" title = '{announcementModel.Title}',";
                }
                if (content)
                {
                    query += $" content = '{announcementModel.Content}',";
                }
                if (date)
                {
                    query += $" date = '{announcementModel.Date.ToString("yyyy-MM-dd")}',";
                }
                if (image)
                {
                    query += $" image = '{announcementModel.Base64Image}',";
                }
                if (employeeId)
                {
                    query += $" employeeID = '{announcementModel.EmployeeModel.Id}',";
                }

                if (query == "UPDATE [pulseup_gym_management_system].[announcement] SET")
                {
                    Console.WriteLine($"Error updating announcement attributes: No selected data modified");
                    return false;
                }

                query = query.Substring(0, query.Length - 1);
                query += $" WHERE id = {announcementModel.Id}";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Announcement attributes updated successfully for ID: {announcementModel.Id}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error updating announcement attributes: No rows affected for ID: {announcementModel.Id}");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error updating announcement attributes in SQL Server: {ex.Message}");
                return false;
            }
        }

        private string GetSelectColumns(bool includePicture)
        {
            if (includePicture)
            {
                return "*";
            }
            else
            {
                return "id, title, content, date, employeeID";
            }
        }
    }
}
