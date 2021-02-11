using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHouse.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { ID = Guid.NewGuid().ToString(), Name = "Luci camera", Description="Accende le luci nella stanza", IPAddress = "192.168.1.2", PortNumber = "1025", Available = false },
                new Item { ID = Guid.NewGuid().ToString(), Name = "Luci cucina", Description="Accende le luci nella cucina", IPAddress = "192.168.1.2", PortNumber = "1025", Available = false  },
                new Item { ID = Guid.NewGuid().ToString(), Name = "Termostato", Description="Impostazioni del termostato", IPAddress = "192.168.1.2", PortNumber = "1025", Available = false  },
                new Item { ID = Guid.NewGuid().ToString(), Name = "Persiane camera", Description="Alza e abbassa la persiana delle camera", IPAddress = "192.168.1.2", PortNumber = "1025", Available = false  },
                new Item { ID = Guid.NewGuid().ToString(), Name = "Persiane sala", Description="Alza e abbassa la persiana delle Sala", IPAddress = "192.168.1.2", PortNumber = "1025", Available = false  },
                new Item { ID = Guid.NewGuid().ToString(), Name = "Luci sala", Description="Accende le luci nella Sala", IPAddress = "192.168.1.2", PortNumber = "1025", Available = false  }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.ID == item.ID).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.ID == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}