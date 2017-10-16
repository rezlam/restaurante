﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Restaurante.Api.Models;
using Restaurante.Api.Models.Validation;
using Restaurante.Api.Repositories;

namespace Restaurante.Api.Controllers
{
    [RoutePrefix("restaurants")]
    public class RestaurantsController : ApiController
    {
        private RestaurantRepository _repository = new RestaurantRepository();

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> ListRestaurants()
        {
            try {
                Dictionary<string, string> queryString = ControllerContext.Request
                                                                          .GetQueryNameValuePairs()
                                                                          .ToDictionary(
                                                                              p => p.Key,
                                                                              p => p.Value,
                                                                              StringComparer.OrdinalIgnoreCase
                                                                          );

                if (queryString.Count > 0) {
                    var hasFilter = queryString.TryGetValue("filter", out string filterValue);

                    if (hasFilter && string.IsNullOrWhiteSpace(filterValue) == false) {
                        return Ok(await _repository.Find(filterValue));
                    }
                }
            
                return Ok(await _repository.List());
            } catch (Exception) {
                return InternalServerError();
            }
        }

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> CreateRestaurant(Restaurant dto)
        {
            if (dto.TryValidateForCreate(out string validationMessage) == false) {
                return BadRequest(validationMessage);
            }

            try {
                int id = await _repository.Create(dto);

                if (id == -1) {
                    return Conflict();
                }

                if (id == 0) {
                    return StatusCode(HttpStatusCode.ExpectationFailed);
                }

                dto.Id = id;

                return Created(Url.Link("ShowRestaurant", new { id = id }), dto);
            } catch (Exception) {
                return InternalServerError();
            }
        }

        [HttpGet, Route("{id:int}", Name = "ShowRestaurant")]
        public async Task<IHttpActionResult> ShowRestaurant(int id)
        {
            if (id < 1) {
                return BadRequest($"Validation failed for property '{nameof(id)}'.");
            }

            try {
                var dto = await _repository.Find(id);

                if (dto == null) {
                    return NotFound();
                }

                return Ok(dto);
            } catch (Exception) {
                return InternalServerError();
            }
        }

        [HttpPut, Route("{id:int}")]
        public async Task<IHttpActionResult> UpdateRestaurant(int id, Restaurant dto)
        {
            if (dto.TryValidateForUpdate(out string validationMessage) == false) {
                return BadRequest(validationMessage);
            }

            if (id != dto.Id) {
                return BadRequest($"Validation failed for property '{nameof(id)}': ID mismatch.");
            }

            try {
                if ((await _repository.Update(dto)) == false) {
                    return StatusCode(HttpStatusCode.ExpectationFailed);
                }

                return StatusCode(HttpStatusCode.NoContent);
            } catch (Exception) {
                return InternalServerError();
            }
        }

        [HttpDelete, Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteDestaurant(int id)
        {
            if (id < 1) {
                return BadRequest($"Validation failed for property '{nameof(id)}'.");
            }

            try {
                if ((await _repository.Delete(id)) == false) {
                    return NotFound();
                }

                return StatusCode(HttpStatusCode.NoContent);
            } catch (Exception) {
                return InternalServerError();
            }
        }
    }
}
