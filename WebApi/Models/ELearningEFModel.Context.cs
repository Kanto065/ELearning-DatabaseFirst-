﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ELearningEntities : DbContext
    {
        public ELearningEntities()
            : base("name=ELearningEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseInstructorTable> CourseInstructorTable { get; set; }
        public virtual DbSet<CourseModuleTable> CourseModuleTable { get; set; }
        public virtual DbSet<CourseStudentTable> CourseStudentTable { get; set; }
        public virtual DbSet<CourseTestimonialTable> CourseTestimonialTable { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentTestimonialTable> StudentTestimonialTable { get; set; }
        public virtual DbSet<Testimonial> Testimonial { get; set; }
    }
}