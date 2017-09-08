﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coursesProject.Models
{
    public class Project
    {
        public int ID { get; set; }
        [Required]
        public User Athor { get; set; }        
        public string NameProject { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public double Raiting { get; set; }
        public ICollection<Goal> Goals { get; set; }   
        public ICollection<Subscriber> Subscriber { get; set; }
        public ICollection<TagsRelation> TagsRelation { get; set; }
        public ICollection<New> News { get; set; }


        public Project()
        {
            Comment = new List<Comment>();
            Goals = new List<Goal>();
            Subscriber = new List<Subscriber>();
            TagsRelation = new List<TagsRelation>();
            News = new List<New>();
        }
    }



    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [JsonIgnore]
        public Project Project { get; set; }
        public User Author { get; set; }
        public string Context { get; set; }
        public DateTime DateCreate { get; set; }   
    }


    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<TagsRelation> TagsRelation { get; set; }

        public Tag()
        {
            TagsRelation = new List<TagsRelation>();
        }
    }

    public class TagsRelation
    {
        public int Id { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
        [JsonIgnore]
        [Required]
        public Project Project { get; set; }
    }


    //public class Tag
    //{
    //    public int ID { get; set; }
    //    public string Text { get; set; }
    //}


    //public class TagRelation
    //{
    //    public int ID { get; set; }
    //    [Required]
    //    public Project Project { get; set; }
    //    public ICollection<Tag> Tag { get; set; }

    //    public TagRelation()
    //    {
    //        Tag = new List<Tag>();
    //    }
    //}


    public class Goal
    {
        public int ID { get; set; }
        public int NeedMoney { get; set; }
        [Required]
        public Project Project { get; set; }
        public string Text { get; set; }
    }


    public class New
    {
        public int ID { get; set; }
        [Required]
        public Project Project { get; set; }
        public string Text { get; set; }
    }


    public class Subscriber
    {
        public int ID { get; set; }
        public User User { get; set; }
        [Required]
        public Project Project { get; set; }
    }
}
