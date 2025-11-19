using System.DirectoryServices.Protocols;

namespace Enterprice
{
    public class GroupADService
    {
        public static List<ADGroup> GetAllGroups()
        {
            var groups = new List<ADGroup>();
            Console.WriteLine("Starter hentning af AD grupper...");

            using (var connection = ADService.Connect())
            {
                Console.WriteLine("Forbindelse oprettet. Forbereder søgeforespørgsel efter grupper.");

                var searchRequest = new SearchRequest(
                    "DC=mags,DC=local",
                    "(objectClass=group)",
                    SearchScope.Subtree,
                    "cn",
                    "description"
                );

                try
                {
                    var response = (SearchResponse)connection.SendRequest(searchRequest);
                    Console.WriteLine($"Søgningen returnerede {response.Entries.Count} grupper.");

                    foreach (SearchResultEntry gruppe in response.Entries)
                    {
                        var nyGruppe = new ADGroup
                        {
                            Name = gruppe.Attributes["cn"]?[0]?.ToString() ?? "N/A",
                            Description = gruppe.Attributes["description"]?[0]?.ToString() ?? "N/A"
                        };

                        groups.Add(nyGruppe);
                        Console.WriteLine($"Tilføjet gruppe: {nyGruppe.Name} - {nyGruppe.Description}");
                    }

                    Console.WriteLine("Alle grupper er nu hentet og tilføjet til listen.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Der opstod en fejl under hentning af grupper.");
                    throw new Exception(
                        $"Der skete en fejl ved hentning af grupper:\n{ex.Message}"
                    );
                }
            }

            Console.WriteLine($"Returnerer {groups.Count} grupper til kaldende kode.");
            return groups;
        }
    }

    public class ADGroup
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
