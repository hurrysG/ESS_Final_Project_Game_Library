using System;
using Xunit;
using FINALPROJ;
using FINALPROJ.Models.Entities;

namespace TestFinalProj
{
    public class GameTests
    {
        [Fact]
        public void SetName_NotEmptyString_NameSet()
        {
            var game = new Game();
            game.Name = "MGS";
            Assert.Equal("MGS", game.Name);
            
        }
    }
}
