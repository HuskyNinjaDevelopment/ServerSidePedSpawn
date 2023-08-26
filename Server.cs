using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSidePedSpawn
{
    internal class Server: BaseScript
    {
        private List<int> _peds;

        public Server()
        {
            _peds = new List<int>();
            EventHandlers["SSPS:CreatePed"] += new Action<float, float, float, uint, float>(SpawnNewPed);
        }

        private void SpawnNewPed(float x, float y, float z, uint hash, float heading)
        {
            int handle = API.CreatePed(0, hash, x, y, z, heading, true, true);

            _peds.Add(handle);

            Debug.WriteLine($"New Ped Spawned AT: {x},{y},{z}");
        }
    }
}
