using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAgenda.Entities
{
    internal class Event(string title,
        string? description = null, Location? location=null)
    {
        internal readonly int id = Aid.AidClasses.AidIdentifier.RandomIntId(4);

        internal string Title { get; set; } = title;

        internal string Description { get; set; } = description ?? string.Empty;

        internal Location? Location { get; set; } = location;


    }
}
