﻿using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system.Service
{
    public class ClassSubscriptionService
    {
        public List<ClassSubscriptionModel> GetClassSubscriptions()
        {
            try
            {
                List<ClassSubscriptionModel> subscriptions = new List<ClassSubscriptionModel>();
                string query = @"
                     SELECT 
                         cs.id AS class_subscription_id,
                         cs.start_date,
                         cs.num_of_attend,
                         m.id AS member_id,
                         m.first_name AS member_first_name,
                         m.second_name AS member_second_name,
                         e.id AS employee_id,
                         e.first_name AS employee_first_name,
                         e.second_name AS employee_second_name,
                         c.id AS class_id,
                         c.name
                     FROM 
                         [pulseup_gym_management_system].[class_subscription] cs
                     JOIN 
                         [pulseup_gym_management_system].[member] m ON cs.memberID = m.id
                     JOIN 
                         [pulseup_gym_management_system].[employee] e ON cs.employeeID = e.id
                     JOIN 
                         [pulseup_gym_management_system].[class] c ON cs.classID = c.id";
                SqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClassSubscriptionModel subscription = new ClassSubscriptionModel
                        {
                            Id = Convert.ToInt32(reader["class_subscription_id"]),
                            StartDate = Convert.ToDateTime(reader["start_date"]),
                            NumberOfAttend = Convert.ToInt32(reader["num_of_attend"]),

                            Member = new MemberModel
                            {
                                Id = Convert.ToInt32(reader["member_id"]),
                                FirstName = reader["member_first_name"].ToString(),
                                SecondName = reader["member_second_name"].ToString(),
                            },

                            Employee = new EmployeeModel
                            {
                                Id = Convert.ToInt32(reader["employee_id"]),
                                FirstName = reader["employee_first_name"].ToString(),
                                SecondName = reader["employee_second_name"].ToString(),
                            },

                            ClassModel = new ClassModel
                            {
                                Id = Convert.ToInt32(reader["class_id"]),
                                Name = reader["name"].ToString(),
                            },
                        };

                        subscriptions.Add(subscription);
                    }

                    return subscriptions;
                }
                else
                {
                    Console.WriteLine("Error getting class subscriptions: No records found");
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error getting class subscriptions from MySql: {ex.Message}");
                return null;
            }
        }

        public bool SubscribeClass(ClassModel classModel, MemberModel memberModel, EmployeeModel employeeModel)
        {
            try
            {
                string query = $@"INSERT INTO [pulseup_gym_management_system].[class_subscription] 
                (start_date, num_of_attend, memberID, employeeID, classID) VALUES 
                (GETDATE(), 0, {memberModel.Id}, 
                {employeeModel.Id}, {classModel.Id})";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Class Subscription created successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding class subscription: No rows affected");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error adding class subscription in MySql: {ex.Message}");
                return false;
            }
        }

        public bool CheckMemberInClassSubscription(int memberId, int classId)
        {
            try
            {
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                string query = $@"
                SELECT COUNT(*) 
                FROM [pulseup_gym_management_system].[class_subscription] cs
                INNER JOIN [pulseup_gym_management_system].[class] c ON cs.classID = c.id
                WHERE cs.memberID = {memberId}
                AND cs.classID = {classId}
                AND cs.start_date <= GETDATE()
                AND DATEADD(MONTH, 1, cs.start_date) >= GETDATE()";

                int count = Global.sqlService.sqlExecuteScalar(query);
                return count > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error checking member class subscription in MySql: {ex.Message}");
                return false;
            }
        }

        public bool UpdateClassAttributes(ClassSubscriptionModel classModel, bool numOfAttend = false, bool startDate = false, bool endDate = false)
        {
            try
            {
                string query = "UPDATE [pulseup_gym_management_system].[class_subscription] SET";
                if (numOfAttend)
                {
                    query += $" num_of_attend = {classModel.NumberOfAttend},";
                }
                if (startDate)
                {
                    query += $" start_date = '{classModel.StartDate.ToString("yyyy-MM-dd HH:mm:ss")}',";
                }
                if (endDate)
                {
                    query += $" end_date = '{classModel.EndDate.ToString("yyyy-MM-dd HH:mm:ss")}',";
                }

                if (query == "UPDATE [pulseup_gym_management_system].[class_subscription] SET")
                {
                    Console.WriteLine($"Error updating class attributes: No selected data modified");
                    return false;
                }

                query = query.Substring(0, query.Length - 1);
                query += $" WHERE id = {classModel.Id}";
                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Class attributes updated successfully for ID: {classModel.Id}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error updating class attributes: No rows affected for ID: {classModel.Id}");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error updating class attributes in MySql: {ex.Message}");
                return false;
            }
        }
        public List<ClassSubscriptionModel> SearchClassSubscriptions(string search, bool byId = false, bool byDate = false)
        {
            try
            {
                List<ClassSubscriptionModel> subscriptions = new List<ClassSubscriptionModel>();
                string query = @"
            SELECT 
                cs.id AS class_subscription_id,
                cs.start_date,
                cs.num_of_attend,
                m.id AS member_id,
                m.first_name AS member_first_name,
                m.second_name AS member_second_name,
                e.id AS employee_id,
                e.first_name AS employee_first_name,
                e.second_name AS employee_second_name
            FROM 
                [pulseup_gym_management_system].[class_subscription] cs
            JOIN 
                [pulseup_gym_management_system].[member] m ON cs.memberID = m.id
            JOIN 
                [pulseup_gym_management_system].[employee] e ON cs.employeeID = e.id
            WHERE ";

                if (byId && int.TryParse(search, out int id))
                {
                    query += $"cs.id = {id}";
                }
                else if (byDate && DateTime.TryParse(search, out DateTime date))
                {
                    query += $"cs.start_date = '{date.ToString("yyyy-MM-dd")}'";
                }
                else
                {
                    Console.WriteLine("Error getting from class_subscription search: No selected search type");
                    return null;
                }

                SqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClassSubscriptionModel subscription = new ClassSubscriptionModel
                        {
                            Id = Convert.ToInt32(reader["class_subscription_id"]),
                            StartDate = Convert.ToDateTime(reader["start_date"]),
                            NumberOfAttend = Convert.ToInt32(reader["num_of_attend"]),

                            Member = new MemberModel
                            {
                                Id = Convert.ToInt32(reader["member_id"]),
                                FirstName = reader["member_first_name"].ToString(),
                                SecondName = reader["member_second_name"].ToString(),
                            },

                            Employee = new EmployeeModel
                            {
                                Id = Convert.ToInt32(reader["employee_id"]),
                                FirstName = reader["employee_first_name"].ToString(),
                                SecondName = reader["employee_second_name"].ToString(),
                            }
                        };

                        subscriptions.Add(subscription);
                    }

                    return subscriptions;
                }
                else
                {
                    Console.WriteLine($"Error getting from class_subscription search: No records found '{search}'");
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error getting from MySql class_subscription search: {ex.Message}");
                return null;
            }
        }
        public bool AddClassSubscription(ClassSubscriptionModel classSubscriptionModel)
        {
            try
            {
                string query = $"INSERT INTO [pulseup_gym_management_system].[class_subscription] ( start_date, num_of_attend, memberID, employeeID, classID) VALUES " +
                               $"(' '{classSubscriptionModel.StartDate.ToString("yyyy-MM-dd")}', " +
                               $"'{classSubscriptionModel.NumberOfAttend}', '{classSubscriptionModel.Member.Id}', " +
                               $"'{classSubscriptionModel.Employee.Id}', '{classSubscriptionModel.ClassModel.Id}')";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Class subscription added successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding class subscription: No rows affected");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error adding class subscription in MySql: {ex.Message}");
                return false;
            }
        }
    }
}
