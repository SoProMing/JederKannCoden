using Microsoft.AspNetCore.Mvc;
using SharedLibrary;
using System.Collections.Generic;
using System.Linq;

namespace DotNetBe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        // Interner Speicher (RAM) für Spieler
        private static readonly List<Player> Players = new();

        // Gibt alle Spieler zurück (GET /players)
        [HttpGet]
        public ActionResult<List<Player>> GetPlayers()
        {
            return Players;
        }

        // Fügt einen Spieler hinzu (POST /players)
        [HttpPost]
        public ActionResult<Player> AddPlayer([FromBody] Player newPlayer)
        {
            // Neue ID generieren
            newPlayer.Id = Players.Count > 0 ? Players.Max(p => p.Id) + 1 : 1;
            Players.Add(newPlayer);
            return CreatedAtAction(nameof(GetPlayers), new { id = newPlayer.Id }, newPlayer);
        }

        // Aktualisiert einen Spieler (PUT /players/{id})
        [HttpPut("{id}")]
        public IActionResult UpdatePlayer(int id, [FromBody] Player updated)
        {
            var existing = Players.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound();

            existing.FirstName = updated.FirstName;
            existing.LastName = updated.LastName;
            return NoContent();
        }

        // Löscht einen Spieler (DELETE /players/{id})
        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(int id)
        {
            var player = Players.FirstOrDefault(p => p.Id == id);
            if (player == null) return NotFound();

            Players.Remove(player);
            return NoContent();
        }

        // Initialisiert aus GitLab (einmalig aufrufbar)
        [HttpPost("loadFromGitlab")]
        public async Task<IActionResult> LoadFromGitlab()
        {
            var gitlabUsers = await GitLabUserLoader.FetchUsersAsync();

            // Spieler aus GitLab-Daten erzeugen
            foreach (var user in gitlabUsers)
            {
                var parts = user.name.Split(' ', 2);
                Players.Add(new Player
                {
                    Id = user.id,
                    FirstName = parts.FirstOrDefault() ?? "",
                    LastName = parts.Skip(1).FirstOrDefault() ?? ""
                });
            }

            return Ok(Players);
        }
    }
}