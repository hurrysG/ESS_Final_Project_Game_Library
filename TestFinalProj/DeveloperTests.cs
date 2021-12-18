using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINALPROJ.Models.Entities;
using FINALPROJ;
using Xunit;

namespace TestFinalProj
{
    public class DeveloperTests
    {
        [Fact]
        public void SetName_NotEmptyString_NameSet()
        {
            var game = new Game();
            game.Name = "Kojima";
            Assert.Equal("Kojima", game.Name);
            
        }
        
    }
}