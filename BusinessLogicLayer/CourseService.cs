﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.BusinessEntity;
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
            var data = mapper.Map<List<CourseModel>>(CourseRepo.Get());
            return data;
        }

        public static void Add(CourseModel course)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CourseModel, Course>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Course>(course);
            CourseRepo.Add(data);
        }

    }
}