﻿using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Service
{
    public class PaymentService
    {
        public static List<PaymentModel> GetAllPayments(bool includeMemberData = false, bool includeEmployeeData = false)
        {
            try
            {
                List<PaymentModel> payments = new List<PaymentModel>();
                string query = $"SELECT * FROM payments";
                MySqlDataReader reader = Global.sqlService.SqlSelect(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PaymentModel payment = new PaymentModel(
                            id: Convert.ToInt32(reader["id"]),
                            name: reader["name"].ToString(),
                            amount: Convert.ToInt32(reader["amount"]),
                            date: Convert.ToDateTime(reader["date"]),
                            member: includeMemberData ? new MemberModel(id: Convert.ToInt32(reader["memberID"])) : null,
                            employee: includeEmployeeData ? new EmployeeModel(id: Convert.ToInt32(reader["employeeID"])) : null
                        );

                        payments.Add(payment);
                    }

                    return payments;
                }
                else
                {
                    Console.WriteLine("Error getting from GetAllPayments: No records found");
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting from MySql GetAllPayments: {ex.Message}");
                return null;
            }
        }
        public bool InsertPayment(PaymentModel payment)
        {
            try
            {
                string query = $"INSERT INTO payment (name, amount, date, memberID, employeeID) VALUES " +
                               $"('{payment.Name}', {payment.Amount}, now(), " +
                               $"{payment.Member.Id}, {payment.Employee.Id})";


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
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error inserting payment into database: {ex.Message}");
                return false;
            }
        }

        public bool UpdatePaymentAttributes(PaymentModel paymentModel, bool name = false, bool amount = false, bool date = false, bool memberId = false, bool employeeId = false)
        {
            try
            {
                string query = "UPDATE payments SET";
                if (name)
                {
                    query += $" name = '{paymentModel.Name}',";
                }
                if (amount)
                {
                    query += $" amount = {paymentModel.Amount},";
                }
                if (date)
                {
                    query += $" date = '{paymentModel.Date.ToString("yyyy-MM-dd HH:mm:ss")}',";
                }
                if (memberId)
                {
                    query += $" memberID = {(paymentModel.Member != null ? paymentModel.Member.Id.ToString() : "NULL")},";
                }
                if (employeeId)
                {
                    query += $" employeeID = {(paymentModel.Employee != null ? paymentModel.Employee.Id.ToString() : "NULL")},";
                }

                if (query == "UPDATE payments SET")
                {
                    Console.WriteLine($"Error updating payment attributes: No selected data modified");
                    return false;
                }

                query = query.Substring(0, query.Length - 1);
                query += $" WHERE id = {paymentModel.Id}";

                int rowsAffected = Global.sqlService.SqlNonQuery(query);

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Payment attributes updated successfully for ID: {paymentModel.Id}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error updating payment attributes: No rows affected for ID: {paymentModel.Id}");
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error updating payment attributes in MySql: {ex.Message}");
                return false;
            }
        }
    }
}
