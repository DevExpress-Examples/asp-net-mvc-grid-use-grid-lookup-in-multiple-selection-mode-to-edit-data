﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Ex_2.Models
{
    public static class DataProvider
    {
        static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        static IList<GridDataItem> GridData
        {
            get
            {
                const string key = "6B95C3EB-8FB0-4BF6-8E10-BFA51D18CE72";
                if (Session[key] == null)
                    Session[key] = CreateGridData();
                return (IList<GridDataItem>)Session[key];
            }
        }
        static IList<Tag> Tags
        {
            get
            {
                const string key = "{70DDA114-EBF1-4990-B3D5-20E1C60CEBF8}";
                if (Session[key] == null)
                    Session[key] = CreateTags();
                return (IList<Tag>)Session[key];
            }
        }

        static IList<GridDataItem> CreateGridData()
        {
            var result = new List<GridDataItem>();
            for (int i = 0; i < 100; i++)
                result.Add(new GridDataItem()
                {
                    ID = i,
                    TagIDs = new int[] { 
                    i % 2 == 0 ? 0 : 1, 
                    i % 3 == 0 ? 2 : 3 
                }
                });
            return result;
        }

        static IList<Tag> CreateTags()
        {
            var result = new List<Tag>();
            for (int i = 0; i < 5; i++)
                result.Add(new Tag() { ID = i, Name = "#Tag" + i });
            return result;
        }

        public static IList<GridDataItem> GetGridData()
        {
            return GridData;
        }

        public static IList<Tag> GetTags()
        {
            return Tags;
        }

        public static void InsertGrid(GridDataItem item)
        {
            item.ID = GridData.Max(i => i.ID);
            item.ID++;
            GridData.Add(item);
        }

        public static void UpdateGrid(GridDataItem item)
        {
            GridData.First(i => i.ID == item.ID).TagIDs = item.TagIDs;
        }

        public static void DeleteGrid(GridDataItem item)
        {
            GridData.Remove(GridData.First(i => i.ID == item.ID));
        }
    }

    public class GridDataItem
    {
       
        public int ID { get; set; }
        [Required(ErrorMessage="At least one tag should be selected")]
        public int[] TagIDs { get; set; }
    }

    public class Tag
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}