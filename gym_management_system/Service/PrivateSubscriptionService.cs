using gym_management_system.Models;
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
    public class PrivateSubscriptionService
    {
        public List<PrivateSubscriptionModel> GetPrivateSubscriptions()
        {
            try
            {
                List<PrivateSubscriptionModel> subscriptions = new List<PrivateSubscriptionModel>();
                string query = @"
            SELECT
                ps.id AS private_subscription_id,
                ps.num_of_attend,
                ps.subscription_date,
                ps.lessons_number,
                m.id AS member_id,
                m.first_name AS member_first_name,
                m.second_name AS member_second_name,
                e.id AS employee_id,
                e.first_name AS employee_first_name,
                e.second_name AS employee_second_name,
                t.id AS trainer_id,
                t.first_name AS trainer_first_name,
                t.second_name AS trainer_second_name
            FROM
                [pulseup_gym_management_system].[private_subscription] ps
            JOIN
                [pulseup_gym_management_system].[member] m ON ps.memberID = m.id
            JOIN
                [pulseup_gym_management_system].[employee] e ON ps.employeeID = e.id
            JOIN
                [pulseup_gym_management_system].[trainer] t ON ps.trainerID = t.id";
                SqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PrivateSubscriptionModel subscription = new PrivateSubscriptionModel
                        {
                            Id = Convert.ToInt32(reader["private_subscription_id"]),
                            NumberOfAttend = Convert.ToInt32(reader["num_of_attend"]),
                            StartDate = Convert.ToDateTime(reader["subscription_date"]),
                            LessonsNum = Convert.ToInt32(reader["lessons_number"]),

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

                            Trainer = new TrainerModel
                            {
                                Id = Convert.ToInt32(reader["trainer_id"]),
                                FirstName = reader["trainer_first_name"].ToString(),
                                SecondName = reader["trainer_second_name"].ToString(),
                            },
                        };

                        subscriptions.Add(subscription);
                    }

                    return subscriptions;
                }
                else
                {
                    Console.WriteLine("Error getting private subscriptions: No records found");
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error getting private subscriptions from MySql: {ex.Message}");
                return null;
            }
        }
        public static List<PrivateSubscriptionModel> SearchPrivateSubscriptions(string searchParam, bool byId = true, bool byDate = false)
        {
            try
            {
                List<PrivateSubscriptionModel> privateSubscriptions = new List<PrivateSubscriptionModel>();
                string query = $@"
            SELECT 
                ps.id AS subscription_id,
                ps.num_of_attend,
                ps.subscription_date,
                m.id AS member_id,
                m.first_name AS member_first_name,
                m.second_name AS member_second_name,
                e.id AS employee_id,
                e.first_name AS employee_first_name,
                e.second_name AS employee_second_name,
                t.id AS trainer_id,
                t.first_name AS trainer_first_name,
                t.second_name AS trainer_second_name,
                ps.lessons_number
            FROM 
                [pulseup_gym_management_system].[private_subscription] ps
            JOIN 
                [pulseup_gym_management_system].[member] m ON ps.memberID = m.id
            JOIN 
                [pulseup_gym_management_system].[employee] e ON ps.employeeID = e.id
            JOIN 
                [pulseup_gym_management_system].[trainer] t ON ps.trainerID = t.id
            WHERE ";

                if (byId && int.TryParse(searchParam, out int id))
                {
                    query += $"ps.id = {id}";
                }
                else if (byDate && DateTime.TryParse(searchParam, out DateTime date))
                {
                    query += $"ps.subscription_date = '{date.ToString("yyyy-MM-dd")}'";
                }
                else
                {
                    Console.WriteLine($"Error getting from private_subscription search: No selected search type");
                    return null;
                }

                using (SqlDataReader reader = Global.sqlService.SqlSelect(query))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MemberModel member = new MemberModel
                            {
                                Id = Convert.ToInt32(reader["memberID"]),
                                FirstName = reader["member_first_name"].ToString(),
                                SecondName = reader["member_second_name"].ToString()
                            };

                            EmployeeModel employee = new EmployeeModel
                            {
                                Id = Convert.ToInt32(reader["employeeID"]),
                                FirstName = reader["employee_first_name"].ToString(),
                                SecondName = reader["employee_second_name"].ToString()
                            };

                            TrainerModel trainer = new TrainerModel
                            {
                                Id = Convert.ToInt32(reader["trainerID"]),
                                FirstName = reader["trainer_first_name"].ToString(),
                                SecondName = reader["trainer_second_name"].ToString()
                            };

                            PrivateSubscriptionModel privateSubscription = new PrivateSubscriptionModel
                            {
                                Id = Convert.ToInt32(reader["subscription_id"]),
                                NumberOfAttend = Convert.ToInt32(reader["num_of_attend"]),
                                StartDate = Convert.ToDateTime(reader["subscription_date"]),
                                Member = member,
                                Employee = employee,
                                Trainer = trainer,
                                LessonsNum = Convert.ToInt32(reader["lessons_number"])
                            };

                            privateSubscriptions.Add(privateSubscription);
                        }

                        return privateSubscriptions;
                    }
                    else
                    {
                        Console.WriteLine($"Error getting from private_subscription search: No records found '{searchParam}'");
                        return null;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error getting from MySql private_subscription search: {ex.Message}");
                return null;
            }

        }

        public bool CheckMemberPrivateSubscription(int memberId)
        {
            try
            {
                string query = $@"
                SELECT COUNT(*) 
                FROM [pulseup_gym_management_system].[private_subscription] ps
                WHERE ps.memberID = {memberId}
                AND ps.subscription_date <= GETDATE()
                AND DATEADD(MONTH, 1, ps.subscription_date) >= GETDATE()
                AND ps.num_of_attend < ps.lessons_number
                ";

                int count = Global.sqlService.sqlExecuteScalar(query);
                return count > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error checking member private subscription in MySql: {ex.Message}");
                return false;
            }
        }

        public bool SupscribePrivate(int lessons_number, MemberModel memberModel, EmployeeModel employeeModel, TrainerModel trainerModel)
        {
            try
            {
                string query = $@"INSERT INTO [pulseup_gym_management_system].[private_subscription] 
            (num_of_attend, subscription_date, lessons_number, memberID, employeeID, trainerID) VALUES 
            (0, GETDATE(), {lessons_number}, {memberModel.Id}, {employeeModel.Id}, {trainerModel.Id})";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Private Subscription created successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding private subscription: No rows affected");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error adding private subscription in MySql: {ex.Message}");
                return false;
            }
        }

        public bool UpdatePrivateSubscriptionAttributes(PrivateSubscriptionModel privateSubscription, bool numOfAttend = false, bool startDate = false, bool lessonsNum = false)
        {
            try
            {
                string query = "UPDATE [pulseup_gym_management_system].[private_subscription] SET";

                if (numOfAttend)
                {
                    query += $" num_of_attend = {privateSubscription.NumberOfAttend},";
                }

                if (startDate)
                {
                    query += $" subscription_date = '{privateSubscription.StartDate.ToString("yyyy-MM-dd HH:mm:ss")}',";
                }

                if (lessonsNum)
                {
                    query += $" lessons_number = {privateSubscription.LessonsNum},";
                }

                if (query == "UPDATE private_subscription SET")
                {
                    Console.WriteLine($"Error updating private_subscription attributes: No selected data modified");
                    return false;
                }

                query = query.Substring(0, query.Length - 1);
                query += $" WHERE id = {privateSubscription.Id}";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Private subscription attributes updated successfully for ID: {privateSubscription.Id}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error updating private_subscription attributes: No rows affected for ID: {privateSubscription.Id}");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error updating private_subscription attributes in MySql: {ex.Message}");
                return false;
            }
        }

        public static List<PrivateSubscriptionModel> GetAllPrivateSubscriptions()
        {
            try
            {
                List<PrivateSubscriptionModel> privateSubscriptions = new List<PrivateSubscriptionModel>();
                string query = $@"
            SELECT 
                ps.id AS subscription_id,
                ps.num_of_attend,
                ps.subscription_date,
                m.id AS member_id,
                m.first_name AS member_first_name,
                m.second_name AS member_second_name,
                e.id AS employee_id,
                e.first_name AS employee_first_name,
                e.second_name AS employee_second_name,
                t.id AS trainer_id,
                t.first_name AS trainer_first_name,
                t.second_name AS trainer_second_name,
                ps.lessons_number
            FROM 
                [pulseup_gym_management_system].[private_subscription] ps
            JOIN 
                [pulseup_gym_management_system].[member] m ON ps.memberID = m.id
            JOIN 
                [pulseup_gym_management_system].[employee] e ON ps.employeeID = e.id
            JOIN 
                [pulseup_gym_management_system].[trainer] t ON ps.trainerID = t.id;";

                using (SqlDataReader reader = Global.sqlService.SqlSelect(query))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MemberModel member = new MemberModel
                            {
                                Id = Convert.ToInt32(reader["memberID"]),
                                FirstName = reader["member_first_name"].ToString(),
                                SecondName = reader["member_second_name"].ToString()
                            };

                            EmployeeModel employee = new EmployeeModel
                            {
                                Id = Convert.ToInt32(reader["employeeID"]),
                                FirstName = reader["employee_first_name"].ToString(),
                                SecondName = reader["employee_second_name"].ToString()
                            };

                            TrainerModel trainer = new TrainerModel
                            {
                                Id = Convert.ToInt32(reader["trainerID"]),
                                FirstName = reader["trainer_first_name"].ToString(),
                                SecondName = reader["trainer_second_name"].ToString()
                            };

                            PrivateSubscriptionModel privateSubscription = new PrivateSubscriptionModel
                            {
                                Id = Convert.ToInt32(reader["subscription_id"]),
                                NumberOfAttend = Convert.ToInt32(reader["num_of_attend"]),
                                StartDate = Convert.ToDateTime(reader["subscription_date"]),
                                Member = member,
                                Employee = employee,
                                Trainer = trainer,
                                LessonsNum = Convert.ToInt32(reader["lessons_number"])
                            };

                            privateSubscriptions.Add(privateSubscription);
                        }
                    }
                }

                return privateSubscriptions;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error getting private_subscriptions: {ex.Message}");
                return null;
            }
        }

        public static bool InsertPrivateSubscription(PrivateSubscriptionModel privateSubscription)
        {
            try
            {
                string query = $@"
            INSERT INTO [pulseup_gym_management_system].[private_subscription] (num_of_attend, subscription_date, lessons_number, memberID, employeeID, trainerID)
            VALUES (
                '{privateSubscription.NumberOfAttend}', 
                '{privateSubscription.StartDate.ToString("yyyy-MM-dd")}', 
                '{privateSubscription.LessonsNum}', 
                '{privateSubscription.Member.Id}', 
                '{privateSubscription.Employee.Id}', 
                '{privateSubscription.Trainer.Id}');";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Private subscription added successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding private subscription: No rows affected");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error adding private subscription in MySql: {ex.Message}");
                return false;
            }
        }
    }
}
