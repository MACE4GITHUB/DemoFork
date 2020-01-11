﻿using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public class BookmarkServiceDb : IBookmarkServiceDb
    {
        private readonly CourseContext context;

        public BookmarkServiceDb(CourseContext context)
        {
            this.context = context;
        }

        public void Add(CourseBookmarkDb bookmark)
        {
            context.CourseBookmarks.Add(bookmark);
            context.SaveChanges();
        }
        public Task<CourseBookmarkDb> AddAsync(CourseBookmarkDb bookmark)
        {
            context.CourseBookmarks.Add(bookmark);
            context.SaveChanges();
            return Task.FromResult(bookmark);
        }

        public IEnumerable<CourseBookmarkDb> GetAll()
        {
            var bookmarks = context.CourseBookmarks.ToList().AsReadOnly();
            return bookmarks;
        }
        public CourseBookmarkDb GetById(string id)
        {
            var bookmark = context.CourseBookmarks.FirstOrDefault(c => c.Id.Equals(id));
            return bookmark;
        }

        public void Delete(CourseBookmarkDb bookmark)
        {
            context.CourseBookmarks.Remove(bookmark);
            context.SaveChanges();
        }

    }
}
