﻿using BAL.Interface;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VacationManageApi.Controllers
{
	[Authorize]
	[RoutePrefix("api/Employee")]
	public class EmployeeController : ApiController
    {
		private readonly IEmployeeManager employeeManager;
		private readonly IUserManager userManager;
		public EmployeeController(IEmployeeManager employeeManager,IUserManager userManager)
		{
			this.employeeManager = employeeManager;
			this.userManager = userManager;
		}
		/// <summary>
		/// Create new vacation request
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("Create")]
		public IHttpActionResult Create([FromBody]CreateRequestDTO request)
		{
			try
			{
				var fullName = userManager.GetFullName(request.UserId);
				employeeManager.Create(request);
				return Ok(fullName);
			}
			catch (Exception ex)
			{
				return NotFound();
			}
		}
		/// <summary>
		/// Remove vacation request
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete]
		[Route("Remove/{id}")]
		public IHttpActionResult Remove(int id)
		{
			try
			{
				employeeManager.Remove(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return NotFound();
			}
		}

	}
}
