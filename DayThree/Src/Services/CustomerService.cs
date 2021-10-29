using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using CrashCourse2021ExercisesDayThree.DB.Impl;
using CrashCourse2021ExercisesDayThree.Models;

namespace CrashCourse2021ExercisesDayThree.Services
{
    public class CustomerService
    {
        CustomerTable db; 
        public CustomerService()
        {
            this.db = new CustomerTable();
        }

        //Create and return a Customer Object with all incoming properties (no ID)
        internal Customer Create(string firstName, string lastName, DateTime birthDate)
        {
            if (firstName.Length < 2)
            {
                throw new ArgumentException(Constants.FirstNameException);
            }
            return new Customer() {FirstName = firstName, LastName = lastName, BirthDate = birthDate};
        }

        //db has an Add function to add a new customer!! :D
        //We can reuse the Create function above..
        internal Customer CreateAndAdd(string firstName, string lastName, DateTime birthDate)
        {
            return db.AddCustomer(Create(firstName,lastName,birthDate));
        }

        //Simple enough, Get the customers from the "Database" (db)
        internal List<Customer> GetCustomers()
        {
            return db.GetCustomers();
        }

        //Maybe Check out how to find in a LIST in c# Maybe there is a Find function?
        public Customer FindCustomer(int customerId)
        {
            if (customerId < 0)
            {
                throw new InvalidDataException(Constants.CustomerIdMustBeAboveZero);
            }

            foreach (var customer in db.GetCustomers())
            {
                if (customer.Id == customerId)
                {
                    return customer;
                }
            }

            return null;
        }
        
        /*So many things can go wrong here...
          You need lots of exceptions handling in case of failure and
          a switch statement that decides what property of customer to use
          depending on the searchField. (ex. case searchfield = "id" we should look in customer.Id 
          Maybe add searchField.ToLower() to avoid upper/lowercase letters)
          Another thing is you should use FindAll here to get all that matches searchfield/searchvalue
          You could also make another search Method that only return One Customer
           and uses Find to get that customer and maybe even test it.
        */
        public List<Customer> SearchCustomer(string searchField, string searchValue)
        {
            if (searchField == null)
            {
                throw new InvalidDataException(Constants.CustomerSearchFieldCannotBeNull);
            }
            
            if (searchValue == null)
            {
                throw new InvalidDataException(Constants.CustomerSearchValueCannotBeNull);
            }

            if (!int.TryParse(searchValue, out int searchValueNumber))
            {
                if (searchField != "")
                {
                    throw new InvalidDataException(Constants.CustomerSearchFieldNotFound);
                }

                if (searchField == "id" && searchValueNumber <= 0)
                {
                    throw new InvalidDataException(Constants.CustomerSearchValueWithFieldTypeIdMustBeANumber);
                }
                
                if (searchValueNumber <= 0)
                {
                    throw new InvalidDataException(Constants.CustomerSearchValueWithFieldTypeIdMustBeANumber);
                }
                throw new InvalidDataException(Constants.CustomerSearchValueWithFieldTypeIdMustBeANumber);
            }

            if (searchValueNumber <= 0)
            {
                throw new InvalidDataException(Constants.CustomerIdMustBeAboveZero);
            }
            
            return db.GetCustomers().FindAll(customer => Equals(searchValue));
        }
    }
}
