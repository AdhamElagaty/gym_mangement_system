using gym_management_system.Models;
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
        public List<PaymentModel> GetAllPayments()
        {
            try
            {
                List<PaymentModel> payments = new List<PaymentModel>();
                string query = @"
            SELECT 
                p.id AS payment_id,
                p.name AS payment_name,
                p.amount,
                p.date,
                m.id AS member_id,
                m.first_name AS member_first_name,
                m.second_name AS member_second_name,
                e.id AS employee_id,
                e.first_name AS employee_first_name,
                e.second_name AS employee_second_name
            FROM 
                payment p
            JOIN 
                member m ON p.memberID = m.id
            JOIN 
                employee e ON p.employeeID = e.id";

                using (MySqlDataReader reader = Global.sqlService.SqlSelect(query))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
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

                            PaymentModel payment = new PaymentModel
                            {
                                Id = Convert.ToInt32(reader["payment_id"]),
                                Name = reader["payment_name"].ToString(),
                                Amount = Convert.ToInt32(reader["amount"]),
                                Date = Convert.ToDateTime(reader["date"]),
                                Member = member,
                                Employee = employee
                            };

                            payments.Add(payment);
                        }

                        return payments;
                    }
                    else
                    {
                        Console.WriteLine("No payment records found.");
                        return null;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error getting payments from MySQL: {ex.Message}");
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
