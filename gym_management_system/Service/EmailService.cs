﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using gym_management_system.Models;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace gym_management_system.Service
{
    public class EmailService
    {
        public bool sendEmail(EmailModel emailModel, Image image = null)
        {
            string senderEmail = "pulseupgym@gmail.com";
            string senderPassword = "gpmr vcnt czsm rtva";
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            using (SmtpClient smtpClient = new SmtpClient(smtpServer))
            {
                smtpClient.Port = smtpPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;
                using (MailMessage mailMessage = new MailMessage(senderEmail, emailModel.PersonModel.Email))
                {
                    mailMessage.Subject = emailModel.Subject;
                    mailMessage.Body = emailModel.Body;
                    if (image != null)
                    {
                        ImageConverter converter = new ImageConverter();
                        byte[] imageBytes = (byte[])converter.ConvertTo(image, typeof(byte[]));
                        MemoryStream memoryStream = new MemoryStream(imageBytes);
                        mailMessage.Attachments.Add(new Attachment(memoryStream, "image.png"));
                    }
                    try
                    {
                        smtpClient.Send(mailMessage);
                        Console.WriteLine("Email sent successfully.");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error sending email: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public bool AddMemberEmail(MemberEmailModel memberEmailModel, Image image = null)
        {
            try
            {
                if (sendEmail(memberEmailModel, image))
                {
                    string query = $"INSERT INTO [pulseup_gym_management_system].[member_email] (subject, date, memberID, employeeID) VALUES " +
                               $"('{memberEmailModel.Subject}', GETDATE(), " +
                               $"{memberEmailModel.MemberModel.Id}, {memberEmailModel.EmployeeModel.Id})";

                    int rowsAffected = Global.sqlService.SqlNonQuery(query);

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Member email created successfully");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Error adding member email: No rows affected");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error in send member email");
                    return false;
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error adding member email in MySql: {ex.Message}");
                return false;
            }
        }

        public bool AddEmployeeEmail(EmployeeEmailModel employeeEmailModel, Image image = null)
        {
            try
            {
                if (sendEmail(employeeEmailModel, image))
                {
                    string query = $"INSERT INTO [pulseup_gym_management_system].[employee_email] (subject, date, RemployeeID, employeeID) VALUES " +
                                   $"('{employeeEmailModel.Subject}', GETDATE(), " +
                                   $"{employeeEmailModel.EmployeeModel1.Id}, {employeeEmailModel.EmployeeModel.Id})";

                    int rowsAffected = Global.sqlService.SqlNonQuery(query);

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Employee email created successfully");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Error adding employee email: No rows affected");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error in send employee email");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error adding employee email in MySql: {ex.Message}");
                return false;
            }
        }

        public bool AddTrainerEmail(TrainerEmailModel trainerEmailModel, Image image = null)
        {
            try
            {
                if (sendEmail(trainerEmailModel, image))
                {
                    string query = $"INSERT INTO [pulseup_gym_management_system].[trainer_email] (subject, date, trainerID, employeeID) VALUES " +
                                   $"('{trainerEmailModel.Subject}', GETDATE(), " +
                                   $"{trainerEmailModel.TrainerModel.Id}, {trainerEmailModel.EmployeeModel.Id})";

                    int rowsAffected = Global.sqlService.SqlNonQuery(query);

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Trainer email created successfully");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Error adding trainer email: No rows affected");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error in send trainer email");
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error adding trainer email in MySql: {ex.Message}");
                return false;
            }
        }
    }
}
