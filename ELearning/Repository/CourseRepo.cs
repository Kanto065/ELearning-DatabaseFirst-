using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Models;

namespace ELearning.Repository
{
    public class CourseRepo
    {
        public List<CategoryModel> GetCategory()
        {
            using (var context = new ELearningEntities())
            {
                var result = context.Category.Select(x=> new CategoryModel { Id = x.Id,Name=x.Name }).ToList();
                return result;
            }
        }

        public int AddCourse(CourseModel model)
        {
            using(var context = new ELearningEntities())
            {
               /* Category category = context.Category.FirstOrDefault(c => c.Id == model.Category.Id);

                if (category == null)
                {
                    category = new Category { Id = model.Category.Id };
                    context.Category.Add(category);
                }*/

                Course course = new Course()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Learning = model.Learning,
                    Thumbnail = model.Thumbnail,
                    CategoryId = model.CategoryId,
                    //Category = category
                };

                context.Course.Add(course);
                context.SaveChanges();

                return course.Id;

            }
        }
        public List<CourseModel> GetAllData()
        {
            using (var context = new ELearningEntities())
            {
                var result = context.Course.Select(x => new CourseModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Learning = x.Learning,
                    Thumbnail = x.Thumbnail,
                    CategoryId = x.CategoryId,
                    Category = new CategoryModel()
                    {
                        Id = x.Category.Id,
                        Name = x.Category.Name
                    }
                }
                ).ToList();
                return result;
            }
        }

        public CourseModel GetDetails(int id)
        {
            using (var context = new ELearningEntities())
            {
                var result = context.Course.Where(x => x.Id == id).Select(x => new CourseModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Learning = x.Learning,
                    Thumbnail = x.Thumbnail,
                    CategoryId= x.CategoryId,
                    Category = new CategoryModel()
                    {
                        Id = x.Category.Id,
                        Name = x.Category.Name
                    }
                }
                ).FirstOrDefault();

                return result;
            }
        }
        public bool UpdateData(int id, CourseModel model)
        {
            using (var context = new ELearningEntities())
            {
                /*Category category = context.Category.FirstOrDefault(c => c.Id == model.Category.Id);

                if (category == null)
                {
                    category = new Category { Name = model.Category.Name };
                    context.Category.Add(category);
                }*/

                var course = context.Course.FirstOrDefault(x => x.Id == id);
                if (course != null)
                {
                    course.Title = model.Title;
                    course.Description = model.Description;
                    course.Learning = model.Learning;
                    course.Thumbnail = model.Thumbnail;
                    course.CategoryId = model.CategoryId;
                    //course.Category = category;
                }

                context.SaveChanges();

                return true;
            }
        }

        public bool DeleteData(int id)
        {
            using (var context = new ELearningEntities())
            {
                var course = context.Course.FirstOrDefault(x => x.Id == id);
                if (course != null)
                {
                    context.Course.Remove(course);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}