using SalesWebMVC2.Data;
using SalesWebMVC2.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC2.Services.Exceptions;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC2.Services;
using SalesWebMVC2.Models.ViewModels;
using System.Threading.Tasks;

namespace SalesWebMVC2.Services
{
	public class SellerService
	{
		private readonly SalesWebMVC2Context _context;

		public SellerService(SalesWebMVC2Context context)
		{
			_context = context;
		}

		public async Task<List<Seller>> FindAllAsync()
		{
			return await _context.Seller.ToListAsync();
		}
		public async Task InsertAsync(Seller obj)
		{
			_context.Add(obj);
			await _context.SaveChangesAsync();
		}

		public async Task<Seller> FindByIdAsync(int id)
		{
			return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
		}

		public async Task RemoveAsync(int id)
		{

			try
			{

				var obj = await _context.Seller.FindAsync(id);
				_context.Seller.Remove(obj);
				await _context.SaveChangesAsync();

			}
			catch (DbUpdateException e)
			{
				throw new IntegrityException("Can´t delete seller because he/she has sales");
			}
			
	}

		public async Task UpdateAsync(Seller obj)
		{
			bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

			if (!hasAny)
			{
				throw new NotFoundException("Id not found");
			}
			try
			{

				_context.Update(obj);
				await _context.SaveChangesAsync();
			}

			catch (DbUpdateConcurrencyException e)
			{
				throw new DbUpdateConcurrencyException(e.Message);
			}
		}
	}
}
