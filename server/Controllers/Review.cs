// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using server.Data;
// using server.Models;

// namespace server.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class Review : ControllerBase
//     {
//         private readonly ApplicationDBContext _context;

//         public Review(ApplicationDBContext context)
//         {
//             _context = context;
//         }

//         // GET: api/Review
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Review>>> GetReview()
//         {
//             return await _context.Review.ToListAsync();
//         }

//         // GET: api/Review/5
//         [HttpGet("{id}")]
//         public async Task<ActionResult<Review>> GetReview(long id)
//         {
//             var review = await _context.Review.FindAsync(id);

//             if (review == null)
//             {
//                 return NotFound();
//             }

//             return review;
//         }

//         // PUT: api/Review/5
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutReview(long id, Review review)
//         {
//             if (id != review.Id)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(review).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!ReviewExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return NoContent();
//         }

//         // POST: api/Review
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPost]
//         public async Task<ActionResult<Review>> PostReview(Review review)
//         {
//             _context.Review.Add(review);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction("GetReview", new { id = review.Id }, review);
//         }

//         // DELETE: api/Review/5
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteReview(long id)
//         {
//             var review = await _context.Review.FindAsync(id);
//             if (review == null)
//             {
//                 return NotFound();
//             }

//             _context.Review.Remove(review);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }

//         private bool ReviewExists(long id)
//         {
//             return _context.Review.Any(e => e.Id == id);
//         }
//     }
// }
