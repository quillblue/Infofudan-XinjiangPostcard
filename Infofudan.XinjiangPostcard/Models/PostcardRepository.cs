﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infofudan.XinjiangPostcard.Models
{
    public class PostcardRepository
    {
        PostcardsDataContext db = new PostcardsDataContext();

        public void InsertPostcard(Postcard p)
        {
            db.Postcard.InsertOnSubmit(p);
            UpdatePlaceCount(Convert.ToInt32(p.SenderPlaceId));
            db.SubmitChanges();
        }

        public void InsertPlace(Place p)
        {
            db.Place.InsertOnSubmit(p);
            db.SubmitChanges();
        }

        public IQueryable<Place> GetPlaceList(int mode)
        {
            return db.Place.Where(p => p.Type == mode);
        }

        public int GetPlaceIdByName(String name, int mode)
        {
            Place pl = db.Place.FirstOrDefault(p => p.Type == mode && p.CityName == name);
            if (pl == null)
            {
                return -1;
            }
            return pl.Id;
        }

        public Postcard GetPostcardById(int id)
        {
            return db.Postcard.FirstOrDefault(p => p.Id == id);
        }

        public int GetLatestPlaceId(int mode)
        {
            return db.Place.Where(p => p.Type == mode).OrderByDescending(p=>p.Id).First().Id;
            //return db.Place.LastOrDefault(p => p.Type == mode).Id;
        }
        
        public void UpdatePlaceCount(int placeId)
        {
            Place pl = db.Place.FirstOrDefault(p => p.Id == placeId);
            pl.Count += 1;
            db.SubmitChanges();
        }

        public void Delete(Postcard p)
        {
            db.Postcard.DeleteOnSubmit(p);
        }

        public void Delete(int id)
        {
            Postcard p = GetPostcardById(id);
            if (p != null)
            {
                Delete(p);
            }
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}