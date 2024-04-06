using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym_management_system.Service
{
    public class PackgeSupscribtionService
    {
        public List<PackgeSubscriptionModel> GetPackageSubscriptions()
        {
            try
            {
                List<PackgeSubscriptionModel> subscriptions = new List<PackgeSubscriptionModel>();
                string query = @"
            SELECT
                ps.id AS package_subscription_id,
                ps.subscription_date,
                ps.remain_invatation,
                m.id AS member_id,
                m.first_name AS member_first_name,
                m.second_name AS member_second_name,
                e.id AS employee_id,
                e.first_name AS employee_first_name,
                e.second_name AS employee_second_name,
                p.id AS package_id,
                p.name AS package_name
            FROM
                [pulseup_gym_management_system].[packge_subscription] ps
            JOIN
                [pulseup_gym_management_system].[member] m ON ps.memberID = m.id
            JOIN
                [pulseup_gym_management_system].[employee] e ON ps.employeeID = e.id
            JOIN
                [pulseup_gym_management_system].[packge] p ON ps.packgeID = p.id";
                SqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PackgeSubscriptionModel subscription = new PackgeSubscriptionModel()
                        {
                            Id = Convert.ToInt32(reader["package_subscription_id"]),
                            StartDate = Convert.ToDateTime(reader["subscription_date"]),
                            RemainInvatation = Convert.ToInt32(reader["remain_invatation"]),

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

                            PackgeModel = new PackgeModel
                            {
                                Id = Convert.ToInt32(reader["package_id"]),
                                Name = reader["package_name"].ToString(),
                            },
                        };

                        subscriptions.Add(subscription);
                    }

                    return subscriptions;
                }
                else
                {
                    Console.WriteLine("Error getting package subscriptions: No records found");
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error getting package subscriptions from MySql: {ex.Message}");
                return null;
            }
        }
        public bool CheckMemberInPackageSubscription(int memberId)
        {
            try
            {
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                string query = $@"
                SELECT COUNT(*) 
                FROM [pulseup_gym_management_system].[packge_subscription] ps
                INNER JOIN [pulseup_gym_management_system].[packge] p ON ps.packgeID = p.id
                INNER JOIN [pulseup_gym_management_system].[month_offer] mo ON p.month_offerID = mo.id
                WHERE ps.memberID = {memberId}
                AND ps.subscription_date <= GETDATE()
                AND DATEADD(MONTH ,mo.num_of_months, subscription_date) >= GETDATE()";

                int count = Global.sqlService.sqlExecuteScalar(query);
                return count > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error checking member subscription in MySql: {ex.Message}");
                return false;
            }
        }

        public bool SubscribePackage(PackgeModel packgeModel, MemberModel memberModel, EmployeeModel employeeModel, List<ClassModel> classModels)
        {
            try
            {
                string monthSubscriptionQuery = $"INSERT INTO [pulseup_gym_management_system].[month_subscription] (num_of_attend, start_date, remain_freze_day, memberID, employeeID, monthID) VALUES (0, GETDATE(), (SELECT max_num_freze FROM [pulseup_gym_management_system].[month_offer] WHERE id = {packgeModel.MonthOffer.Id}), {memberModel.Id}, {employeeModel.Id}, {packgeModel.MonthOffer.Id});";
                int monthRowsAffected = Global.sqlService.SqlNonQuery(monthSubscriptionQuery);
                if (monthRowsAffected == 0)
                {
                    Console.WriteLine("Error adding month subscription: No rows affected");
                    return false;
                }
                int lastClassSubscriptionID = 0;
                string getLastIDQueryc = "SELECT TOP 1 id FROM [pulseup_gym_management_system].[class_subscription] ORDER BY id DESC";
                SqlDataReader reader1 = Global.sqlService.SqlSelect(getLastIDQueryc);
                if (reader1.Read())
                {
                    lastClassSubscriptionID = reader1.GetInt32(0);
                    reader1.Close();
                    Console.WriteLine($"Last inserted class_subscriptionID: {lastClassSubscriptionID}");
                }
                string valuesPart = string.Join(", ", classModels.Select(classModel =>
                    $"(0, GETDATE(), {employeeModel.Id}, {memberModel.Id}, {classModel.Id})"
                ));
                string classSubscriptionQuery = $"INSERT INTO [pulseup_gym_management_system].[class_subscription] (num_of_attend, start_date, employeeID, memberID, classID) VALUES {valuesPart};";
                int classRowsAffected = Global.sqlService.SqlNonQuery(classSubscriptionQuery);

                if (classRowsAffected == 0)
                {
                    Console.WriteLine("Error adding class subscriptions: No rows affected");
                    return false;
                }
                int lastMonthSubscriptionID;
                string getLastIDQuery = "SELECT TOP 1 id FROM [pulseup_gym_management_system].[month_subscription] ORDER BY id DESC";
                SqlDataReader reader = Global.sqlService.SqlSelect(getLastIDQuery);
                if (reader.Read())
                {
                    lastMonthSubscriptionID = reader.GetInt32(0);
                    reader.Close();
                    Console.WriteLine($"Last inserted month_subscriptionID: {lastMonthSubscriptionID}");
                }
                else
                {
                    reader.Close();
                    Console.WriteLine("Error retrieving last inserted ID for month_subscription");
                    return false;
                }
                string packgeSubscriptionQuery = $"INSERT INTO [pulseup_gym_management_system].[packge_subscription] (subscription_date, remain_invatation, memberID, employeeID, packgeID, month_subscriptionID) VALUES (GETDATE(), (SELECT num_of_invatation FROM [pulseup_gym_management_system].[packge] WHERE id = {packgeModel.Id}), {memberModel.Id}, {employeeModel.Id}, {packgeModel.Id}, {lastMonthSubscriptionID});";

                Console.WriteLine($"Executing query: {packgeSubscriptionQuery}");

                int packgeRowsAffected = Global.sqlService.SqlNonQuery(packgeSubscriptionQuery);
                if (packgeRowsAffected > 0)
                {
                    int lastpackgeSubscriptionID = 0;
                    string getLastIDQueryp = "SELECT TOP 1 id FROM [pulseup_gym_management_system].[packge_subscription] ORDER BY id DESC";
                    SqlDataReader reader2 = Global.sqlService.SqlSelect(getLastIDQueryp);
                    if (reader2.Read())
                    {
                        lastpackgeSubscriptionID = reader2.GetInt32(0);
                        reader2.Close();
                        Console.WriteLine($"Last inserted class_subscriptionID: {lastpackgeSubscriptionID}");
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding package subscription: No rows affected");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error adding subscription in MySql: {ex.Message}");
                return false;
            }
        }

    }
}
