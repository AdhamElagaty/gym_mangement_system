﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Models
{
    public class PaymentModel
    {
        private int id;
        private double amount;
        private string name;
        private DateTime date;
        private MemberModel member;
        private EmployeeModel employee;
        public PaymentModel(int id = 0, string name = null, double amount = 0, DateTime date = default, MemberModel member = null, EmployeeModel employee = null)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Date = date;
            Member = member;
            Employee = employee;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public double Amount { get { return amount; } set { amount = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public MemberModel Member { get { return member; } set { member = value; } }
        public EmployeeModel Employee { get { return employee; } set { employee = value; } }
        public int MemberId { get { return Member.Id; } }
        public int EmployeeId { get { return Employee.Id; } }
        public string MemberName { get { return Member.Name; } }
        public string EmployeeName { get { return Employee.Name; } }
    }
}
