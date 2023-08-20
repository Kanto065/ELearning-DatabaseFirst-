using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessEntityLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CourseService
    {
        public static List<CourseModel> Get()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Course, CourseModel>();
                c.CreateMap<Category, CategoryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.CourseDataAccess();
            var data = mapper.Map<List<CourseModel>>(da.Get());
            return data;
        }

        public static List<CategoryModel> GetCategory()
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Course, CourseModel>();
                c.CreateMap<Category, CategoryModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.CategoryDataAccess();
            var data = mapper.Map<List<CategoryModel>>(da.Get());
            return data;
        }

        public static void Add(CourseModel course)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CourseModel, Course>();
            });
            var mapper = new Mapper(config);
            /*var c = new CourseModel()
            {
                CreatedAt = DateTime.Now,
            };*/
            var data = mapper.Map<Course>(course);
            DataAccessFactory.CourseDataAccess().Add(data);
        }

        public static void delete(int id)
        { 
            DataAccessFactory.CourseDataAccess().Delete(id);
        }

        public static void Edit(CourseModel course)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CourseModel, Course>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Course>(course);
            DataAccessFactory.CourseDataAccess().Edit(data);
        }

    }
}
