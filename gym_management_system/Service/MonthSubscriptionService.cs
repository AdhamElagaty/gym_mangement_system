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
    public class MonthSubscriptionService
    {
        public List<MonthSubscriptionModel> GetMonthSubscriptions()
        {
            try
            {
                List<MonthSubscriptionModel> subscriptions = new List<MonthSubscriptionModel>();
                string query = @"
            SELECT
                ms.id AS month_subscription_id,
                ms.num_of_attend,
                ms.start_date,
                ms.remain_freze_day,
                m.id AS member_id,
                m.first_name AS member_first_name,
                m.second_name AS member_second_name,
                e.id AS employee_id,
                e.first_name AS employee_first_name,
                e.second_name AS employee_second_name,
                mo.id AS month_offer_id,
                mo.max_num_freze,
                mo.num_of_months,
                mo.price
            FROM
                [pulseup_gym_management_system].[month_subscription] ms
            JOIN
                [pulseup_gym_management_system].[member] m ON ms.memberID = m.id
            JOIN
                [pulseup_gym_management_system].[employee] e ON ms.employeeID = e.id
            JOIN
                [pulseup_gym_management_system].[month_offer] mo ON ms.monthID = mo.id";
                SqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MonthSubscriptionModel subscription = new MonthSubscriptionModel
                        {
                            Id = Convert.ToInt32(reader["month_subscription_id"]),
                            NumberOfAttend = Convert.ToInt32(reader["num_of_attend"]),
                            StartDate = Convert.ToDateTime(reader["start_date"]),
                            RemainFrezeDay = Convert.ToInt32(reader["remain_freze_day"]),

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

                            MonthOffer = new MonthOfferModel
                            {
                                Id = Convert.ToInt32(reader["month_offer_id"]),
                                MaxNumFreze = Convert.ToInt32(reader["max_num_freze"]),
                                NumOfMonth = Convert.ToInt32(reader["num_of_months"]),
                                Price = Convert.ToInt32(reader["price"]),
                            },
                        };

                        subscriptions.Add(subscription);
                    }

                    return subscriptions;
                }
                else
                {
                    Console.WriteLine("Error getting month subscriptions: No records found");
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error getting month subscriptions from MySql: {ex.Message}");
                return null;
            }
        }
        public bool CheckMemberInMonthSubscription(int memberId)
        {
            try
            {
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                string query = $@"
                SELECT COUNT(*) 
                FROM [pulseup_gym_management_system].[month_subscription] ms
                INNER JOIN [pulseup_gym_management_system].[month_offer] mo ON ms.monthID = mo.id
                WHERE ms.memberID = {memberId}
                AND ms.start_date <= GETDATE()
                AND DATEADD(MONTH, mo.num_of_months, ms.start_date) >= GETDATE()";

                int count = Global.sqlService.sqlExecuteScalar(query);
                return count > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error checking member month subscription in MySql: {ex.Message}");
                return false;
            }
        }

        public List<MonthSubscriptionModel> SearchMonthSubscription(string search, bool byId = false, bool byDate = false)
        {
            try
            {
                List<MonthSubscriptionModel> subscriptions = new List<MonthSubscriptionModel>();
                string query = $@"
            SELECT 
                ms.id AS subscription_id,
                ms.num_of_attend,
                ms.start_date,
                ms.remain_freze_day,
                m.id AS member_id,
                m.first_name AS member_first_name,
                m.second_name AS member_second_name,
                e.id AS employee_id,
                e.first_name AS employee_first_name,
                e.second_name AS employee_second_name,
                mo.id AS month_offer_id,
                mo.max_num_freze,
                mo.num_of_months,
                mo.price
            FROM 
                [pulseup_gym_management_system].[month_subscription] ms
            JOIN 
                [pulseup_gym_management_system].[member] m ON ms.memberID = m.id
            JOIN 
                [pulseup_gym_management_system].[employee] e ON ms.employeeID = e.id
            JOIN 
                [pulseup_gym_management_system].[month_offer] mo ON ms.monthID = mo.id
            WHERE ";

                if (byId && int.TryParse(search, out int id))
                {
                    query += $"ms.id = {id}";
                }
                else if (byDate && DateTime.TryParse(search, out DateTime date))
                {
                    query += $"ms.start_date = '{date.ToString("yyyy-MM-dd")}'";
                }
                else
                {
                    Console.WriteLine($"Error getting from month_subscription search: No selected search type");
                    return null;
                }

                SqlDataReader reader = Global.sqlService.SqlSelect(query);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MonthOfferModel monthOffer = new MonthOfferModel
                        {
                            Id = Convert.ToInt32(reader["month_offer_id"]),
                            MaxNumFreze = Convert.ToInt32(reader["max_num_freze"]),
                            NumOfMonth = Convert.ToInt32(reader["num_of_months"]),
                            Price = Convert.ToInt32(reader["price"])
                        };

                        MemberModel member = new MemberModel
                        {
                            Id = Convert.ToInt32(reader["member_id"]),
                            FirstName = reader["member_first_name"].ToString(),
                            SecondName = reader["member_second_name"].ToString()
                        };

                        EmployeeModel employee = new EmployeeModel
                        {
                            Id = Convert.ToInt32(reader["employee_id"]),
                            FirstName = reader["employee_first_name"].ToString(),
                            SecondName = reader["employee_second_name"].ToString()
                        };

                        MonthSubscriptionModel subscription = new MonthSubscriptionModel
                        {
                            Id = Convert.ToInt32(reader["subscription_id"]),
                            NumberOfAttend = Convert.ToInt32(reader["num_of_attend"]),
                            StartDate = Convert.ToDateTime(reader["start_date"]),
                            RemainFrezeDay = Convert.ToInt32(reader["remain_freze_day"]),
                            MonthOffer = monthOffer,
                            Member = member,
                            Employee = employee
                        };

                        subscriptions.Add(subscription);
                    }

                    return subscriptions;
                }
                else
                {
                    Console.WriteLine($"Error getting from month_subscription search: No records found '{search}'");
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error getting from MySql month_subscription search: {ex.Message}");
                return null;
            }
        }

        public bool SubscribeMonth(MonthOfferModel monthOfferModel, MemberModel memberModel, EmployeeModel employeeModel)
        {
            try
            {
                string query = $@"INSERT INTO [pulseup_gym_management_system].[month_subscription] 
                                (num_of_attend, start_date, remain_freze_day, memberID, employeeID, monthID) VALUES 
                                (0, GETDATE(), (SELECT max_num_freze FROM [pulseup_gym_management_system].[month_offer] WHERE id = {monthOfferModel.Id}), {memberModel.Id}, {employeeModel.Id}, {monthOfferModel.Id})";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Month Subscription created successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding month subscription: No rows affected");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error adding month subscription in MySql: {ex.Message}");
                return false;
            }
        }

        public bool AddMonthSubscription(MonthSubscriptionModel subscription)
        {
            try
            {
                string query = $@"INSERT INTO [pulseup_gym_management_system].[month_subscription] 
                                (num_of_attend, start_date, remain_freze_day, memberID, employeeID, monthID) VALUES 
                                ({subscription.NumberOfAttend}, GETDATE(), {subscription.RemainFrezeDay}, {subscription.Member.Id}, {subscription.Employee.Id}, {subscription.MonthOffer.Id})";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Month Subscription created successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error adding month subscription: No rows affected");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error adding month subscription in MySql: {ex.Message}");
                return false;
            }
        }

    }
}