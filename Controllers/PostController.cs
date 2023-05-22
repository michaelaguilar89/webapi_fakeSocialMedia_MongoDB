using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMongoSaveImage.Models;
using WebApiMongoSaveImage.Services;

namespace WebApiMongoSaveImage.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostController : ControllerBase
	{
		private readonly PostingService _service;

		public PostController(PostingService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetPost()
		{
			try
			{

				var result = await _service.GetAsync();
				if (result==null)
				{
					return NotFound();
				}
				return Ok(result);
			}
			catch (Exception e)
			{
				return BadRequest("internal error : "+e.ToString());
				
			}
		
		}
		[HttpGet("{id:length(24)}")]
		public async Task<IActionResult> GetPostById(string id)
		{
			try
			{
				var result=await _service.GetAsyncId(id);
				if(result is null)
				{
					return NotFound("data not found");
				}
				return Ok(result);
			}
			catch (Exception e)
			{

				return BadRequest("error : " + e.ToString());
			}
		}
		[HttpDelete("{id:length(24)}")]
		public async Task<IActionResult> DeletePost(string id)
		{
			try
			{
				var result = await _service.RemoveAsync(id);
				if (result == "Remove Ok")
				{
					return Ok("Remove Ok");
				}
				return BadRequest("Internal server error");

			}
			catch (Exception e)
			{

				return BadRequest("Internal server error : "+e.ToString());
			}
		}

		[HttpPut]
		public async Task<IActionResult> UpdatePost(Post updatePost)
		{
			try
			{
				var result = await _service.GetAsyncId(updatePost.Id);
				if (result is null)
				{
					return NotFound();
				}

				var result2=await _service.UpdateAsync(updatePost.Id, updatePost);
				if (result2 == "Update Ok")
				{
					return Ok("Update Ok");
				}
				return BadRequest("Internal error");
			}
			catch (Exception e) 
			{

				return BadRequest("Internal server Error : "+e.ToString());
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreatePost(Post myPost)
		{
			try
			{
				var result = await _service.CreateAsync(myPost);
				if (result== "Insert Ok")
				{
					return Ok("Insert Ok");
				}
				else
				
					if(result == "-500")
					{
						return BadRequest("Error internal server");
					}
					
				
				return BadRequest("Can't connect to database");
			}
			catch (Exception e)
			{

				return BadRequest("Error : "+e.ToString());
			}
		}

	}
}
