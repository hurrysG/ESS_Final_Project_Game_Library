using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINALPROJ.Models.Entities;
using FINALPROJ;
using Xunit;

namespace TestFinalProj
{
    public class PublisherTests
    {
        [Fact]
        public void SetName_NotEmptyString_NameSet()
        {
            var game = new Game();
            game.Name = "Konami";
            Assert.Equal("Konami", game.Name);
            
        }
    }
}