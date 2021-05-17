using System;
using Xunit;
using Grundlæggende_Programmering_Aflevering;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Testinsert()
        {
            Assert.True(SQLconnection.Insert($"INSERT INTO Vare (navn, pris, stock) VALUES ('Rasmus', 200, 2)"));
            Assert.False(SQLconnection.Insert($"INSERT INTO Vare (navn, pris, stock) VALUES ('Rasmus', 'jacob')"));
        }
        [Fact]
        public void Testupdate()
        {
            Assert.True(SQLconnection.Insert($"UPDATE Vare SET navn ='Kage', pris = '200', stock = '3222' WHERE id = 3"));
            Assert.False(SQLconnection.Insert($"UPDATE Vare SET navn ='Kage', pris = Mans WHERE id = 44"));
        }
    }
}
