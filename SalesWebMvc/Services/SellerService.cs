﻿using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll() 
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller) 
        {
            _context.Seller.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id) 
        {
            return _context.Seller.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
        }

        public void Remove(int id)
        {
            var seller = FindById(id);
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }
    }
}
