using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.InfraData.Migrations
{

    public partial class SeedProducts : Migration
    {

        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products (Name, Description, Image, Stock, Price, CategoryId) VALUES ('Caderno', 'Caderno de 100 folhas', 'caderno.jpg', 50, 9.99, 1)");
            mb.Sql("INSERT INTO Products (Name, Description, Image, Stock, Price, CategoryId) VALUES ('Caneta', 'Caneta esferográfica azul', 'caneta.jpg', 100, 1.99, 1)");
            mb.Sql("INSERT INTO Products (Name, Description, Image, Stock, Price, CategoryId) VALUES ('Mochila', 'Mochila escolar resistente', 'mochila.jpg', 30, 49.99, 1)");
            mb.Sql("INSERT INTO Products (Name, Description, Image, Stock, Price, CategoryId) VALUES ('Calculadora', 'Calculadora científica', 'calculadora.jpg', 20, 29.99, 2)");
            mb.Sql("INSERT INTO Products (Name, Description, Image, Stock, Price, CategoryId) VALUES ('Fone de Ouvido', 'Fone de ouvido com cancelamento de ruído', 'fone.jpg', 15, 99.99, 2)");
        }


        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products WHERE Name = 'Caderno' AND Description = 'Caderno de 100 folhas'");
        }
    }
}
