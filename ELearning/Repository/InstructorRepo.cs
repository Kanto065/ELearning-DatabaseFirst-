using ELearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELearning.Repository
{
    public class InstructorRepo
    {
        public int AddInstructor(InstructorModel instructorModel)
        {
            using (var context = new ELearningEntities())
            {
                Address address = new Address()
                {
                    Address1 = instructorModel.Address.Address1,
                    City = instructorModel.Address.City,
                    Country = instructorModel.Address.Country,
                };

                context.Address.Add(address);

                Instructor instructor = new Instructor()
                {
                    Name = instructorModel.Name,
                    Email = instructorModel.Email,
                    Phone = instructorModel.Phone,
                    AddressId = address.Id,
                    Password = instructorModel.Password
                };

                context.Instructor.Add(instructor);
                context.SaveChanges();

                return instructor.Id;
            }
        }

        public bool VarifyInstructor(InstructorModel model)
        {
            using(var context = new ELearningEntities())
            {
                var result = context.Instructor.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if (result != null)
                {
                    return true;
                }
                return false;
            } 
        }
    }
}