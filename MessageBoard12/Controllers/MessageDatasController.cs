using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard12.Models;
using MessageBoard12.Pages;

namespace MessageBoard12.ClientApp
{
    [Route("api/MessageData")]
    [ApiController]
    public class MessageDatasController : ControllerBase
    {
        private readonly MessageBoard12Context _context;

        public MessageDatasController(MessageBoard12Context context)
        {
            _context = context;
        }

        // GET: api/MessageDatas
        [HttpGet]
        public IEnumerable<MessageData> GetMessageData()
        {
            return _context.messageData;
        }

        // GET: api/MessageDatas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var messageData = await _context.messageData.FindAsync(id);

            if (messageData == null)
            {
                return NotFound();
            }

            return Ok(messageData);
        }

        // PUT: api/MessageDatas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageData([FromRoute] int id, [FromBody] MessageData messageData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != messageData.id)
            {
                return BadRequest();
            }

            _context.Entry(messageData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MessageDatas
        [HttpPost]
        public async Task<IActionResult> PostMessageData([FromBody] MessageData messageData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.messageData.Add(messageData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageData", new { id = messageData.id }, messageData);
        }

        // DELETE: api/MessageDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var messageData = await _context.messageData.FindAsync(id);
            if (messageData == null)
            {
                return NotFound();
            }

            _context.messageData.Remove(messageData);
            await _context.SaveChangesAsync();

            return Ok(messageData);
        }

        private bool MessageDataExists(int id)
        {
            return _context.messageData.Any(e => e.id == id);
        }
    }
}